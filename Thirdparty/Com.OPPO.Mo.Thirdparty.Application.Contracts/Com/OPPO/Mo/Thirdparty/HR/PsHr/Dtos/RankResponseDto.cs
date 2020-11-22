using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Dtos
{
    public class RankResponseDto
    {
        /// <summary>
        /// 集合ID
        /// </summary>
        [JsonProperty("hhrSetId")]
        public string SetId { get; set; }


        /// <summary>
        /// 职级代码
        /// </summary>
        [JsonProperty("hhrSupvLvlId")]
        public string RankCode { get; set; }

        /// <summary>
        ///  职级描述
        /// </summary>
        [JsonProperty("hhrSupvLvlDescr")]
        public string RankDescription { get; set; }


        /// <summary>
        ///  职级简单描述
        /// </summary>
        [JsonProperty("hhrSupvLvlShortDescr")]
        public string RankShortDescription { get; set; }


    }
}
