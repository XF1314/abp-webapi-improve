using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Dtos
{

    public class JobFuncsDto
    {
        /// <summary>
        /// 通道代码
        /// </summary>
        [JsonProperty("hhrJobFunction")]
        public string JobFunction { get; set; }
        /// <summary>
        /// 通道描述
        /// </summary>
        [JsonProperty("hhrJobFuncDescr")]
        public string JobFuncDescr { get; set; }
    }
}
