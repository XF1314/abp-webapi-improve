using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Com.OPPO.Mo.Bpm
{
    /// <summary>
    /// 任务事件消息
    /// </summary>
    public class TaskEventMessage : Entity<Guid>, IHasCreationTime
    {
        /// <summary>
        /// 任务实例Id
        /// </summary>
        [NotNull]
        public string TaskInstanceId { get; set; }

        /// <summary>
        /// ActionSfot任务状态
        /// </summary>
        [NotNull]
        public string TaskControlState { get; set; }

        /// <summary>
        /// 审批动作
        /// </summary>
        [NotNull]
        public string Action { get; set; }

        /// <summary>
        /// 审批意见
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// 任务事件事件名称
        /// </summary>
        [NotNull]
        public string TaskEventName { get; set; }

        /// <summary>
        /// 任务事件发生时间
        /// </summary>
        [NotNull]
        public DateTime TaskEventTime { get; set; }

        /// <summary>
        /// 历史任务实例Ids
        /// </summary>
        public List<string> HistoryTaskInstanceIds { get; set; }

        /// <summary>
        /// <see cref="ProcessInstanceInfo"/>
        /// </summary>
        [NotNull]
        public ProcessInstanceInfo ProcessInstance { get; set; }

        /// <summary>
        /// <see cref="ProcessDefinitionInfo"/>
        /// </summary>
        [NotNull]
        public ProcessDefinitionInfo ProcessDefinition { get; set; }

        /// <summary>
        /// <see cref="TaskDefinitionInfo"/>
        /// </summary>
        [NotNull]
        public TaskDefinitionInfo TaskDefinition { get; set; }

        /// <summary>
        /// <see cref="OperatorInfo"/>
        /// </summary>
        [NotNull]
        public OperatorInfo Operator { get; set; }

        /// <summary>
        /// <see cref="TargetUserInfo"/>
        /// </summary>
        public TargetUserInfo TargetUser { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }
    }
}
