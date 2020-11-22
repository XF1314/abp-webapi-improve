using Com.OPPO.Mo.Bpm.ActionSoft;
using Com.OPPO.Mo.Bpm.ActionSoft.Processes;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Com.OPPO.Mo.Bpm.Etos
{
    /// <summary>
    /// 流程事件消息Eto
    /// </summary>
    public class ProcessEventMessageEto
    {
        /// <summary>
        /// <see cref="IEntity{Guid}.Id"/>
        /// </summary>
        public string Id { get; set; }

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

        /// <summary>
        /// 流程事件名称
        /// </summary>
        public string ProcessEventName { get; set; }

        /// <summary>
        /// <see cref="ProcessDefinitionInfoEto"/>
        /// </summary>
        public ProcessDefinitionInfoEto ProcessDefinition { get; set; }

        /// <summary>
        /// 流程事件发生时间
        /// </summary>
        public DateTime ProcessEventTime { get; set; }

        /// <summary>
        /// <see cref="OperatorInfoEto"/>
        /// </summary>
        public OperatorInfoEto Operator { get; set; }
    }
}
