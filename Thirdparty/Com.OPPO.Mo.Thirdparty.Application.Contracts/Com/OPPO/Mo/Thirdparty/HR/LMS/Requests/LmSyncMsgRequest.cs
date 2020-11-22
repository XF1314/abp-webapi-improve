using Newtonsoft.Json;
using System;

namespace Com.OPPO.Mo.Thirdparty.Hr.LMS.Requests
{
    /// <summary>
    /// 离职同步审批信息
    /// </summary>
    public class LmSyncMsgRequest : BaseEsbRequest
    {
        /// <summary>
        /// 离职原因
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; set; }
        /// <summary>
        /// 驳回（转发）对象节点
        /// </summary>
        [JsonProperty("rejectTo")]
        public string RejectTo { get; set; }

        /// <summary>
        /// 竞业赔偿金
        /// </summary>
        [JsonProperty("damage")]
        public string Damage { get; set; }

        /// <summary>
        /// 是否启用竞业限制 1 启用 2 不启用
        /// </summary>
        [JsonProperty("workLimit")]
        public int WorkLimit { get; set; }

        /// <summary>
        /// 离职去向
        /// </summary>
        [JsonProperty("leaveDirect")]
        public string LeaveDirect { get; set; }

        /// <summary>
        /// 操作人工号
        /// </summary>
        [JsonProperty("operatorAccount")]
        public string OperatorAccount { get; set; }

        /// <summary>
        /// 工资
        /// </summary>
        [JsonProperty("salary")]
        public string Salary { get; set; }

        /// <summary>
        /// 操作人姓名
        /// </summary>
        [JsonProperty("operatorName")]
        public string OperatorName { get; set; }

        /// <summary>
        /// 是否安全审计
        /// </summary>
        [JsonProperty("security")]
        public int Security { get; set; }

        /// <summary>
        /// 审批状态 1同意 2拒绝/驳回 3转发
        /// </summary>
        [JsonProperty("tag")]
        public int Tag { get; set; }

        /// <summary>
        /// 享自由文件编号
        /// </summary>
        [JsonProperty("freeno")]
        public string Freeno { get; set; }

        /// <summary>
        /// 交接人
        /// </summary>
        [JsonProperty("handOver")]
        public string HandOver { get; set; }

        /// <summary>
        /// 绩效
        /// </summary>
        [JsonProperty("assess")]
        public string Assess { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonProperty("createTime")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 下一节点
        /// </summary>
        [JsonProperty("nextNode")]
        public string NextNode { get; set; }

        /// <summary>
        /// 离职原因
        /// </summary>
        [JsonProperty("leaveReason")]
        public string LeaveReason { get; set; }

        /// <summary>
        /// 申请单文件编号
        /// </summary>
        [JsonProperty("applyNo")]
        public string ApplyNo { get; set; }

        /// <summary>
        /// 离职日期
        /// </summary>
        [JsonProperty("leaveDate")]
        public DateTime LeaveDate { get; set; }

        /// <summary>
        /// 是否流程结束标记（0: 否, 1: 是）
        /// </summary>
        [JsonProperty("ended")]
        public int Ended { get; set; }

        /// <summary>
        /// 竞业月数
        /// </summary>
        [JsonProperty("limitMonth")]
        public int LimitMonth { get; set; }

        /// <summary>
        /// 当前节点ID
        /// </summary>
        [JsonProperty("nodeId")]
        public string NodeId { get; set; }

        /// <summary>
        /// 交接人电话
        /// </summary>
        [JsonProperty("handOverTel")]
        public string HandOverTel { get; set; }

        /// <summary>
        /// 是否敏感岗位（0: 否, 1: 是）
        /// </summary>
        [JsonProperty("sensitivePost")]
        public int SensitivePost { get; set; }

        /// <summary>
        /// 离职员工工号
        /// </summary>
        [JsonProperty("leaveStaffNo")]
        public string LeaveStaffNo { get; set; }

        /// <summary>
        /// mo当前节点审批链接
        /// </summary>
        [JsonProperty("moUrl")]
        public string MoUrl { get; set; }
    }

}
