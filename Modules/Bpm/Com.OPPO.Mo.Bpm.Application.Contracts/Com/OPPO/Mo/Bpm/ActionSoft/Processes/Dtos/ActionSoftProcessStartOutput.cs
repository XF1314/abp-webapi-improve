using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes.Dtos
{
    /// <summary>
    /// ActionSoft流程启动Output
    /// </summary>
     public class ActionSoftProcessStartOutput
    {
        /// <summary>
        /// 流程实例Id
        /// </summary>
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 流程实例编码
        /// </summary>
        public string ProcessInstanceCode { get; set; }

        /// <summary>
        /// 流程实例标题
        /// </summary>
        public string ProcessTitle { get; set; }

        /// <summary>
        /// 流程第一个任务（拟制）的定义Id
        /// </summary>
        public string StartTaskDefinitionId { get; set; }

        /// <summary>
        /// 流程启动时产生的首个任务实例Id
        /// </summary>
        public string StartTaskInstanceId { get; set; }
    }
}
