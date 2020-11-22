using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PreEmploymentPlatform.Request
{
    /// <summary>
    /// 领用状态数据
    /// </summary>
    public class ReceiveStateRequest: BaseEsbRequest
    {
        /// <summary>
        /// 办公用具领用状态，必填
        /// 1表示办公用具领用
        /// 2表示电脑权限开通
        /// </summary>
        [JsonProperty("tag")] 
        public string Status { get; set; }

        /// <summary>
        /// 操作者ID，必填
        /// </summary>
        [JsonProperty("opt_id")]
        public string EmployId { get; set; }

        /// <summary>
        /// Mo编号，必填
        /// </summary>
        [JsonProperty("mo_number")]
        public string Number { get; set; }
    }
}
