using System.Collections.Generic;

namespace Com.OPPO.Mo.Thirdparty.Hr.LMS.Requests
{
    /// <summary>
    /// 同步审批人变更请求信息
    /// </summary>
    public class LmsModifyApproveRequest
    {
        public LmsModifyApproveRequest()
        {
            ChangeList = new List<ChangeInfo>();
        }

        /// <summary>
        /// 流程单号
        /// </summary>
        public string ApplyNo { get; set; }

        /// <summary>
        /// 变更操作人工号
        /// </summary>
        public string SubmitUserNo { get; set; }

        /// <summary>
        /// 变更操作人姓名
        /// </summary>
        public string SubmitUsername { get; set; }

        /// <summary>
        /// 当前节点ID
        /// </summary>
        public string CurrentNodeId { get; set; }

        /// <summary>
        /// 离职员工工号
        /// </summary>
        public string LeaveStaffNo { get; set; }

        /// <summary>
        /// 变更信息
        /// </summary>
        public List<ChangeInfo> ChangeList { get; set; }
    }

    public class ChangeInfo
    {
        public ChangeInfo()
        {
            ApproveList = new List<ApproveInfo>();
        }
        /// <summary>
        /// 变更的节点ID
        /// </summary>
        public string NodeId { get; set; }

        /// <summary>
        /// 变更信息
        /// </summary>
        public List<ApproveInfo> ApproveList { get; set; }

    }

    public class ApproveInfo
    {
        /// <summary>
        /// 工号
        /// </summary>
        public string UserNo
        { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string UserName { get; set; }
    }
}
