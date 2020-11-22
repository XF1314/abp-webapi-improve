using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Request
{
    public class RankQuery
    {
        /// <summary>
        /// 集合ID
        /// </summary>
        [JsonProperty("hhrSetId")]
        public string SetId { get; set; }
    }
}
