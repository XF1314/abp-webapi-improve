using Com.OPPO.Mo.Bpm.ActionSoft.Processes;
using Com.OPPO.Mo.Bpm.ActionSoft.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Com.OPPO.Mo.Bpm.Dtos
{
    /// <summary>
    /// 流程事件消息Dto
    /// </summary>
    public  class ProcessEventMessageDto
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
        /// ActionSoft流程状态（系统）
        /// </summary>
        public string ProcessControlState { get; set; }

        /// <summary>
        /// 流程事件事件名称
        /// </summary>
        public string ProcessEventName { get; set; }

        /// <summary>
        /// 流程事件发生时间
        /// </summary>
        public DateTime ProcessEventTime { get; set; }

        /// <summary>
        /// <see cref="ProcessDefinitionInfoDto"/>
        /// </summary>
        public ProcessDefinitionInfoDto ProcessDefinition { get; set; }

        /// <summary>
        /// <see cref="OperatorInfoDto"/>
        /// </summary>
        public OperatorInfoDto Operator { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }
    }
}
