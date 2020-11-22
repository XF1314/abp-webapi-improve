using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;
using WebApiClient.Contexts;

namespace Com.OPPO.Mo
{
    public class WebApiClientComposeReturnAttribute : ApiReturnAttribute
    {
        protected override void ConfigureAccept(HttpHeaderValueCollection<MediaTypeWithQualityHeaderValue> accept)
        {
            accept.Add(new MediaTypeWithQualityHeaderValue(WebApiClientJsonContent.MediaType, 0.9d));
            accept.Add(new MediaTypeWithQualityHeaderValue(WebApiClientXmlContent.MediaType, 0.8d));
            accept.Add(new MediaTypeWithQualityHeaderValue("*/*", 0.1d));
        }

        protected override async Task<object> GetTaskResult(ApiActionContext context)
        {
            var response = context.ResponseMessage;
            var dataType = context.ApiActionDescriptor.Return.DataType;

            if (dataType.IsHttpResponseMessage == true)
            {
                return response;
            }

            if (dataType.IsString == true)
            {
                return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }

            if (dataType.IsByteArray == true)
            {
                return await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
            }

            if (dataType.IsStream == true)
            {
                return await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
            }

            if (dataType.IsHttpResponseWrapper == true)
            {
                return dataType.HttpResponseWrapperFactory.Invoke(response);
            }

            var contentType = new WebApiClientContentType(response.Content.Headers.ContentType);
            if (contentType.IsApplicationJson() == true)
            {
                var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                while (json.StartsWith("{{") && json.EndsWith("}}"))
                    json.Substring(1, json.Length - 2);

                return context.HttpApiConfig.JsonFormatter.Deserialize(json, dataType.Type);
            }

            if (contentType.IsApplicationXml() == true)
            {
                var xml = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return context.HttpApiConfig.XmlFormatter.Deserialize(xml, dataType.Type);
            }

            throw new ApiReturnNotSupportedExteption(response, dataType.Type);
        }
    }
}
