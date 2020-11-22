using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.Public.Request
{

    public class OvertimePushRequest : BaseEsbRequest
    {
        /// <summary>
        /// 工时信息
        /// </summary>
        [JsonProperty("workhours")]
        public string Data { get; set; }
    }
}
