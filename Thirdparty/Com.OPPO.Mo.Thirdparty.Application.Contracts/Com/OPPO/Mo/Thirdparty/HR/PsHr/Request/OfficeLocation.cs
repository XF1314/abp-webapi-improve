using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Request
{

    public class OfficeLocation
    {
        /// <summary>
        /// 集合ID，非必填
        /// </summary>
        [JsonProperty("hhrSetId")]
        public string SetId { get; set; }

        /// <summary>
        /// 国家/地区代码，非必填
        /// </summary>
        [JsonProperty("hhrCountry")]
        public string CountryCode { get; set; }

        /// <summary>
        /// 办公城市代码，非必填
        /// </summary>
        [JsonProperty("hhrLocation")]
        public string LocationCode { get; set; }
    }
}
