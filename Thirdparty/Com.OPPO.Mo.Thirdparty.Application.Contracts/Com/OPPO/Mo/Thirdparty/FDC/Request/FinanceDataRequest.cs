using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Fdc.Request
{
    public class FinanceDataRequest
    {
        public string Format { get; set; } = "JSON";
        public string AppId { get; set; } = "00000001";
        public string Version { get; set; } = "1.0";
        public string Charset { get; set; } = "UTF8";
        public string BizContent { get; set; }
        public string ReqSn { get; set; } = "00000000_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
        public string CusId { get; set; } = "9900001";
        public string ApiCode { get; set; } = "FIELD_ATTRIBUTE";
        public string Timestamp { get; set; } = DateTime.Now.ToString("yyyyMMddHHmmss");
        public string SignType { get; set; } = "1";
        public string Sign { get; set; }


    }
}
