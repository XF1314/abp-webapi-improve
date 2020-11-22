using Com.OPPO.Mo.Bpm.ActionSoft;
using Com.OPPO.Mo.Bpm.ActionSoft.Processes;
using Com.OPPO.Mo.Bpm.ActionSoft.Tasks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Com.OPPO.Mo.Bpm.Dtos
{
    /// <summary>
    /// 任务事件消息Dto
    /// </summary>
    public class TaskEventMessageDto
    {
        /// <summary>
        /// <see cref="IEntity{Guid}.Id"/>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 任务实例Id
        /// </summary>
        public string TaskInstanceId { get; set; }

        /// <summary>
        /// ActionSfot任务状态<see cref="ActionSoftTaskControlState"/>
        /// </summary>
        public string TaskControlState { get; set; }

        /// <summary>
        /// 审批动作<see cref="ActionSoftApprovalAction"/>
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// 审批意见
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// 任务事件事件名称
        /// </summary>
        public string TaskEventName { get; set; }

        /// <summary>
        /// 任务事件发生时间
        /// </summary>
        public DateTime TaskEventTime { get; set; }

        /// <summary>
        /// 历史任务实例Ids
        /// </summary>
        public List<string> HistoryTaskInstanceIds { get; set; }

        /// <summary>
        /// <see cref="ProcessInstanceInfoDto"/>
        /// </summary>
        public ProcessInstanceInfoDto ProcessInstance { get; set; }

        /// <summary>
        /// <see cref="ProcessDefinitionInfoDto"/>
        /// </summary>
        public ProcessDefinitionInfoDto ProcessDefinition { get; set; }

        /// <summary>
        /// <see cref="TaskDefinitionInfoDto"/>
        /// </summary>
        public TaskDefinitionInfoDto TaskDefinition { get; set; }

        /// <summary>
        /// <see cref="OperatorInfoDto"/>
        /// </summary>
        public OperatorInfoDto Operator { get; set; }

        /// <summary>
        /// <see cref="TargetUserInfoDto"/>任务认领用户信息
        /// </summary>
        public TargetUserInfoDto TargetUser { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }
    }
}
