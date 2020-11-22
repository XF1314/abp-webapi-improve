using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.Attributes;
using WebApiClient.Contexts;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr
{
    public class PeopleSoftHrParamsFilter : ApiActionFilterAttribute
    {
        private readonly Lazy<IConfiguration> _configuration;
        private readonly Lazy<ILoggerFactory> _loggerFactory;

        public PeopleSoftHrParamsFilter(Lazy<ILoggerFactory> loggerFactory, Lazy<IConfiguration> configuration)
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
                else if (apiActionContext.ApiActionDescriptor.Parameters.Count == 1
                         && apiActionContext.ApiActionDescriptor.Parameters[0].Value is ISecret)
                {
                    if (apiActionContext.ApiActionDescriptor.Parameters[0].Value is IAppIdInfo)
                    {
                        var appIdInfo = apiActionContext.ApiActionDescriptor.Parameters[0].Value as IAppIdInfo;
                        if (string.IsNullOrWhiteSpace(appIdInfo.AppId))
                            appIdInfo.AppId = _configuration.Value[ThirdpartySettingNames.PsWebApiAppId];
                        var appPasswordInfo = apiActionContext.ApiActionDescriptor.Parameters[0].Value as ISecret;
                        if (string.IsNullOrWhiteSpace(appPasswordInfo.Secret))
                            appPasswordInfo.Secret = _configuration.Value[ThirdpartySettingNames.PsWebApiAppSecret];

                        await FullfillSignatureInfo(apiActionContext, apiPath);
                    }
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
            var psWebApiAppId = _configuration.Value[ThirdpartySettingNames.PsWebApiAppId];
            var psWebApiAppPassword = _configuration.Value[ThirdpartySettingNames.PsWebApiAppSecret];

            var messageContent = apiActionContext.RequestMessage.Content;
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
                    keyValuePairs.ToList().ForEach(x => @params.Add(x.Key, x.Value));

                    var sign = psWebApiAppId.Md5Digest();
                    @params.Add(nameof(ISignatureBasedRequest.Sign), sign);
                    var formContent = await WebApiClientUrlEncodedContent.FromHttpContentAsync(null, false);

                    await formContent.AddFormFieldAsync(@params);

                    apiActionContext.RequestMessage.Headers.Add("Accept-Encoding", "gzip,deflate");
                    apiActionContext.RequestMessage.Content.Dispose();
                    apiActionContext.RequestMessage.Content = formContent;
                }
                else if (contentType.Contains(WebApiClientConsts.MultiPartFormContentMediaType))
                {
                    var keyValueFormatter = apiActionContext.HttpApiConfig.KeyValueFormatter;
                    var options = apiActionContext.HttpApiConfig.FormatOptions;
                    var keyValuePairs = keyValueFormatter.Serialize(apiActionContext.ApiActionDescriptor.Parameters[0], options);
                    keyValuePairs.ToList().ForEach(x => @params.Add(x.Key, x.Value));

                    var sign = psWebApiAppId.Md5Digest();
                    @params.Add(nameof(ISignatureBasedRequest.Sign), sign);
                    var multipartFormContent = new WebApiClientMultipartFormContent();
                    foreach (var param in @params.OrderBy(t => t.Key))
                        multipartFormContent.Add(new WebApiClientMultipartTextContent(param.Key, param.Value));

                    apiActionContext.RequestMessage.Headers.Add("Accept-Encoding", "gzip,deflate");

                    apiActionContext.RequestMessage.Content.Dispose();
                    apiActionContext.RequestMessage.Content = multipartFormContent;
                }
                else if (contentType.Contains(WebApiClientConsts.JsonContentMediaType))//"application/json; charset=utf-8"
                {
                    var jsonFormatter = apiActionContext.HttpApiConfig.JsonFormatter;
                    var options = apiActionContext.HttpApiConfig.FormatOptions;
                    //不使用驼峰，确保传输字段的正确性
                    options.UseCamelCase = false;
                    var jsonString = jsonFormatter.Serialize(apiActionContext.ApiActionDescriptor.Parameters[0].Value, options);
                    var jObject = JObject.Parse(jsonString);

                    //var sortedDictionary = jObject.ConvertToSortedDictionary();
                    //if (sortedDictionary != null && sortedDictionary.Any())
                    //    foreach (var keyValuePair in sortedDictionary)
                    //    {
                    //        @params.Add(keyValuePair.Key, keyValuePair.Value);
                    //    }

                    //var sign = psWebApiAppId.Md5Digest();
                    //jObject.Add(nameof(ISignatureBasedRequest.Sign), sign);

                    apiActionContext.RequestMessage.Headers.Add("User-Agent", "Mo");

                    apiActionContext.RequestMessage.Headers.Add("Accept-Encoding", "gzip,deflate");

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

                var sign = psWebApiAppId.Md5Digest();
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

                uriEditor.AddQuery(nameof(ISignatureBasedRequest.Sign), sign);

                apiActionContext.RequestMessage.RequestUri = uriEditor.Uri;
            }
        }

    }
}
