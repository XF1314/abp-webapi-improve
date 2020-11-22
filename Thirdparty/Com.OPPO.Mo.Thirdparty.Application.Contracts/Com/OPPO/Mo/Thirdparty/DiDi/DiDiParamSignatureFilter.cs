using Com.OPPO.Mo.Thirdparty.DiDi.Requests;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.Attributes;
using WebApiClient.Contexts;

namespace Com.OPPO.Mo.Thirdparty.DiDi
{
    public class DiDiParamSignatureFilter : ApiActionFilterAttribute
    {
        private readonly Lazy<IConfiguration> _configuration;
        private readonly Lazy<ILoggerFactory> _loggerFactory;

        public DiDiParamSignatureFilter(Lazy<ILoggerFactory> loggerFactory, Lazy<IConfiguration> configuration)
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
                else if (apiActionContext.ApiActionDescriptor.Parameters.Count == 1) //&& apiActionContext.ApiActionDescriptor.Parameters[0].Value is ISignatureBasedRequest
                {
                    if (apiActionContext.ApiActionDescriptor.Parameters[0].Value is IAppIdInfo)
                    {
                        var appIdInfo = apiActionContext.ApiActionDescriptor.Parameters[0].Value as IAppIdInfo;
                        if (string.IsNullOrWhiteSpace(appIdInfo.AppId))
                        {
                            appIdInfo.AppId = _configuration.Value[ThirdpartySettingNames.DiDiXiaoJukejiAppId];
                        }

                        var appSecret = apiActionContext.ApiActionDescriptor.Parameters[0].Value as IAppSecret;
                        if (appSecret != null)
                        {
                            if (string.IsNullOrWhiteSpace(appSecret.AppSecret))
                            {
                                appSecret.AppSecret = _configuration.Value[ThirdpartySettingNames.DiDiXiaoJukejiAppSecret];
                            }
                        }

                        var company = apiActionContext.ApiActionDescriptor.Parameters[0].Value as ICompanyId;
                        if (company != null)
                        {
                            if (string.IsNullOrWhiteSpace(company.CompanyId))
                            {
                                company.CompanyId = _configuration.Value[ThirdpartySettingNames.DiDiXiaoJukejiCompanyId];
                            }
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
            var @params = new Dictionary<string, object>();

            //var appId = _configuration.Value[ThirdpartySettingNames.DiDiXiaoJukejiAppId];
            var signKey = _configuration.Value[ThirdpartySettingNames.DiDiXiaoJukejiSignKey];
            //var companyId = _configuration.Value[ThirdpartySettingNames.DiDiXiaoJukejiCompanyId];
            var appSecret = _configuration.Value[ThirdpartySettingNames.DiDiXiaoJukejiAppSecret];

            var messageContent = apiActionContext.RequestMessage.Content;
            if (messageContent != null)
            {
                var contentType = apiActionContext.RequestMessage.Content.Headers.GetValues("Content-Type").FirstOrDefault();
                if (string.IsNullOrEmpty(contentType))
                    throw new Exception("请求参数类型不能为空。");
                else if (contentType == WebApiClientConsts.FormUrlEncodeContentMediaType)
                {
                    //var keyValueFormatter = apiActionContext.HttpApiConfig.KeyValueFormatter;
                    //var options = apiActionContext.HttpApiConfig.FormatOptions;
                    //var keyValuePairs = keyValueFormatter.Serialize(apiActionContext.ApiActionDescriptor.Parameters[0], options);
                    //keyValuePairs.ToList().ForEach(x => @params.Add(x.Key, x.Value));

                    //var sign = GetSignDidi(@params, signKey);
                    //@params.Add(ThirdpartyConsts.DiDiOpenApiSignParameterName, sign);
                    //var formContent = await WebApiClientUrlEncodedContent.FromHttpContentAsync(null, false);

                    //await formContent.AddFormFieldAsync(@params);
                    //apiActionContext.RequestMessage.Content.Dispose();
                    //apiActionContext.RequestMessage.Content = formContent;
                }
                else if (contentType.Contains(WebApiClientConsts.MultiPartFormContentMediaType))
                {
                    //var keyValueFormatter = apiActionContext.HttpApiConfig.KeyValueFormatter;
                    //var options = apiActionContext.HttpApiConfig.FormatOptions;
                    //var keyValuePairs = keyValueFormatter.Serialize(apiActionContext.ApiActionDescriptor.Parameters[0], options);
                    //keyValuePairs.ToList().ForEach(x => @params.Add(x.Key, x.Value));

                    //var sign = GetOnePlusSignDidCreate(@params, apiPath, signKey);
                    //@params.Add(ThirdpartyConsts.DiDiOpenApiSignParameterName, sign);
                    //var multipartFormContent = new WebApiClientMultipartFormContent();
                    //foreach (var param in @params.OrderBy(t => t.Key))
                    //    multipartFormContent.Add(new WebApiClientMultipartTextContent(param.Key, param.Value));

                    //apiActionContext.RequestMessage.Content.Dispose();
                    //apiActionContext.RequestMessage.Content = multipartFormContent;
                }
                else if (contentType.Contains(WebApiClientConsts.JsonContentMediaType))//"application/json; charset=utf-8"
                {
                    var jsonFormatter = apiActionContext.HttpApiConfig.JsonFormatter;

                    var options = apiActionContext.HttpApiConfig.FormatOptions;

                    var jsonString = jsonFormatter.Serialize(apiActionContext.ApiActionDescriptor.Parameters[0].Value, options);

                    if (apiPath.Contains("/river/Approval/create"))
                    {
                        var createInfo = JsonConvert.DeserializeObject<DiDiCreateRequest>(jsonString);

                        var travelDetailInfo = JsonConvert.SerializeObject(createInfo.TravelDetail);

                        var timestamp = GetTimeStamp(DateTime.Now);

                        createInfo.DateTime = timestamp;

                        @params.Add("client_id", createInfo.AppId);
                        @params.Add("access_token", createInfo.Token);
                        @params.Add("timestamp", timestamp);
                        @params.Add("company_id", createInfo.CompanyId);
                        @params.Add("phone", createInfo.Phone);
                        @params.Add("regulation_id", createInfo.RegulationId);
                        @params.Add("approval_type", createInfo.ApprovalType.ToString());
                        @params.Add("travel_detail", createInfo.TravelDetail);

                        var sign = GetSignDidi(@params, signKey);

                        createInfo.Sign = sign;

                        IsoDateTimeConverter dtConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm':'ss" };

                        var createJsonStr = JsonConvert.SerializeObject(createInfo, dtConverter);

                        apiActionContext.RequestMessage.Content.Dispose();

                        apiActionContext.RequestMessage.Content = new WebApiClientJsonContent(createJsonStr, Encoding.UTF8);

                    }
                    else
                    {
                        JObject jObject = JObject.Parse(jsonString);

                        var sortedDictionary = jObject.ConvertToSortedDictionary();

                        if (sortedDictionary != null && sortedDictionary.Any())
                        {
                            foreach (var keyValuePair in sortedDictionary)
                            {
                                @params.Add(keyValuePair.Key, keyValuePair.Value);
                            }
                        }

                        var sign = GetSignDidi(@params, signKey);

                        jObject.Add(ThirdpartyConsts.DiDiOpenApiSignParameterName, sign);

                        apiActionContext.RequestMessage.Content.Dispose();

                        apiActionContext.RequestMessage.Content = new WebApiClientJsonContent(jObject.ToString(), Encoding.UTF8);
                    }
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

                var sign = GetSignDidi(@params, signKey);
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

                uriEditor.AddQuery(ThirdpartyConsts.DiDiOpenApiSignParameterName, sign);
                apiActionContext.RequestMessage.RequestUri = uriEditor.Uri;
            }
        }

        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="secret"></param>
        /// <returns></returns>
        private static string GetSignDidi(IDictionary<string, object> parameters, string secret)
        {
            var builder = new StringBuilder();

            Dictionary<string, object> dic = new Dictionary<string, object>(parameters);

            dic.Add("sign_key", secret);

            var dicS = dic.OrderBy(t => t.Key).ToList();

            foreach (var param in dicS)
            {
                if (param.Key == "travel_detail")
                {
                    TravelDetailInfo detail = JsonConvert.DeserializeObject<TravelDetailInfo>(dic["travel_detail"].ToString()); //dic["travel_detail"] as TravelDetailInfo;

                    string traveldetail = JsonConvert.SerializeObject(parameters["travel_detail"]);
                    foreach (var item in detail.Trips)
                    {
                        traveldetail = traveldetail.Replace(item.DepartureCity, EnUnicode(item.DepartureCity));
                        traveldetail = traveldetail.Replace(item.DestinationCity, EnUnicode(item.DestinationCity));
                    }
                    builder.Append(string.Format("{0}={1}&", param.Key, traveldetail));
                }
                else
                {
                    builder.Append(string.Format("{0}={1}&", param.Key, param.Value));
                }                
            }
            return builder.ToString().TrimEnd('&').Md5Digest().ToLower();
        }

        private static string EnUnicode(string str)
        {
            StringBuilder strResult = new StringBuilder();
            if (!string.IsNullOrEmpty(str))
            {
                for (int i = 0; i < str.Length; i++)
                {
                    strResult.Append("\\u");
                    strResult.Append(((int)str[i]).ToString("x"));
                }
            }
            return strResult.ToString();
        }

        /// <summary>
        /// 获取一加滴滴创建审批单签名
        /// </summary>
        /// <param name="parameters">参数</param>
        /// <param name="apiPath">地址</param>
        /// <param name="secret">秘钥</param>
        /// <returns></returns>
        private static string GetOnePlusSignDidCreate(IDictionary<string, string> parameters, string apiPath, string secret)
        {
            var builder = new StringBuilder();
            Dictionary<string, string> dic = new Dictionary<string, string>(parameters)
            {
                { "client_id", secret }
            };
            foreach (var param in dic.OrderBy(t => t.Key))
            {
                if (param.Key == "travel_detail")
                {
                    //var  detail = dic["travel_detail"] as TravelDetailInfo;

                    //string traveldetail = JsonConvert.SerializeObject(dic["travel_detail"]);
                    //foreach (var item in detail.trips)
                    //{
                    //    traveldetail = traveldetail.Replace(item.departure_city, EnUnicode(item.departure_city));
                    //    traveldetail = traveldetail.Replace(item.destination_city, EnUnicode(item.destination_city));
                    //}
                    //builder.Append(string.Format("{0}={1}&", param.Key, traveldetail));
                }
                else
                {
                    builder.Append(string.Format("{0}={1}&", param.Key, param.Value));
                }
            }

            return builder.ToString().TrimEnd('&').ToLower().Md5Digest();
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

        private static string GetTimeStamp(DateTime time)
        {
            var timestamp = (time.ToUniversalTime().Ticks - 621355968000000000) / 10000000;

            return timestamp.ToString();
        }
    }
}
