using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes.Dtos
{
    /// <summary>
    /// 任务留言信息Dto
    /// </summary>
    public class ActionSoftTaskCommentInfoDto
    {
        /// <summary>
        /// 留言Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 流程实例Id
        /// </summary>
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 任务实例Id
        /// </summary>
        public string TaskInstanceId { get; set; }

        /// <summary>
        /// 环节名称
        /// </summary>
        public string ActivityName { get; set; }

        /// <summary>
        /// 审批动作名称
        /// </summary>
        public string ActionName { get; set; }


        /// <summary>
        /// 留言创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 留言人工号
        /// </summary>
        public string CreatorUserCode { get; set; }

        /// <summary>
        ///  留言人部门名称
        /// </summary>
        public string CreatorDepartmentName { get; set; }


        /// <summary>
        ///  留言人职位名称
        /// </summary>
        public string CreatorPositionName { get; set; }

        /// <summary>
        ///  留言信息
        /// </summary>
        public string Comment { get; set; }
    }
}
