using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Dtos
{

    public class SubJobFunctionDto
    {
        /// <summary>
        /// 通道代码
        /// </summary>
        [JsonProperty("hhrJobFunction")]
        public string JobFunction { get; set; }
        /// <summary>
        /// 领域代码
        /// </summary>
        [JsonProperty("hhrSubJobFunc")]
        public string SubJobFunc { get; set; }
        /// <summary>
        /// 领域描述
        /// </summary>
        [JsonProperty("hhrSubJobFuncDescr")]
        public string SubJobFuncDescr { get; set; }
    }
}
