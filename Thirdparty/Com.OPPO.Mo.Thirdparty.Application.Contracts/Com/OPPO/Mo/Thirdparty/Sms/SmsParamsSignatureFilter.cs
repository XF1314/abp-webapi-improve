using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebApiClient.Attributes;
using WebApiClient.Contexts;

namespace Com.OPPO.Mo.Thirdparty.Sms
{
    public class SmsParamsSignatureFilter : ApiActionFilterAttribute
    {
        private readonly Lazy<IConfiguration> _configuration;
        private readonly Lazy<ILoggerFactory> _loggerFactory;

        public SmsParamsSignatureFilter(Lazy<ILoggerFactory> loggerFactory, Lazy<IConfiguration> configuration)
        {
            _loggerFactory = loggerFactory;
            _configuration = configuration;
        }

        public override int OrderIndex { get { return 0; } }

        public override async Task OnBeginRequestAsync(ApiActionContext apiActionContext)
        {
            try
            {
                apiActionContext.RequestMessage.Headers.Add("Accept", "");
                var apiPath = apiActionContext.RequestMessage.RequestUri.AbsolutePath;
                if (apiActionContext.ApiActionDescriptor.Parameters.Count > 1)
                    throw new Exception("参数个数不能大于1。");

                await FullfillSignatureInfo(apiActionContext, apiPath);

                await base.OnBeginRequestAsync(apiActionContext);
            }
            catch (Exception ex)
            {
                var loggerName = string.Format("{0}.{1}", apiActionContext.ApiActionDescriptor.Member.DeclaringType.FullName, apiActionContext.ApiActionDescriptor.Member.Name);
                var logger = _loggerFactory.Value.CreateLogger(loggerName);
                logger.LogError("参数解析出错。", ex);
            }
        }

        private async Task FullfillSignatureInfo(ApiActionContext apiActionContext, string apiPath)
        {
            var @params = new Dictionary<string, string>();
            var esbSignKey = _configuration.Value[ThirdpartySettingNames.EsbSignKey];
            var messageContent = apiActionContext.RequestMessage.Content;
            if (messageContent != null)
            {
                var contentType = apiActionContext.RequestMessage.Content.Headers.GetValues("Content-Type").FirstOrDefault();
                if (string.IsNullOrEmpty(contentType))
                {
                    throw new Exception("请求参数类型不能为空。");
                }
                if (contentType.Contains(WebApiClientConsts.JsonContentMediaType))//"application/json; charset=utf-8"
                {
                    var jsonFormatter = apiActionContext.HttpApiConfig.JsonFormatter;
                    var options = apiActionContext.HttpApiConfig.FormatOptions;
                    var jsonString = jsonFormatter.Serialize(apiActionContext.ApiActionDescriptor.Parameters[0].Value, options);
                    var jObject = JObject.Parse(jsonString);

                    var sortedDictionary = jObject.ConvertToSortedDictionary();
                    if (sortedDictionary != null && sortedDictionary.Any())
                    {
                        foreach (var keyValuePair in sortedDictionary)
                        {
                            @params.Add(keyValuePair.Key, keyValuePair.Value);
                        }
                    }
                    long createTime = 0;

                    if (@params.ContainsKey("createTime"))
                    {
                        createTime = Convert.ToInt64(@params["createTime"]);
                    }
                    string timeStamp = GetTimeStamp();

                    var dic = new SortedDictionary<string, object>();

                    if (@params.ContainsKey("msgId"))
                    {
                        dic.Add("msgId", @params["msgId"]);
                    }
                    if (@params.ContainsKey("content"))
                    {
                        dic.Add("content", @params["content"]);
                    }
                    if (@params.ContainsKey("mobile"))
                    {
                        dic.Add("mobile", @params["mobile"].Trim());
                    }

                    dic.Add("createTime", createTime);

                    dic.Add("timeStamp", timeStamp);

                    if (@params.ContainsKey("msgId"))
                    {
                        dic.Add("apiKey", _configuration.Value[ThirdpartySettingNames.SmsWebApiPassword]);
                    }

                    string sign = GetSign(dic);
                    string token = EncodeBase64($"{_configuration.Value[ThirdpartySettingNames.SmsWebApiAgentId]},{_configuration.Value[ThirdpartySettingNames.SmsWebApiAppUserName]},{timeStamp},{sign}");

                    apiActionContext.RequestMessage.Headers.Add("Authorization", $"Bearer {token}");
                    apiActionContext.RequestMessage.Content.Dispose();
                    apiActionContext.RequestMessage.Content = new WebApiClientJsonContent(jObject.ToString(), Encoding.UTF8);
                }
                else
                {
                    throw new Exception(string.Format("请求参数类型-{0}不被支持。", contentType));
                }
            }
            else
            {
                var keyValueFormatter = apiActionContext.HttpApiConfig.KeyValueFormatter;
                var options = apiActionContext.HttpApiConfig.FormatOptions;
                var keyValuePairs = keyValueFormatter.Serialize(apiActionContext.ApiActionDescriptor.Parameters[0], options);
                keyValuePairs.ToList().ForEach(x => @params.Add(x.Key, x.Value));

                var sign = GetSignature(@params, apiPath, esbSignKey);
                var requestUri = apiActionContext.RequestMessage.RequestUri.OriginalString;
                requestUri = requestUri.Remove(requestUri.IndexOf('?'));
                var uriEditor = new UriEditor(new Uri(requestUri), Encoding.UTF8);
                foreach (var keyValuePair in keyValuePairs)
                {
                    if (uriEditor.Replace(keyValuePair.Key, keyValuePair.Value) == false)
                    {
                        uriEditor.AddQuery(keyValuePair.Key, keyValuePair.Value);
                    }
                }
                uriEditor.AddQuery("sign", sign);
                apiActionContext.RequestMessage.RequestUri = uriEditor.Uri;
            }
        }

        private static string GetSignature(IDictionary<string, string> @params, string apiPath, string secret)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(apiPath);
            stringBuilder.Append("\n");

            foreach (var param in @params.OrderBy(t => t.Key))
            {
                stringBuilder.AppendFormat("{0}={1}\n", param.Key, param.Value);
            }
            stringBuilder.Append(secret);

            return stringBuilder.ToString().Md5Digest();
        }

        private static string GetSign(IDictionary<string, object> dic)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in dic)
            {
                string key = UrlEncode(item.Key);
                string value = UrlEncode(item.Value.ToString());
                builder.Append(string.Format("{0}={1}&", key, value));
            }
            string str = builder.ToString();
            if (str.Length > 0)
            {
                str = str.Substring(0, str.Length - 1);
            }

            return MD5Encrypt(str);
        }

        private static string UrlEncode(string str)
        {
            StringBuilder builder = new StringBuilder();
            foreach (char c in str)
            {
                string encode = HttpUtility.UrlEncode(c.ToString(), Encoding.UTF8);
                if (encode.Length > 1 || c.Equals(' '))
                {
                    builder.Append(encode.ToUpper());
                }
                else
                {
                    switch (encode)
                    {
                        case "(":
                            builder.Append("%28");
                            break;
                        case ")":
                            builder.Append("%29");
                            break;
                        default:
                            builder.Append(c);
                            break;
                    }

                }
            }
            return builder.ToString();
        }

        private static string MD5Encrypt(string str)
        {
            MD5 md5 = MD5.Create();
            byte[] bs = Encoding.UTF8.GetBytes(str);
            byte[] hs = md5.ComputeHash(bs);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hs)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 获取时间戳，精确到秒
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        private static string EncodeBase64(string source)
        {
            string encode = string.Empty;
            byte[] bytes = Encoding.UTF8.GetBytes(source);
            try
            {
                encode = Convert.ToBase64String(bytes);
            }
            catch
            {
            }
            return encode;
        }
    }
}
