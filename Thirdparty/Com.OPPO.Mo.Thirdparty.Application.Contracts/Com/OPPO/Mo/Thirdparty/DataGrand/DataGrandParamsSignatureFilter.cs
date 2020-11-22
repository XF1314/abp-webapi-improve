using Com.OPPO.Mo.Thirdparty;
using Com.OPPO.Mo.Thirdparty.DataGrand.Requests;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;
using WebApiClient.Contexts;

namespace Com.OPPO.Mo.Thirdparty.DataGrand
{
    /// <summary>
    /// 达观搜索签名Filter
    /// </summary>
    public class DataGrandParamsSignatureFilter : ApiActionFilterAttribute
    {
        private readonly Lazy<IConfiguration> _configuration;
        private readonly Lazy<ILoggerFactory> _loggerFactory;

        /// <summary>
        /// <see cref="DataGrandParamsSignatureFilter"/>
        /// </summary>
        public DataGrandParamsSignatureFilter(Lazy<IConfiguration> configuration, Lazy<ILoggerFactory> loggerFactory)
        {
            _loggerFactory = loggerFactory;
            _configuration = configuration;
        }

        /// <inheritdoc/>
        public override int OrderIndex { get { return 100; } }

        /// <summary>准备请求之前</summary>
        /// <param name="apiActionContext"><see cref="ApiActionContext"/></param>
        /// <returns></returns>
        public override async Task OnBeginRequestAsync(ApiActionContext apiActionContext)
        {
            try
            {
                apiActionContext.RequestMessage.Headers.Add("Accept", "application/json");
                var indexOfQuestionMark = apiActionContext.RequestMessage.RequestUri.AbsoluteUri.IndexOf('?');
                var apiPath = apiActionContext.RequestMessage.RequestUri.AbsolutePath;
                var dataGrandApiPath = apiPath;
                if (apiPath.StartsWith(ThirdpartyConsts.DataGrandDataSearchGatewayIdnentitifier))
                    dataGrandApiPath = apiPath.Substring(ThirdpartyConsts.DataGrandDataSearchGatewayIdnentitifier.Length);
                else if (dataGrandApiPath.StartsWith(ThirdpartyConsts.DataGrandDataUploadGatewayIdentitifier))
                    dataGrandApiPath = apiPath.Substring(ThirdpartyConsts.DataGrandDataUploadGatewayIdentitifier.Length);

                if (apiActionContext.ApiActionDescriptor.Parameters.Count > 1)
                    throw new Exception("参数个数不能大于1。");
                else if (apiActionContext.ApiActionDescriptor.Parameters.Count == 1
                    && apiActionContext.ApiActionDescriptor.Parameters[0].Value is ISignatureBasedDataGrandRequest)
                {
                    if (apiActionContext.ApiActionDescriptor.Parameters[0].Value is IAppIdInfo)
                    {
                        var appIdInfo = apiActionContext.ApiActionDescriptor.Parameters[0].Value as IAppIdInfo;
                        if (string.IsNullOrWhiteSpace(appIdInfo.AppId))
                            appIdInfo.AppId = _configuration.Value[ThirdpartySettingNames.DataGrandAppId];

                        await FullfillSignatureInfo(apiActionContext, dataGrandApiPath);
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

        private async Task FullfillSignatureInfo(ApiActionContext apiActionContext, string dataGrandApiPath)
        {
            var datagrandSignKey = _configuration.Value[ThirdpartySettingNames.DataGrandSignKey];
            var sortedParameters = new SortedDictionary<string, string>();
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
                    keyValuePairs.ToList().ForEach(x => sortedParameters.Add(x.Key, x.Value));

                    var sign = GetParamsSignature(sortedParameters, dataGrandApiPath, datagrandSignKey);
                    var formContent = await WebApiClientUrlEncodedContent.FromHttpContentAsync(apiActionContext.RequestMessage.Content);
                    await formContent.AddFormFieldAsync(new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>(ThirdpartyConsts.DataGrandSignParameterName, sign) });
                    apiActionContext.RequestMessage.Content.Dispose();
                    apiActionContext.RequestMessage.Content = formContent;
                }
                else if (contentType.Contains(WebApiClientConsts.MultiPartFormContentMediaType))
                {
                    var keyValueFormatter = apiActionContext.HttpApiConfig.KeyValueFormatter;
                    var options = apiActionContext.HttpApiConfig.FormatOptions;
                    var keyValuePairs = keyValueFormatter.Serialize(apiActionContext.ApiActionDescriptor.Parameters[0], options);
                    keyValuePairs.ToList().ForEach(x => sortedParameters.Add(x.Key, x.Value));

                    var sign = GetParamsSignature(sortedParameters, dataGrandApiPath, datagrandSignKey);
                    sortedParameters.Add(ThirdpartyConsts.DataGrandSignParameterName, sign);
                    var multipartFormContent = new WebApiClientMultipartFormContent();
                    foreach (var param in sortedParameters.OrderBy(t => t.Key))
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

                    sortedParameters = jObject.ConvertToSortedDictionary();
                    var sign = GetParamsSignature(sortedParameters, dataGrandApiPath, datagrandSignKey);
                    jObject.Add(ThirdpartyConsts.DataGrandSignParameterName, sign);
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
                keyValuePairs.ToList().ForEach(x => sortedParameters.Add(x.Key, x.Value));

                var sign = GetParamsSignature(sortedParameters, dataGrandApiPath, datagrandSignKey);
                apiActionContext.RequestMessage.AddUrlQuery(ThirdpartyConsts.DataGrandSignParameterName, sign);
                var requestUri = apiActionContext.RequestMessage.RequestUri.OriginalString;
                requestUri = requestUri.Remove(requestUri.IndexOf('?'));
                var uriEditor = new UriEditor(new Uri(requestUri), Encoding.UTF8);
                foreach (var keyValuePair in keyValuePairs)
                {
                    if (uriEditor.Replace(keyValuePair.Key, keyValuePair.Value) == false)
                        uriEditor.AddQuery(keyValuePair.Key, keyValuePair.Value);
                }

                uriEditor.AddQuery(ThirdpartyConsts.DataGrandSignParameterName, sign);
                apiActionContext.RequestMessage.RequestUri = uriEditor.Uri;
            }
        }

        private static string GetParamsSignature(SortedDictionary<string, string> sortedParameters, string apiPath, string signKey)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(apiPath);
            if (sortedParameters != null && sortedParameters.Any())
            {
                var formattedParams = sortedParameters
                    .Select(x => string.Format(@"{0}={1}", x.Key, x.Value))
                    .ToList();

                formattedParams.ForEach(y => stringBuilder.AppendFormat("{0}{1}", '\n', y));
            }
            stringBuilder.AppendFormat("{0}{1}", '\n', signKey);

            return stringBuilder.ToString().Md5Digest();
        }
    }
}
