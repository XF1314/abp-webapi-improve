using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Com.OPPO.Mo
{
    public struct WebApiClientContentType
    {
        /// <summary>
        /// ContentType内容
        /// </summary>
        private readonly string contentType;

        /// <summary>
        /// 回复的ContentType
        /// </summary>
        /// <param name="contentType">ContentType内容</param>
        public WebApiClientContentType(MediaTypeHeaderValue contentType)
        {
            this.contentType = contentType?.MediaType;
        }

        /// <summary>
        /// 是否为某个Mime
        /// </summary>
        /// <param name="mediaType"></param>
        /// <returns></returns>
        public bool IsMediaType(string mediaType)
        {
            return this.contentType != null && this.contentType.StartsWith(mediaType, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// 是否为json
        /// </summary>
        /// <returns></returns>
        public bool IsApplicationJson()
        {
            return this.IsMediaType(WebApiClientJsonContent.MediaType) || this.IsMediaType("text/json");
        }

        /// <summary>
        /// 是否为xml
        /// </summary>
        /// <returns></returns>
        public bool IsApplicationXml()
        {
            return this.IsMediaType(WebApiClientXmlContent.MediaType) || this.IsMediaType("text/xml");
        }
    }
}
