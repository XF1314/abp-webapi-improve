using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Com.OPPO.Mo
{
     public class UriEditor
    {
        private readonly string fragment;

        private readonly int pathIndex;

        private readonly int fragmentLength;

        private Uri uriValue;

        private bool uriCanReplace = false;

        public Uri Uri
        {
            get
            {
                return this.uriValue;
            }
            private set
            {
                this.uriValue = value;
                this.uriCanReplace = value.OriginalString.IndexOf('{') > -1;
            }
        }

        public Encoding Encoding { get; }

        public UriEditor(Uri uri)
            : this(uri, Encoding.UTF8)
        {
        }

        public UriEditor(Uri uri, Encoding encoding)
        {
            this.Uri = uri ?? throw new ArgumentNullException(nameof(uri));
            this.Encoding = encoding ?? throw new ArgumentNullException(nameof(encoding));
            if (uri.IsAbsoluteUri == false)
            {
                throw new UriFormatException($"{nameof(uri)}必须为绝对完整URI");
            }

            const int delimiterLength = 3;
            this.fragment = uri.Fragment;
            this.pathIndex = uri.AbsoluteUri.IndexOf('/', uri.Scheme.Length + delimiterLength);
            this.fragmentLength = string.IsNullOrEmpty(uri.Fragment) ? 0 : uri.Fragment.Length;
        }

        public bool Replace(string name, string value)
        {
            if (this.uriCanReplace == false)
            {
                return false;
            }

            var replaced = false;
            var regex = new Regex($"{{{name}}}", RegexOptions.IgnoreCase);
            var url = regex.Replace(this.Uri.OriginalString, m =>
            {
                replaced = true;
                return HttpUtility.UrlEncode(value, this.Encoding);
            });

            if (replaced == true)
            {
                this.Uri = new Uri(url);
            }
            return replaced;
        }

        public void AddQuery(string name, string value)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            name = HttpUtility.UrlEncode(name, this.Encoding);
            value = HttpUtility.UrlEncode(value, this.Encoding);

            var pathQuery = this.GetPathAndQuery();
            var concat = pathQuery.IndexOf('?') > -1 ? "&" : "?";
            var relativeUri = $"{pathQuery}{concat}{name}={value}{this.fragment}";

            this.Uri = new Uri(this.Uri, relativeUri);
        }

        public void AddJobNumber(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            value = HttpUtility.UrlEncode(value, this.Encoding);

            var pathQuery = this.GetPathAndQuery();

            var relativeUri = $"{pathQuery}\\{value}{this.fragment}";

            this.Uri = new Uri(this.Uri, relativeUri);
        }

        private string GetPathAndQuery()
        {
            var originalUri = this.Uri.OriginalString;
            var length = originalUri.Length - this.pathIndex - this.fragmentLength;
            if (length == 0)
            {
                return string.Empty;
            }
            return originalUri.Substring(this.pathIndex, length).TrimEnd('&', '?');
        }

        public override string ToString()
        {
            return this.Uri.ToString();
        }
    }
}
