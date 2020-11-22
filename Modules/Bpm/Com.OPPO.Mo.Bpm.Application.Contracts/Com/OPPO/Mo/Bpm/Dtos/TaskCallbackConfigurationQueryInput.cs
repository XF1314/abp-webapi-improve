using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.Dtos
{
    /// <summary>
    /// 任务回调配置查询Input
    /// </summary>
    public class TaskCallbackConfigurationQueryInput
    {
        /// <summary>
        /// 【选填项】应用Id
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 【选填项】流程定义Id
        /// </summary>
        public string ProcessDefinitionId { get; set; }

        /// <summary>
        /// 【选填项】流程名称
        /// </summary>
        public string ProcessName { get; set; }

        /// <summary>
        /// 【选填项】任务定义Id
        /// </summary>
        public string TaskDefinitionId { get; set; }

        /// <summary>
        /// 【选填项】任务事件名称
        /// </summary>
        public string TaskEventName { get; set; }

        /// <summary>
        /// 【选填项】回调地址
        /// </summary>
        public string CallbackUrl { get; set; }

        /// <summary>
        /// 【选填项】是否有效
        /// </summary>
        public bool? IsValid { get; set; }
    }
}
