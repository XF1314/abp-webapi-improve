using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Request
{
    public class PositionInformationQuery
    {
        /// <summary>
        /// 集合ID,非必填
        /// </summary>
        [JsonProperty("hhrSetId")]
        public string SetId { get; set; }

        /// <summary>
        /// 通道,非必填
        /// </summary>
        [JsonProperty("hhrJobFunction")]
        public string JobFunction { get; set; }

        /// <summary>
        /// 专业领域,非必填
        /// </summary>
        [JsonProperty("hhrJobSubFunc")]
        public string JobSubFunc { get; set; }

        /// <summary>
        /// 职族,非必填
        /// </summary>
        [JsonProperty("hhrClanId")]
        public string ClanId { get; set; }
    }
}
