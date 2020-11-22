using Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Responses;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes.Responses
{
    /// <summary>
    /// ActionSoft流程预测信息
    /// </summary>
    public class ActionSoftProcessPredictInfo
    {
        /// <summary>
        /// 是否启动了业务分析
        /// </summary>
        [JsonProperty("bapIsActive")]
        public bool IsBapActive { get; set; }

        /// <summary>
        /// 预计审批审批过程
        /// </summary>
        [JsonProperty("completeTime")]
        public string PredictCompleteProcess { get; set; }

        /// <summary>
        /// 预计审批完成时间
        /// </summary>
        [JsonProperty("endTime")]
        public string PredictCompleteTime { get; set; }

        /// <summary>
        /// 任务s<see cref="ActionSoftTaskPredictInfo"/>
        /// </summary>
        [JsonProperty("processBudgetModelList")]
        public List<ActionSoftTaskPredictInfo> PredictTasks { get; set; }
    }
}
