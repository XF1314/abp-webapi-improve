using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Com.OPPO.Mo
{
    public class WebApiClientMultipartTextContent : StringContent
    {
        public WebApiClientMultipartTextContent(string name, string value)
            : base(value ?? string.Empty)
        {
            if (this.Headers.ContentDisposition == null)
            {
                var disposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = $"\"{name}\""
                };
                this.Headers.ContentDisposition = disposition;
            }
            this.Headers.Remove("Content-Type");
        }
    }
}