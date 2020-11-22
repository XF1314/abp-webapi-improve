using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Contexts;
using Com.OPPO.Mo;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo
{
    public class MoWebApiClientLogFilter : IApiActionFilter, IAttributeMultiplable
    {
        private static readonly string tagKey = "$WebApiClientLogFilter";
        private readonly Lazy<ILoggerFactory> _loggerFactory;

        public MoWebApiClientLogFilter(Lazy<ILoggerFactory> loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public int OrderIndex => int.MaxValue - 1;

        public bool AllowMultiple => false;

        public async Task OnBeginRequestAsync(ApiActionContext apiActionContext)
        {
            //if (apiActionContext.RequestMessage.Content != null)
            //{
            //    var requestMessage = new WebApiClientRequestMessage { Time = DateTime.Now, Content = string.Empty };
            //    if (apiActionContext.RequestMessage.Content.Headers != null &&
            //        apiActionContext.RequestMessage.Content.Headers.ContentType == new MediaTypeHeaderValue("application/bson"))// 处理bson格式的请求体
            //    {
            //        var contentBuilder = new StringBuilder();
            //        foreach (var parameter in apiActionContext.ApiActionDescriptor.Parameters)
            //        {
            //            contentBuilder.AppendLine(string.Format("[{0}],", JsonConvert.SerializeObject(parameter.Value)));
            //        }

            //        contentBuilder.Remove(contentBuilder.Length - 1, 1);
            //        requestMessage.Content = contentBuilder.ToString();
            //    }
            //    else
            //    {
            //        requestMessage.Content = await apiActionContext.RequestMessage.GetRequestStringAsync().ConfigureAwait(false); // 只能读出文本格式数据
            //    }

            //    apiActionContext.Tags.Set(tagKey, requestMessage);
            //}

            await Task.CompletedTask;
        }

        public async Task OnEndRequestAsync(ApiActionContext context)
        {
            var loggerName = string.Format("{0}.{1}", context.ApiActionDescriptor.Member.DeclaringType.FullName, context.ApiActionDescriptor.Member.Name);
            var logger = _loggerFactory.Value.CreateLogger(loggerName);

            try
            {
                //var requestMessage = context.Tags.Get(tagKey).As<WebApiClientRequestMessage>();
                MediaTypeHeaderValue responseContentType = null;
                if (context.ResponseMessage != null && context.ResponseMessage.Content != null && context.ResponseMessage.Content.Headers != null)
                    responseContentType = context.ResponseMessage.Content.Headers.ContentType;


                var responseStatus = context.ResponseMessage?.StatusCode ?? System.Net.HttpStatusCode.GatewayTimeout;
                var responseBody = "";
                if (context.ResponseMessage?.Content != null)
                    responseBody = await context.ResponseMessage?.Content?.ReadAsStringAsync();

                var requestUri = context.RequestMessage.RequestUri ?? new Uri("");
                var requestString = await context.RequestMessage.GetRequestStringAsync().ConfigureAwait(false);
                var requestContent = string.IsNullOrEmpty(requestString) ? "无" : requestString;
                var requestInfo = string.Format("\r\n请求：{0}\r\n{1}\r\n响应码：{2}\r\n响应内容类型：{3}\r\n响应内容：{4}",
                    requestUri, requestContent, responseStatus, responseContentType is null ? string.Empty : responseContentType.ToString(), responseBody);

                if (context.Exception == null && (context.ResponseMessage != null && context.ResponseMessage.IsSuccessStatusCode))
                    logger.LogInformation(requestInfo);
                else
                {
                    logger.LogError(context.Exception, requestInfo);
                }
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
            }
        }
    }

}