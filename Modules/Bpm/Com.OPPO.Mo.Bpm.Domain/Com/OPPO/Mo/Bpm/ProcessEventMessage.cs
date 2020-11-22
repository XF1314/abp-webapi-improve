using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Com.OPPO.Mo.Bpm
{
    /// <summary>
    /// 流程事件消息
    /// </summary>
    public class ProcessEventMessage : Entity<Guid>, IHasCreationTime
    {
        /// <summary>
        /// 流程实例Id
        /// </summary>
        [NotNull]
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 流程Title
        /// </summary>
        public string ProcessTitle { get; set; }

        /// <summary>
        /// ActionSoft流程状态（系统）
        /// </summary>
        [NotNull]
        public string ProcessControlState { get; set; }

        /// <summary>
        /// 流程事件事件名称
        /// </summary>
        [NotNull]
        public string ProcessEventName { get; set; }

        /// <summary>
        /// 流程事件发生时间
        /// </summary>
        [NotNull]
        public DateTime ProcessEventTime { get; set; }

        /// <summary>
        /// <see cref="ProcessDefinitionInfo"/>
        /// </summary>
        [NotNull]
        public ProcessDefinitionInfo ProcessDefinition { get; set; }

        /// <summary>
        /// <see cref="OperatorInfo"/>
        /// </summary>
        [NotNull]
        public OperatorInfo Operator { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }
    }
}
