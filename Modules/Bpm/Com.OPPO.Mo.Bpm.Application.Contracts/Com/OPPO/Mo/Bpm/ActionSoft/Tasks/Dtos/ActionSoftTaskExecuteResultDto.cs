using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Dtos
{
    /// <summary>
    /// ActionSoft任务执行结果Dto
    /// </summary>
    public  class ActionSoftTaskExecuteResultDto
    {
        /// <summary>
        /// 是否流程已经结束
        /// </summary>
        public Boolean IsProcessEnd { get; set; }

        /// <summary>
        /// 本次执行所完成的任务s
        /// </summary>
        public List<ActionSoftHistoryTaskDto> HistoryTasks { get; set; }

        /// <summary>
        /// 本次执行所创建/启动的任务s
        /// </summary>
        public List<ActionSoftTaskDto> ActiveTasks { get; set; }
    }
}
