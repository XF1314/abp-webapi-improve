using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes.Dtos
{
    /// <summary>
    /// ActionSoft流程创建Output
    /// </summary>
    public class ActionSoftProcessCreateOutput
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
    }
}
