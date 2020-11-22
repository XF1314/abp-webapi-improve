using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Com.OPPO.Mo
{
    public class WebApiClientJsonContent : StringContent
    {
        public static string MediaType { get { return WebApiClientConsts.JsonContentMediaType; } }

        public WebApiClientJsonContent(string json, Encoding encoding)
            : base(json ?? string.Empty, encoding, MediaType)
        {
        }
    }
}
