using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Request
{
    public class JobRankListQuery
    {
        /// <summary>
        /// 集合ID,必填
        /// </summary>
        [JsonProperty("hhrSetId")]
        public string SetId { get; set; }

        /// <summary>
        /// 岗位代码,必填
        /// </summary>
        [JsonProperty("hhrJobCode")]
        public string JobCode { get; set; }
    }
}
