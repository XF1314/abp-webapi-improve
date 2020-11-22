using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PreEmploymentPlatform.Request
{
    public class GetEmployRequest: BaseEsbRequest
    {
        /// <summary>
        /// 用户名，必填
        /// </summary>
       [JsonProperty("fname")]
        public string Name { get; set; }
    }
}
