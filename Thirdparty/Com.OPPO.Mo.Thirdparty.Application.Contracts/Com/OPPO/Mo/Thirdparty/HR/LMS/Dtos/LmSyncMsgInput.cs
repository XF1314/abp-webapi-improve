using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Com.OPPO.Mo.Thirdparty.Hr.LMS.Dtos
{
    /// <summary>
    /// 离职同步审批信息
    /// </summary>
    public class LmSyncMsgInput
    {
        /// <summary>
        /// 离职原因
        /// </summary>
        [Required]
        public string Reason { get; set; }
        /// <summary>
        /// 驳回（转发）对象节点
        /// </summary>
        public string RejectTo { get; set; }

        /// <summary>
        /// 竞业赔偿金
        /// </summary>
        public string Damage { get; set; }

        /// <summary>
        /// 是否启用竞业限制 1 启用 2 不启用
        /// </summary>
        public int WorkLimit { get; set; }

        /// <summary>
        /// 离职去向
        /// </summary>
        public string LeaveDirect { get; set; }

        /// <summary>
        /// 操作人工号
        /// </summary>
        [Required]
        public string OperatorAccount { get; set; }

        /// <summary>
        /// 工资
        /// </summary>
        public string Salary { get; set; }

        /// <summary>
        /// 操作人姓名
        /// </summary>
        public string OperatorName { get; set; }

        /// <summary>
        /// 是否安全审计
        /// </summary>
        public int Security { get; set; }

        /// <summary>
        /// 审批状态 1同意 2拒绝/驳回 3转发
        /// </summary>
        public int Tag { get; set; }

        /// <summary>
        /// 享自由文件编号
        /// </summary>
        public string Freeno { get; set; }

        /// <summary>
        /// 交接人
        /// </summary>
        public string HandOver { get; set; }

        /// <summary>
        /// 绩效
        /// </summary>
        public string Assess { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonIgnore]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 下一节点
        /// </summary>
        [Required]
        public string NextNode { get; set; }

        /// <summary>
        /// 离职原因
        /// </summary>
        public string LeaveReason { get; set; }

        /// <summary>
        /// 申请单文件编号
        /// </summary>
        [Required]
        public string ApplyNo { get; set; }

        /// <summary>
        /// 离职日期
        /// </summary>
        [Required]
        public DateTime LeaveDate { get; set; }

        /// <summary>
        /// 是否流程结束标记（0: 否, 1: 是）
        /// </summary>
        [Required]
        public int Ended { get; set; }
        /// <summary>
        /// 竞业月数
        /// </summary>
        [Required]
        public int LimitMonth { get; set; }

        /// <summary>
        /// 当前节点ID
        /// </summary>
        [Required]
        public string NodeId { get; set; }

        /// <summary>
        /// 交接人电话
        /// </summary>
        public string HandOverTel { get; set; }

        /// <summary>
        /// 是否敏感岗位（0: 否, 1: 是）
        /// </summary>
        public int SensitivePost { get; set; }

        /// <summary>
        /// 离职员工工号
        /// </summary>
        [Required]
        public string LeaveStaffNo { get; set; }

        /// <summary>
        /// mo当前节点审批链接
        /// </summary>
        [Required]
        public string MoUrl { get; set; }
    }
}
