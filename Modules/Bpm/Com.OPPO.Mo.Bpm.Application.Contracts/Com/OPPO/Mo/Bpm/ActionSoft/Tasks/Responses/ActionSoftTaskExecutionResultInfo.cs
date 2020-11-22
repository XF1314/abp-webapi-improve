using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Responses
{
    /// <summary>
    /// ActionSoft任务执行结果信息
    /// </summary>
    public  class ActionSoftTaskExecutionResultInfo
    {
        /// <summary>
        /// 是否流程已经结束
        /// </summary>
        public Boolean IsProcessEnd { get; set; }

        /// <summary>
        /// 本次执行所完成的任务s
        /// </summary>
        [JsonProperty("historyTasks")]
        public List<ActionSoftHistoryTaskInfo> HistoryTasks { get; set; }

        /// <summary>
        /// 本次执行所创建/启动的任务s
        /// </summary>
        public List<ActionSoftTaskInfo> ActiveTasks { get; set; }

    }
}
