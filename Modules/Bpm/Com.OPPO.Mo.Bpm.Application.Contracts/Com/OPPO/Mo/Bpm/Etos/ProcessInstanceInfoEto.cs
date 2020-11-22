using Com.OPPO.Mo.Bpm.ActionSoft.Processes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.Etos
{
    /// <summary>
    /// 流程实例信息Eto
    /// </summary>
    public class ProcessInstanceInfoEto
    {
        /// <summary>
        /// 流程实例Id
        /// </summary>
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 流程Title
        /// </summary>
        public string ProcessTitle { get; set; }

        /// <summary>
        /// ActionSoft流程状态（系统）<see cref="ActionSoftProcessControlState"/>
        /// </summary>
        public string ProcessControlState { get; set; }
    }
}
