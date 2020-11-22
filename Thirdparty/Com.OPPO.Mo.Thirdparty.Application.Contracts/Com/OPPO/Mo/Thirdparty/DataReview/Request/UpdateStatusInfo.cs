using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.DataReview.Request
{
    public class UpdateStatusInfo
    {
        /// <summary>
        /// 审批意见
        /// </summary>
        public string approvalOpinions { get; set; }
        /// <summary>
        /// 审批状态
        /// </summary>
        public int approvalStatus { get; set; }
        /// <summary>
        /// 审批时间
        /// </summary>
        public string approvalTime { get; set; }
        /// <summary>
        /// 审批人
        /// </summary>
        public string approvedBy { get; set; }
        /// <summary>
        /// 文件编号
        /// </summary>
        public string processInstanceCode { get; set; }
    }
}
