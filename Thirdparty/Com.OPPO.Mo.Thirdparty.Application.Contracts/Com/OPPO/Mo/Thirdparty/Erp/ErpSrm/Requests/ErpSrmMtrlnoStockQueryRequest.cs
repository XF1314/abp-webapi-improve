﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.Requests
{


    public class ErpSrmMtrlnoStockQueryRequest : BaseEsbLanguageRequest
    {
        [JsonProperty("organization_code")]
        public string OrganizationCode { get; set; }

        [JsonProperty("segment1")]
        public string MaterialNumber { get; set; }


    }
}
