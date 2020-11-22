using Com.OPPO.Mo.Thirdparty.DataGrand.Requests;
using Com.OPPO.Mo.Thirdparty.Megvii.Common;
using Com.OPPO.Mo.Thirdparty.Megvii.Request;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.Attributes;
using WebApiClient.Contexts;

namespace Com.OPPO.Mo.Thirdparty.Megvii
{
    public class MegviiFilter : ApiActionFilterAttribute
    {
        private readonly Lazy<IConfiguration> _configuration;
        private readonly Lazy<ILoggerFactory> _loggerFactory;

        public MegviiFilter(Lazy<ILoggerFactory> loggerFactory, Lazy<IConfiguration> configuration)
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

                    var formContent = await WebApiClientUrlEncodedContent.FromHttpContentAsync(null, false);

                    await formContent.AddFormFieldAsync(@params);
                    apiActionContext.RequestMessage.Content.Dispose();
                    apiActionContext.RequestMessage.Content = formContent;

                    CookieContainer cc = new CookieContainer();
                    HttpPostWithCookieFace(ref cc);
                    if (apiActionContext.HttpApiConfig.HttpHandler.CookieContainer.Count == 0)
                    {
                        apiActionContext.HttpApiConfig.HttpHandler.CookieContainer = cc;
                    }
                    if (apiActionContext.HttpApiConfig.HttpHandler.AllowAutoRedirect == true)
                    {
                        apiActionContext.HttpApiConfig.HttpHandler.AllowAutoRedirect = false;
                    }
                }
                else if (contentType.Contains(WebApiClientConsts.MultiPartFormContentMediaType))
                {    
                    
                    AddPhotoRequest request = (AddPhotoRequest)apiActionContext.ApiActionDescriptor.Parameters[0].Value;
                    if (!string.IsNullOrEmpty(request.SubjectId))
                    {
                        apiActionContext.RequestMessage.AddMulitpartText("subject_id", request.SubjectId);
                    }
                    if (!string.IsNullOrEmpty(request.OldPhotoId))
                    {
                        apiActionContext.RequestMessage.AddMulitpartText("old_photo_id", request.OldPhotoId);
                    }
                    Stream fileStream = new MemoryStream(request.Photo);
                    apiActionContext.RequestMessage.AddMulitpartFile(fileStream, "photo", "123", "image/jpeg");

                    CookieContainer cc = new CookieContainer();
                    HttpPostWithCookieFace(ref cc);
                    if (apiActionContext.HttpApiConfig.HttpHandler.CookieContainer.Count==0)
                    {
                        apiActionContext.HttpApiConfig.HttpHandler.CookieContainer = cc;
                    }

                    if (apiActionContext.HttpApiConfig.HttpHandler.AllowAutoRedirect == true)
                    {
                        apiActionContext.HttpApiConfig.HttpHandler.AllowAutoRedirect = false;
                    }

                }
                else if (contentType.Contains(WebApiClientConsts.JsonContentMediaType))//"application/json; charset=utf-8"
                {
                    var jsonFormatter = apiActionContext.HttpApiConfig.JsonFormatter;
                    var options = apiActionContext.HttpApiConfig.FormatOptions;
                    var jsonString = jsonFormatter.Serialize(apiActionContext.ApiActionDescriptor.Parameters[0].Value, options);
                    var jObject = JObject.Parse(jsonString);

                    apiActionContext.RequestMessage.Headers.Add("User-Agent", DefaultUserAgent);
                    apiActionContext.RequestMessage.Headers.Add("ContentType", "application/json");

                    apiActionContext.RequestMessage.Content.Dispose();
                    apiActionContext.RequestMessage.Content = new WebApiClientJsonContent(jObject.ToString(), Encoding.UTF8);

                    CookieContainer cc = new CookieContainer();
                    HttpPostWithCookieFace(ref cc);
                    if (apiActionContext.HttpApiConfig.HttpHandler.CookieContainer.Count == 0)
                    {
                        apiActionContext.HttpApiConfig.HttpHandler.CookieContainer = cc;
                    }
                    apiActionContext.RequestMessage.Version = HttpVersion.Version10;

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

                var requestUri = apiActionContext.RequestMessage.RequestUri.OriginalString;
                requestUri = requestUri.Remove(requestUri.IndexOf('?'));
                var uriEditor = new UriEditor(new Uri(requestUri), Encoding.UTF8);


                foreach (var keyValuePair in keyValuePairs)
                {
                    if (keyValuePair.Value != null)
                    {
                        if (keyValuePair.Key == "jobNumber")
                        {
                            uriEditor.AddJobNumber(keyValuePair.Value);
                        }
                        else
                        {
                            uriEditor.AddQuery(keyValuePair.Key, keyValuePair.Value);
                        }

                    }
                }

                apiActionContext.RequestMessage.Headers.Add("ContentType", "text/html;charset=UTF-8");
                apiActionContext.RequestMessage.Headers.Add("User-Agent", DefaultUserAgent);

                apiActionContext.RequestMessage.RequestUri = uriEditor.Uri;

                CookieContainer cc = new CookieContainer();
                HttpPostWithCookieFace(ref cc);

                if (apiActionContext.HttpApiConfig.HttpHandler.CookieContainer.Count == 0)
                {
                    apiActionContext.HttpApiConfig.HttpHandler.CookieContainer = cc;
                }
                if (apiActionContext.HttpApiConfig.HttpHandler.AllowAutoRedirect == true)
                {
                    apiActionContext.HttpApiConfig.HttpHandler.AllowAutoRedirect = false;
                }
               
            }
        }

        private static readonly string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受     
        }


        public string HttpPostWithCookieFace(ref CookieContainer cookie)
        {
            string host = _configuration.Value[ThirdpartySettingNames.MegeviiWebApiHost];
            string userName = _configuration.Value[ThirdpartySettingNames.MegeviiWebApiAppUserName];
            string password = _configuration.Value[ThirdpartySettingNames.MegeviiWebApiAppPassword];

            string url = host + MegviiRoute.AuthLogin;
            string authLoginStr = "username=" + userName + "&password=" + password;

            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                Encoding charset = Encoding.GetEncoding("utf-8");

                //HTTPSQ请求  
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                request = WebRequest.Create(url) as HttpWebRequest;

                if (cookie.Count == 0)
                {
                    request.CookieContainer = new CookieContainer();
                    cookie = request.CookieContainer;
                }
                else
                {
                    request.CookieContainer = cookie;
                }
                request.ProtocolVersion = HttpVersion.Version10;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.UserAgent = "Koala Admin";
                request.Timeout = 5 * 60 * 1000;
                //如果需要POST数据     

                byte[] data = charset.GetBytes(authLoginStr);
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                response = request.GetResponse() as HttpWebResponse;
                cookie.Add(response.Cookies);
                Stream streamRet = response.GetResponseStream();   //获取响应的字符串流  
                StreamReader sr = new StreamReader(streamRet); //创建一个stream读取流  
                string ret = sr.ReadToEnd();
                response.Close();

                return ret;
            }
            catch (WebException ex)
            {
                HttpWebResponse res = (HttpWebResponse)ex.Response;
                StreamReader sr = new StreamReader(res.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
                string errorMessage = sr.ReadToEnd();
                return "";
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (response != null) response.Close();
                if (request != null) request.Abort();
            }
        }


    }



}
