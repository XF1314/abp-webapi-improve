using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Com.OPPO.Mo
{
    public class WebApiClientMulitpartFileContent : StreamContent
    {
        public WebApiClientMulitpartFileContent(Stream stream, string name, string fileName, string contentType)
            : base(stream)
        {
            if (this.Headers.ContentDisposition == null)
            {
                var disposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = $"\"{name}\"",
                    FileName = $"\"{fileName}\""
                };
                this.Headers.ContentDisposition = disposition;
            }

            if (string.IsNullOrEmpty(contentType) == true)
            {
                contentType = "application/octet-stream";
            }
            this.Headers.ContentType = new MediaTypeHeaderValue(contentType);
        }

        public HttpContent ToEllipsisContent()
        {
            return new EllipsisContent(this);
        }

        private class EllipsisContent : ByteArrayContent
        {
            private static readonly byte[] ellipsisContent = new[] { (byte)'.', (byte)'.', (byte)'.' };

            public EllipsisContent(WebApiClientMulitpartFileContent fileContent)
                : base(ellipsisContent)
            {
                this.Headers.ContentDisposition = fileContent.Headers.ContentDisposition;
                this.Headers.ContentType = fileContent.Headers.ContentType;
            }
        }
    }
}
