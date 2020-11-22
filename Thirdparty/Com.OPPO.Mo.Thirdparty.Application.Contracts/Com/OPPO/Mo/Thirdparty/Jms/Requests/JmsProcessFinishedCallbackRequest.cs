using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Jms.Requests
{
    /// <summary>
    /// 流程结束时回调Jms request
    /// </summary>
    public class JmsProcessFinishedCallbackRequest : BaseJmsRequest
    {
        /// <summary>
        /// 【必填项】<see cref="Mo2JmsApprovalInfo"/>
        /// </summary>
        [JsonProperty("mo_info")]
        public Mo2JmsApprovalInfo ApprovalInfo { get; set; }

    }

    /// <summary>
    /// Mo传递给Jms的审批信息
    /// </summary>
    public class Mo2JmsApprovalInfo
    {
        /// <summary>
        /// 【必填项】流程实例编码
        /// </summary>
        [JsonProperty("mo_id")]
        public string ProcessInstanceCode { get; set; }

        /// <summary>
        /// 【必填项】<see cref="Mo2JmsApprovalStatus"/>
        /// </summary>
        [JsonProperty("status")]
        public Mo2JmsApprovalStatus ApprovalStatus { get; set; }

    }

    /// <summary>
    /// Mo传递给Jms的审批状态
    /// </summary>
    public enum Mo2JmsApprovalStatus
    {
        /// <summary>
        /// 拒绝
        /// </summary>
        reject = 0,

        /// <summary>
        /// 通过
        /// </summary>
        pass = 1

    }

}
