using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Dtos
{
    public class JobRankListResponseDto
    {
        /// <summary>
        /// 行数
        /// </summary>
        [JsonProperty("totalRows")] 
        public int TotalRows { get; set; }

        /// <summary>
        /// 返回的职务职级数据
        /// </summary>
        [JsonProperty("levels")] 
        public List<JobRankDto> Datas { get; set; }
    }

    public class JobRankDto
    {
        /// <summary>
        /// 集合ID
        /// </summary>
        [JsonProperty("hhrSetId")]
        public string SetId { get; set; }
        /// <summary>
        /// 岗位代码
        /// </summary>
        [JsonProperty("hhrJobCode")]
        public string JobCode { get; set; }
        /// <summary>
        /// 岗位描述
        /// </summary>
        [JsonProperty("hhrJobCodeDescr")]
        public string JobDescription { get; set; }
        /// <summary>
        /// 通道
        /// </summary>
        [JsonProperty("hhrSupvLvlId")]
        public string JobLevelCode { get; set; }
        /// <summary>
        /// 通道描述
        /// </summary>
        [JsonProperty("hhrSupvLvlDescr")]
        public string JobLevelDescription { get; set; }
    }
}
