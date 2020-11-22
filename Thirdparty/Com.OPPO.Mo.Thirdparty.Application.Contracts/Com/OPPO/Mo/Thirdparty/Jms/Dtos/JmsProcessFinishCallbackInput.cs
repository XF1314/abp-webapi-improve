using Com.OPPO.Mo.Thirdparty.Jms.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Jms.Dtos
{
    /// <summary>
    /// 跳板机流程实例结束回调 input
    /// </summary>
    public class JmsProcessFinishCallbackInput
    {
        /// <summary>
        /// 【必填项】流程实例编码
        /// </summary>
        [Required]
        public string ProcessInstanceCode { get; set; }

        /// <summary>
        /// 【必填项】<see cref="Mo2JmsApprovalStatus"/>
        /// </summary>
        [Required]
        public Mo2JmsApprovalStatus ApprovalStatus { get; set; }
    }
}
