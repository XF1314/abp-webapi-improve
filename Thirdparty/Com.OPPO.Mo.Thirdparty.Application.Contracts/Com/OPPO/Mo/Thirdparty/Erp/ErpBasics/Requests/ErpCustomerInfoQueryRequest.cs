using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpBasics.Requests
{

    public class ErpCustomerInfoQueryRequest : BaseEsbLanguageRequest
    {
        [JsonProperty("account_number")]
        public string AccountNumber{ get; set; }
        [JsonProperty("ou_name")]
        public string AccountName { get; set; }

    }
}
