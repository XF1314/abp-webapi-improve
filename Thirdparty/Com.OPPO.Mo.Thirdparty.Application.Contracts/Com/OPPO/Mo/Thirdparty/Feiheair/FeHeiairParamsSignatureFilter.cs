using Com.OPPO.Mo.Thirdparty.DataGrand.Requests;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.Attributes;
using WebApiClient.Contexts;

namespace Com.OPPO.Mo.Thirdparty.Feiheair
{
    public class FeHeiairParamsSignatureFilter : ApiActionFilterAttribute
    {
        private readonly Lazy<IConfiguration> _configuration;
        private readonly Lazy<ILoggerFactory> _loggerFactory;

        public FeHeiairParamsSignatureFilter(Lazy<ILoggerFactory> loggerFactory, Lazy<IConfiguration> configuration)
        {
            _loggerFactory = loggerFactory;
            _configuration = configuration;
        }

        public override int OrderIndex { get { return 0; } }

        public override async Task OnBeginRequestAsync(ApiActionContext apiActionContext)
        {
            try
            {
                apiActionContext.RequestMessage.Headers.Add("Accept", "application/json");
                var apiPath = apiActionContext.RequestMessage.RequestUri.AbsolutePath;
                if (apiActionContext.ApiActionDescriptor.Parameters.Count > 1)
                    throw new Exception("参数个数不能大于1。");
                else if (apiActionContext.ApiActionDescriptor.Parameters.Count == 1)
                {
                    if (apiActionContext.ApiActionDescriptor.Parameters[0].Value is ICompanyCode)
                    {
                        var company = apiActionContext.ApiActionDescriptor.Parameters[0].Value as ICompanyCode;

                        if (company != null)
                        {
                            if (string.IsNullOrWhiteSpace(company.CompanyCode))
                            {
                                company.CompanyCode = _configuration.Value[ThirdpartySettingNames.FeiheairCompanyId];
                            }
                        }
                    }

                    if (apiActionContext.ApiActionDescriptor.Parameters[0].Value is IPassword)
                    {
                        var userInfo = apiActionContext.ApiActionDescriptor.Parameters[0].Value as IPassword
;
                        if (userInfo != null)
                        {
                            if (string.IsNullOrWhiteSpace(userInfo.Password))
                            {
                                userInfo.Password = _configuration.Value[ThirdpartySettingNames.FeiheairAppSecret];
                            }
                        }
                    }

                    await FullfillSignatureInfo(apiActionContext, apiPath);
                }

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
            var feiheairSignKey = _configuration.Value[ThirdpartySettingNames.FeiheairAppSecret];
            var companyCode = _configuration.Value[ThirdpartySettingNames.FeiheairCompanyId];

            var messageContent = apiActionContext.RequestMessage.Content;

            var userCode = string.Empty;
            var key = string.Empty;

            if (messageContent != null)
            {
                var contentType = apiActionContext.RequestMessage.Content.Headers.GetValues("Content-Type").FirstOrDefault();
                if (string.IsNullOrEmpty(contentType))
                    throw new Exception("请求参数类型不能为空。");
                else if (contentType == WebApiClientConsts.FormUrlEncodeContentMediaType)
                {
                    var keyValueFormatter = apiActionContext.HttpApiConfig.KeyValueFormatter;
                    var options = apiActionContext.HttpApiConfig.FormatOptions;
                    var keyValuePairs = keyValueFormatter.Serialize(apiActionContext.ApiActionDescriptor.Parameters[0], options);
                    //keyValuePairs.ToList().ForEach(x => @params.Add(x.Key, x.Value));

                    foreach (var item in keyValuePairs)
                    {
                        if (item.Key != "key")
                        {
                            @params.Add(item.Key, item.Value);
                        }

                        if (item.Key.Contains("userCode"))
                        {
                            userCode = item.Value;
                        }

                        if (item.Key.Contains("key"))
                        {
                            key = item.Value;
                        }
                    }

                    string appSecret = GetMd5(companyCode + userCode + key);
                    @params.Add(ThirdpartyConsts.FeiHeairSignParameterName, appSecret);
                    var formContent = await WebApiClientUrlEncodedContent.FromHttpContentAsync(null, false);

                    await formContent.AddFormFieldAsync(@params);
                    apiActionContext.RequestMessage.Content.Dispose();
                    apiActionContext.RequestMessage.Content = formContent;
                }
                else if (contentType.Contains(WebApiClientConsts.MultiPartFormContentMediaType))
                {
                    var keyValueFormatter = apiActionContext.HttpApiConfig.KeyValueFormatter;
                    var options = apiActionContext.HttpApiConfig.FormatOptions;
                    var keyValuePairs = keyValueFormatter.Serialize(apiActionContext.ApiActionDescriptor.Parameters[0], options);
                    keyValuePairs.ToList().ForEach(x => @params.Add(x.Key, x.Value));

                    var sign = GetSignature(@params, apiPath, feiheairSignKey);
                    @params.Add(ThirdpartyConsts.FeiHeairSignParameterName, sign);
                    var multipartFormContent = new WebApiClientMultipartFormContent();
                    foreach (var param in @params.OrderBy(t => t.Key))
                        multipartFormContent.Add(new WebApiClientMultipartTextContent(param.Key, param.Value));

                    apiActionContext.RequestMessage.Content.Dispose();
                    apiActionContext.RequestMessage.Content = multipartFormContent;
                }
                else if (contentType.Contains(WebApiClientConsts.JsonContentMediaType))//"application/json; charset=utf-8"
                {
                    var jsonFormatter = apiActionContext.HttpApiConfig.JsonFormatter;
                    var options = apiActionContext.HttpApiConfig.FormatOptions;
                    var jsonString = jsonFormatter.Serialize(apiActionContext.ApiActionDescriptor.Parameters[0].Value, options);
                    var jObject = JObject.Parse(jsonString);

                    var sortedDictionary = jObject.ConvertToSortedDictionary();
                    //if (sortedDictionary != null && sortedDictionary.Any())
                    //{
                    //    foreach (var keyValuePair in sortedDictionary)
                    //    {
                    //        if (keyValuePair.Key != "key")
                    //        {
                    //            @params.Add(keyValuePair.Key, keyValuePair.Value);
                    //        }
                    //    }
                    //}

                    if (sortedDictionary.ContainsKey("userCode"))
                    {
                        userCode = sortedDictionary["userCode"];
                    }

                    if (sortedDictionary.ContainsKey("key"))
                    {
                        key = sortedDictionary["key"];
                    }
                    string appSecret = GetMd5(companyCode + userCode + key);

                    jObject.Add(ThirdpartyConsts.FeiHeairSignParameterName, appSecret);

                    jObject.Remove("key");


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

                //var sign = GetSignature(@params, apiPath, esbSignKey);
                var requestUri = apiActionContext.RequestMessage.RequestUri.OriginalString;

                requestUri = requestUri.Remove(requestUri.IndexOf('?'));

                var uriEditor = new UriEditor(new Uri(requestUri), Encoding.UTF8);

                foreach (var keyValuePair in keyValuePairs)
                {
                    if (uriEditor.Replace(keyValuePair.Key, keyValuePair.Value) == false)
                    {
                        uriEditor.AddQuery(keyValuePair.Key, keyValuePair.Value);
                    }

                    if (keyValuePair.Key == "userCode")
                    {
                        userCode = keyValuePair.Value;
                    }

                    if (keyValuePair.Key == "key")
                    {
                        key = keyValuePair.Value;
                    }
                }

                if (!apiPath.Contains("get_new_key.aspx"))
                {
                    string appSecret = GetMd5(companyCode + userCode + key);

                    uriEditor.AddQuery(ThirdpartyConsts.FeiHeairSignParameterName, appSecret);
                }

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

        /// <summary>
        /// 返回Md5
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        private static string GetMd5(string src)
        {
            var buffer = new StringBuilder();
            using (var md5 = MD5.Create())
            {
                var md5Bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(src));
                for (var i = 0; i < md5Bytes.Length; i++)
                {
                    var val = Convert.ToInt32(md5Bytes[i] & 0xff);
                    if (val < 16)
                    {
                        buffer.Append("0");
                    }
                    buffer.Append(string.Format("{0:X}", val));
                }
            }

            return buffer.ToString();
        }
    }
}
