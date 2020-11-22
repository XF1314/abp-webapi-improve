using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Dtos
{
    public class PositionInformationResponseDto
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
        /// 岗位简单描述
        /// </summary>
        [JsonProperty("hhrJobCodeShortDescr")]
        public string JobShortDescription { get; set; }
    }
}
