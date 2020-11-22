using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo
{
     public class WebApiClientMultipartFormContent : MultipartContent//, ICustomTracable
    {
        private readonly string boundary;

        private readonly Lazy<MultipartContent> ellipsisFileMultipartContent;

        public static string MediaType => "multipart/form-data";

        public WebApiClientMultipartFormContent()
            : this(Guid16.NewGuid16().ToString())
        {
        }

        public WebApiClientMultipartFormContent(string boundary)
            : base("form-data", boundary)
        {
            this.boundary = boundary;
            this.ellipsisFileMultipartContent = new Lazy<MultipartContent>(this.CreateEllipsisFileMultipartContent, true);

            var parameter = new NameValueHeaderValue("boundary", boundary);
            this.Headers.ContentType.Parameters.Clear();
            this.Headers.ContentType.Parameters.Add(parameter);
        }

        //Task<string> ICustomTracable.ReadAsStringAsync()
        //{
        //    return this.ellipsisFileMultipartContent.Value.ReadAsStringAsync();
        //}

        private MultipartContent CreateEllipsisFileMultipartContent()
        {
            var multipartContent = new WebApiClientMultipartFormContent(this.boundary);
            foreach (var httpContent in this)
            {
                if (httpContent is WebApiClientMulitpartFileContent fileContent)
                {
                    multipartContent.Add(fileContent.ToEllipsisContent());
                }
                else
                {
                    multipartContent.Add(httpContent);
                }
            }
            return multipartContent;
        }

    }

    struct Guid16 : IComparable<Guid16>, IEquatable<Guid16>
    {
        private readonly long val;

        public static readonly Guid16 Empty = new Guid16(0);

        public Guid16(long val)
        {
            this.val = val;
        }

        public override string ToString()
        {
            return this.val.ToString("x16");
        }

        public long ToInt64()
        {
            return this.val;
        }

        public override int GetHashCode()
        {
            return this.val.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Guid16 other)
            {
                return this.Equals(other);
            }
            return false;
        }

        public bool Equals(Guid16 other)
        {
            return this.val.Equals(other.val);
        }

        public int CompareTo(Guid16 other)
        {
            return this.val.CompareTo(other.val);
        }


        public static Guid16 NewGuid16()
        {
            var val = Guid.NewGuid().ToByteArray().Aggregate<byte, long>(1, (current, b) => current * (b + 1));
            return new Guid16(val - DateTime.Now.Ticks);
        }

        public static Guid16 Parse(string g)
        {
            if (string.IsNullOrEmpty(g) == true)
            {
                throw new ArgumentNullException(nameof(g));
            }

            if (g.Length != 16)
            {
                throw new ArgumentException(nameof(g));
            }

            var val = Convert.ToInt64(g, 16);
            return new Guid16(val);
        }

        public static bool operator ==(Guid16 a, Guid16 b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Guid16 a, Guid16 b)
        {
            return a.Equals(b) == false;
        }
    }
}
