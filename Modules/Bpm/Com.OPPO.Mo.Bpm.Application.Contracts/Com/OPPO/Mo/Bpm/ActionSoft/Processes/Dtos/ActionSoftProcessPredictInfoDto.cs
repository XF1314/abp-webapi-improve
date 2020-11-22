using Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes.Dtos
{
    /// <summary>
    /// ActionSoft流程预测信息Dto
    /// </summary>
    public class ActionSoftProcessPredictInfoDto
    {
        /// <summary>
        /// 是否启动了业务分析
        /// </summary>
        public bool IsBapActive { get; set; }

        /// <summary>
        /// 当前所在的审批节点Id（如果流程已经审批完成，则返回空值）
        /// </summary>
        public string CurrentActivityId { get; set; }

        /// <summary>
        /// 预计审批审批过程
        /// </summary>
        public string PredictCompleteProcess { get; set; }

        /// <summary>
        /// 预计审批完成时间
        /// </summary>
        public string PredictCompleteTime { get; set; }

        /// <summary>
        /// <see cref="ActionSoftTaskPredictInfoDto"/>
        /// </summary>
        public List<ActionSoftTaskPredictInfoDto> PredictTasks { get; set; }
    }
}
