using Com.OPPO.Mo.Thirdparty.Erp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Mes.Requests
{
    public class MesCountryInfoQueryRequest: BaseEsbRespTypeRequest
    {
        [JsonProperty("country_code")]
        public string ConutryCode { get; set; }
        [JsonProperty("country_type")]
        public string CountryType { get; set; }

    }
}
