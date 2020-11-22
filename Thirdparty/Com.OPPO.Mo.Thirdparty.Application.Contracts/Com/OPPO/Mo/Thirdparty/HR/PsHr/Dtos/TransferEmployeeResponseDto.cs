using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Dtos
{
    public class TransferEmployeeResponseDto
    {
        /// <summary>
        /// 绩效标识
        /// </summary>
        [JsonProperty("hhrRateFlag")]
        public string RateFlag { get; set; }


        /// <summary>
        /// 转正标识
        /// </summary>
        [JsonProperty("hhrProbationFlag")]
        public string ProbationFlag { get; set; }

        /// <summary>
        /// 职族
        /// </summary>
        [JsonProperty("hhrClanId")]
        public string ClanId { get; set; }
    }
}
