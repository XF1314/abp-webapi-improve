using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Request
{
    public class SubFunctionQuery
    {
        /// <summary>
        /// 通道代码
        /// </summary>
        [JsonProperty("hhrJobFunction")]
        public string JobFunction { get; set; }
    }
}
