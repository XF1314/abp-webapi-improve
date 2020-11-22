using Com.OPPO.Mo.Thirdparty.DataGrand.Requests;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.Attributes;
using WebApiClient.Contexts;

namespace Com.OPPO.Mo.Thirdparty
{
    public class AdapFilter : ApiActionFilterAttribute
    {
        private readonly Lazy<IConfiguration> _configuration;
        private readonly Lazy<ILoggerFactory> _loggerFactory;

        public AdapFilter(Lazy< ILoggerFactory>loggerFactory, Lazy<IConfiguration> configuration)
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
            var appId = _configuration.Value[ThirdpartySettingNames.AdapWebApiAppId];
            
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

                    //var sign = GetSignature(@params, apiPath, esbSignKey);
                    //@params.Add(ThirdpartyConsts.EsbSignParameterName, sign);
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

                    //var sign = GetSignature(@params, apiPath, esbSignKey);
                    //@params.Add(ThirdpartyConsts.EsbSignParameterName, sign);
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

                    //var sortedDictionary = jObject.ConvertToSortedDictionary();
                    //if (sortedDictionary != null && sortedDictionary.Any())
                    //    foreach (var keyValuePair in sortedDictionary)
                    //    {
                    //        @params.Add(keyValuePair.Key, keyValuePair.Value);
                    //    }
                    var loginHost = _configuration.Value[ThirdpartySettingNames.AdapWebApiAppLoginHost];
                    var tag = _configuration.Value[ThirdpartySettingNames.AdapWebApiAppTag];
                    var secret = _configuration.Value[ThirdpartySettingNames.AdapWebApiAppSecret];
                    var dict = new Dictionary<string, object>();
                    dict.Add("thirdAppTag", tag);
                    dict.Add("thirdAppSecret", secret);

                    var response = GetRefDataHttps(dict, loginHost);
                    JObject retJson = JObject.Parse(response);
                    if (retJson["code"].ToString() != "0")
                        throw new Exception(retJson["message"].ToString() + dict);
                    var authToken = retJson["payload"]["accessToken"].ToString();

                    apiActionContext.RequestMessage.Headers.Add("appid", appId);
                    apiActionContext.RequestMessage.Headers.Add("authtoken", authToken);

                    //var sign = GetSignature(@params, apiPath, esbSignKey);
                    //jObject.Add(ThirdpartyConsts.EsbSignParameterName, sign);
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
                requestUri =  requestUri.Remove(requestUri.IndexOf('?'));
                var uriEditor = new UriEditor(new Uri(requestUri), Encoding.UTF8);
                foreach (var keyValuePair in keyValuePairs)
                {
                    if (uriEditor.Replace(keyValuePair.Key, keyValuePair.Value) == false)
                    {
                        uriEditor.AddQuery(keyValuePair.Key, keyValuePair.Value);
                    }
                }

                //uriEditor.AddQuery(ThirdpartyConsts.EsbSignParameterName, sign);
                apiActionContext.RequestMessage.RequestUri = uriEditor.Uri;
            }
        }

        public static string GetRefDataHttps(IDictionary<string, object> dic, string apiUrl)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            string ret = "";
            try
            {
                Encoding encoding = Encoding.UTF8;
                //https 设置协议
                //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback((object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) =>
                //{
                //    return true; //总是接受  
                //});
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                request = (HttpWebRequest)WebRequest.Create(apiUrl);
                request.Method = "POST";
                //request.ContentType = "application/x-www-form-urlencoded";
                request.ContentType = "application/json;charset=UTF-8";
                var data = JsonConvert.SerializeObject(dic);
                byte[] buffer = encoding.GetBytes(data);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
                response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    ret = reader.ReadToEnd();
                    reader.Close();
                }
                return ret;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
        }



    }
}
