using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.Requests
{


    public class ErpSrmCheckBillInfoQueryRequest : BaseEsbLanguageRequest
    {
        [JsonProperty("organization_code")]
        public string OrganizationCode { get; set; }
        [JsonProperty("receipt_num")]
        public string ReceiptNumber { get; set; }
        [JsonProperty("segment1")]
        public string MaterialNumber { get; set; }


    }
}
