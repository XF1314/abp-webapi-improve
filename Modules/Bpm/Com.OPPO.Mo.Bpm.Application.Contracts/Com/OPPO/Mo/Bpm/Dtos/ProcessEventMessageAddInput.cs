using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Com.OPPO.Mo.Bpm.Dtos
{
    /// <summary>
    /// 流程事件消息新增Input
    /// </summary>
    public class ProcessEventMessageAddInput
    {
        /// <summary>
        /// 【必填项】流程实例Id
        /// </summary>
        [JsonRequired]
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 流程Title
        /// </summary>
        public string ProcessTitle { get; set; }

        /// <summary>
        /// 【必填项】ActionSoft流程状态（系统）
        /// </summary>
        [JsonRequired]
        public string ProcessControlState { get; set; }

        /// <summary>
        /// 【必填项】流程事件事件名称
        /// </summary>
        [JsonRequired]
        public string ProcessEventName { get; set; }

        /// <summary>
        /// 【必填项】流程事件发生时间
        /// </summary>
        [JsonRequired]
        public DateTime ProcessEventTime { get; set; }

        /// <summary>
        /// 【必填项】<see cref="ProcessDefinitionInfoDto"/>
        /// </summary>
        [JsonRequired]
        public ProcessDefinitionInfoDto ProcessDefinition { get; set; }

        /// <summary>
        /// 【必填项】<see cref="OperatorInfoDto"/>
        /// </summary>
        [JsonRequired]
        public OperatorInfoDto Operator { get; set; }
    }
}
