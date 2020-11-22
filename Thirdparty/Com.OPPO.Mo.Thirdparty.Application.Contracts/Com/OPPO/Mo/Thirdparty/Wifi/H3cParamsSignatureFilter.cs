using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.Attributes;
using WebApiClient.Contexts;

namespace Com.OPPO.Mo.Thirdparty.Wifi
{
    public class H3cParamsSignatureFilter : ApiActionFilterAttribute
    {
        private readonly Lazy<IConfiguration> _configuration;
        private readonly Lazy<ILoggerFactory> _loggerFactory;

        public H3cParamsSignatureFilter(Lazy<ILoggerFactory> loggerFactory, Lazy<IConfiguration> configuration)
        {
            _loggerFactory = loggerFactory;
            _configuration = configuration;
        }

        public override int OrderIndex { get { return 0; } }

        public override async Task OnBeginRequestAsync(ApiActionContext apiActionContext)
        {
            try
            {
                var apiPath = apiActionContext.RequestMessage.RequestUri.AbsolutePath;
                if (apiActionContext.ApiActionDescriptor.Parameters.Count > 1)
                {
                    throw new Exception("参数个数不能大于1。");
                }
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
                if (contentType.Contains(WebApiClientConsts.FormUrlEncodeContentMediaType))
                {
                    var wifiApiAccount = _configuration.Value[ThirdpartySettingNames.WifiWebApiAcount];
                    var wifiApiPwd = _configuration.Value[ThirdpartySettingNames.WifiWebApiPwd].Replace("amp;", ""); //"Afdk3247sah&&-123!"
                    var doman = _configuration.Value[ThirdpartySettingNames.WifiWebApiImc]; // "iMC RESTful Web Services"; 

                    var keyValueFormatter = apiActionContext.HttpApiConfig.KeyValueFormatter;
                    var options = apiActionContext.HttpApiConfig.FormatOptions;
                    var keyValuePairs = keyValueFormatter.Serialize(apiActionContext.ApiActionDescriptor.Parameters[0], options);
                    keyValuePairs.ToList().ForEach(x => @params.Add(x.Key, x.Value));

                    //var sign = GetSignature(@params, apiPath, esbSignKey);
                    //@params.Add("sign", sign);

                    var formContent = await WebApiClientUrlEncodedContent.FromHttpContentAsync(null, false);

                    await formContent.AddFormFieldAsync(@params);

                    apiActionContext.HttpApiConfig.HttpHandler.Credentials = new NetworkCredential(wifiApiAccount, wifiApiPwd, doman);

                    apiActionContext.RequestMessage.Content.Dispose();
                    apiActionContext.RequestMessage.Content = formContent;
                }
                else if (contentType.Contains(WebApiClientConsts.JsonContentMediaType))
                {
                    var wifiApiAccount = _configuration.Value[ThirdpartySettingNames.WifiWebApiAcount];
                    var wifiApiPwd = _configuration.Value[ThirdpartySettingNames.WifiWebApiPwd].Replace("amp;", ""); //"Afdk3247sah&&-123!"
                    var doman = _configuration.Value[ThirdpartySettingNames.WifiWebApiImc]; // "iMC RESTful Web Services"; 

                    var jsonFormatter = apiActionContext.HttpApiConfig.JsonFormatter;
                    var options = apiActionContext.HttpApiConfig.FormatOptions;
                    var jsonString = jsonFormatter.Serialize(apiActionContext.ApiActionDescriptor.Parameters[0].Value, options);
                    var jObject = JObject.Parse(jsonString);

                    apiActionContext.HttpApiConfig.HttpHandler.Credentials = new NetworkCredential(wifiApiAccount, wifiApiPwd, doman);

                    apiActionContext.RequestMessage.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)");

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
                var wifiApiAccount = _configuration.Value[ThirdpartySettingNames.WifiWebApiAcount];
                var wifiApiPwd = _configuration.Value[ThirdpartySettingNames.WifiWebApiPwd].Replace("amp;", ""); //"Afdk3247sah&&-123!"
                var doman = _configuration.Value[ThirdpartySettingNames.WifiWebApiImc]; // "iMC RESTful Web Services"; 
                var keyValueFormatter = apiActionContext.HttpApiConfig.KeyValueFormatter;
                var options = apiActionContext.HttpApiConfig.FormatOptions;
                var keyValuePairs = keyValueFormatter.Serialize(apiActionContext.ApiActionDescriptor.Parameters[0], options);
                keyValuePairs.ToList().ForEach(x => @params.Add(x.Key, x.Value));

                //var sign = GetSignature(@params, apiPath, esbSignKey);
                var requestUri = apiActionContext.RequestMessage.RequestUri.OriginalString;
                //requestUri = requestUri.Remove(requestUri.IndexOf('?'));
                var uriEditor = new UriEditor(new Uri(requestUri), Encoding.UTF8);
                //foreach (var keyValuePair in keyValuePairs)
                //{
                //    if (uriEditor.Replace(keyValuePair.Key, keyValuePair.Value) == false)
                //    {
                //        uriEditor.AddQuery(keyValuePair.Key, keyValuePair.Value);
                //    }
                //}


                apiActionContext.HttpApiConfig.HttpHandler.Credentials = new NetworkCredential(wifiApiAccount, wifiApiPwd, doman);

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
    }
}
