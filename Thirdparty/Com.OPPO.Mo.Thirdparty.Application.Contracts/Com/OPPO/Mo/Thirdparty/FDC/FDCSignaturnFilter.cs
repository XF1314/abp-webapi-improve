using Com.OPPO.Mo.Thirdparty.DataGrand.Requests;
using Com.OPPO.Mo.Thirdparty.Fdc.Common;
using Com.OPPO.Mo.Thirdparty.OTravel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.Attributes;
using WebApiClient.Contexts;

namespace Com.OPPO.Mo.Thirdparty
{
    public class FdcSignaturnFilter : ApiActionFilterAttribute
    {
        private readonly Lazy<IConfiguration> _configuration;
        private readonly Lazy<ILoggerFactory> _loggerFactory;

        public FdcSignaturnFilter(Lazy< ILoggerFactory>loggerFactory, Lazy<IConfiguration> configuration)
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
                else if (apiActionContext.ApiActionDescriptor.Parameters.Count == 1  )
                {
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
            var messageContent = apiActionContext.RequestMessage.Content;
            if (messageContent != null)
            {
                var contentType = apiActionContext.RequestMessage.Content.Headers.GetValues("Content-Type").FirstOrDefault();
                if (string.IsNullOrEmpty(contentType))
                    throw new Exception("请求参数类型不能为空。");
                else if (contentType.Contains(WebApiClientConsts.JsonContentMediaType))//"application/json; charset=utf-8"
                {
                    var jsonFormatter = apiActionContext.HttpApiConfig.JsonFormatter;
                    var options = apiActionContext.HttpApiConfig.FormatOptions;
                    options.UseCamelCase = false;
                    var jsonString = jsonFormatter.Serialize(apiActionContext.ApiActionDescriptor.Parameters[0].Value, options);
                    var jObject = JObject.Parse(jsonString);

                    JObject @object = new JObject();
                    var apiCode = jObject["ApiCode"].ToString();

                    //获取接口中配置的拓展字段
                    var charSet =ThirdpartySettingNames.FdcCharSet;
                    var format =ThirdpartySettingNames.FdcContentFormat;
                    var version = _configuration.Value[ThirdpartySettingNames.FdcWebApiAppVersion];
                    var appId = _configuration.Value[ThirdpartySettingNames.FdcWebApiAppId];
                    var custId = _configuration.Value[ThirdpartySettingNames.FdcWebApiAppCustId];
                    var signType = _configuration.Value[ThirdpartySettingNames.FdcWebApiAppSignType];
                    var userCode = _configuration.Value[ThirdpartySettingNames.FdcWebApiAppUserCode];
                    var sessionKey = _configuration.Value[ThirdpartySettingNames.FdcWebApiAppSessionKey];
                    //var apiCode = _configuration.Value[ThirdpartySettingNames.FdcWebApiAppApiCode];
                    var username = _configuration.Value[ThirdpartySettingNames.FdcWebApiAppUserName];
                    var password = _configuration.Value[ThirdpartySettingNames.FdcWebApiAppPassword];
                    string requestSerialNumber = userCode + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    if (requestSerialNumber != null && requestSerialNumber.Length > 64)
                        requestSerialNumber = requestSerialNumber.Substring(0, 64);
                    string encrypt = FinanceDESHelper.DESEncrypt(jObject.ToString(), username, password);
                    string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                    @object.Add("Format", format);
                    @object.Add("AppId", appId);
                    @object.Add("Version", version);
                    @object.Add("Charset", charSet);
                    @object.Add("BizContent", encrypt);
                    @object.Add("ReqSn", requestSerialNumber);
                    string signStr = "CusId=" + custId + "&ReqSn=" + requestSerialNumber + "&AppId=" + appId + "&ApiCode=" + apiCode + "&Format=" + format + "&Charset=" + charSet + "&SignType=" + signType + "&Timestamp=" + timestamp + "&Version=" + version + "&BizContent=" + encrypt + "&MD5Secret=" + sessionKey;
                    string sign = FinanceDESHelper.MD5Encrypt(signStr);
                    @object.Add("Sign", sign);
                    @object.Add("CusId", custId);
                    @object.Add("ApiCode", apiCode);
                    @object.Add("Timestamp", timestamp);
                    @object.Add("SignType", signType);

                    apiActionContext.RequestMessage.Content.Dispose();
                    apiActionContext.RequestMessage.Content = new WebApiClientJsonContent(@object.ToString(), Encoding.UTF8);

                    if (apiActionContext.HttpApiConfig.HttpHandler.AllowAutoRedirect != true)
                    {
                        apiActionContext.HttpApiConfig.HttpHandler.AllowAutoRedirect = true;
                    }
                    
                    apiActionContext.RequestMessage.Headers.Referrer = null;
                    if (apiActionContext.HttpApiConfig.HttpHandler.Credentials != CredentialCache.DefaultCredentials)
                    {
                        apiActionContext.HttpApiConfig.HttpHandler.Credentials = CredentialCache.DefaultCredentials;
                    }
                    
                    apiActionContext.RequestMessage.Headers.Add("Accept", "*/*");

                
                }
                else
                {
                    throw new Exception(string.Format("请求参数类型-{0}不被支持。", contentType));
                }
            }
        }        
    }
}
