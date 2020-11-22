using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Com.OPPO.Mo
{
    public class WebApiClientXmlContent : StringContent
    {

        public static string MediaType => WebApiClientConsts.XmlContentMediaType;

        public WebApiClientXmlContent(string xml, Encoding encoding)
            : base(xml ?? string.Empty, encoding, MediaType)
        {
        }
    }
}
