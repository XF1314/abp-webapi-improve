using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.Attributes;
using WebApiClient.Contexts;

namespace Com.OPPO.Mo.Thirdparty.Common.EmailSend
{

    public class EsbParamsSignatureToEmailFilter : ApiActionFilterAttribute
    {
        private readonly Lazy<IConfiguration> _configuration;
        private readonly Lazy<ILoggerFactory> _loggerFactory;

        public EsbParamsSignatureToEmailFilter(Lazy<ILoggerFactory> loggerFactory, Lazy<IConfiguration> configuration)
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
                    && apiActionContext.ApiActionDescriptor.Parameters[0].Value is ISignatureBasedRequest)
                {
                    if (apiActionContext.ApiActionDescriptor.Parameters[0].Value is IAppIdInfo)
                    {
                        var appIdInfo = apiActionContext.ApiActionDescriptor.Parameters[0].Value as IAppIdInfo;
                        if (string.IsNullOrWhiteSpace(appIdInfo.AppId))
                        {
                            appIdInfo.AppId = _configuration.Value[ThirdpartySettingNames.EsbAppId];
                        }

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
            var esbSignKey = _configuration.Value[ThirdpartySettingNames.EsbSignKey];
            var messageContent = apiActionContext.RequestMessage.Content;
            if (messageContent != null)
            {
                var contentType = apiActionContext.RequestMessage.Content.Headers.GetValues("Content-Type").FirstOrDefault();
                if (string.IsNullOrEmpty(contentType))
                    throw new Exception("请求参数类型不能为空。");
              
                else if (contentType.Contains(WebApiClientConsts.MultiPartFormContentMediaType))
                {
                    var keyValueFormatter = apiActionContext.HttpApiConfig.KeyValueFormatter;
                    var options = apiActionContext.HttpApiConfig.FormatOptions;
                    var keyValuePairs = keyValueFormatter.Serialize(apiActionContext.ApiActionDescriptor.Parameters[0], options);

                    foreach (var item in keyValuePairs.ToList())
                    {
                        if (!string.IsNullOrEmpty(item.Value)) @params.Add(item.Key, item.Value);
                    }

                    var sign = GetSignature(@params, apiPath, esbSignKey);
                    @params.Add(ThirdpartyConsts.EsbSignParameterName, sign);
                    var multipartFormContent = new WebApiClientMultipartFormContent();
                    foreach (var param in @params.OrderBy(t => t.Key))
                        multipartFormContent.Add(new WebApiClientMultipartTextContent(param.Key, param.Value));

                    apiActionContext.RequestMessage.Content.Dispose();
                    apiActionContext.RequestMessage.Content = multipartFormContent;
                }
                else
                {
                    throw new Exception(string.Format("请求参数类型-{0}不被支持。", contentType));
                }
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
