using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Com.OPPO.Mo
{
    public class WebApiClientUrlEncodedContent : HttpContent
    {
        private readonly MemoryStream stream = new MemoryStream();

        private static readonly Encoding defaultHttpEncoding = Encoding.GetEncoding(28591);

        public static string MediaType
        {
            get { return WebApiClientConsts.FormUrlEncodeContentMediaType; }
        }

        public WebApiClientUrlEncodedContent()
        {
            this.Headers.ContentType = new MediaTypeHeaderValue(MediaType);
        }

        public static async Task<WebApiClientUrlEncodedContent> FromHttpContentAsync(HttpContent httpContent, bool disposeHttpContent = true)
        {
            if (httpContent == null)
            {
                return new WebApiClientUrlEncodedContent();
            }

            WebApiClientUrlEncodedContent urlEncodedContent;
            if (httpContent is WebApiClientUrlEncodedContent)
            {
                return httpContent as WebApiClientUrlEncodedContent;
            }

            urlEncodedContent = new WebApiClientUrlEncodedContent();
            var byteArray = await httpContent.ReadAsByteArrayAsync().ConfigureAwait(false);
            await urlEncodedContent.AddByteArrayAsync(byteArray).ConfigureAwait(false);

            if (disposeHttpContent == true)
            {
                httpContent.Dispose();
            }
            return urlEncodedContent;
        }

        public async Task AddFormFieldAsync(IEnumerable<KeyValuePair<string, string>> keyValues)
        {
            if (keyValues == null)
            {
                return;
            }

            var form = new StringBuilder();
            foreach (var pair in keyValues)
            {
                if (form.Length > 0)
                {
                    form.Append('&');
                }
                form.Append(Encode(pair.Key));
                form.Append('=');
                form.Append(Encode(pair.Value));
            }

            await this.AddRawFormAsync(form.ToString()).ConfigureAwait(false);
        }

        public async Task AddRawFormAsync(string form)
        {
            if (string.IsNullOrEmpty(form) == true)
            {
                return;
            }

            var buffer = defaultHttpEncoding.GetBytes(form);
            await this.AddByteArrayAsync(buffer).ConfigureAwait(false);
        }

        private async Task AddByteArrayAsync(byte[] buffer)
        {
            if (buffer == null || buffer.Length == 0)
            {
                return;
            }

            if (this.stream.Length > 0)
            {
                this.stream.WriteByte((byte)'&');
            }
            await this.stream.WriteAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
        }

        private static string Encode(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            return HttpUtility.UrlEncode(value).Replace("%20", "+");
            //return Uri.EscapeDataString(value).Replace("%20", "+");
        }

        protected override bool TryComputeLength(out long length)
        {
            length = this.stream.Length;
            return true;
        }

        protected override Task<Stream> CreateContentReadStreamAsync()
        {
            var buffer = this.stream.ToArray();
            var readStream = new MemoryStream(buffer, 0, buffer.Length, writable: false);
            return Task.FromResult<Stream>(readStream);
        }

        protected override async Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            var position = this.stream.Position;
            this.stream.Position = 0;
            await this.stream.CopyToAsync(stream).ConfigureAwait(false);
            this.stream.Position = position;
        }

        protected override void Dispose(bool disposing)
        {
            this.stream.Dispose();
            base.Dispose(disposing);
        }
    }
}

