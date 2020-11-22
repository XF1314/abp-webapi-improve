using Com.OPPO.Mo.Bpm.ActionSoft;
using Com.OPPO.Mo.Bpm.ActionSoft.Processes;
using Com.OPPO.Mo.Bpm.ActionSoft.Tasks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Com.OPPO.Mo.Bpm.Etos
{
    /// <summary>
    /// 任务事件消息Eto
    /// </summary>
    public class TaskEventMessageEto
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
        /// ActionSoft任务状态<see cref="ActionSoftTaskControlState"/>
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
        /// 任务事件名称
        /// </summary>
        public string TaskEventName { get; set; }

        /// <summary>
        /// 任务事件发生时间
        /// </summary>
        public DateTime TaskEventTime { get; set; }

        /// <summary>
        /// <see cref="ProcessInstanceInfoEto"/>
        /// </summary>
        public ProcessInstanceInfoEto ProcessInstance { get; set; }

        /// <summary>
        /// <see cref="ProcessDefinitionInfoEto"/>
        /// </summary>
        public ProcessDefinitionInfoEto ProcessDefinition { get; set; }

        /// <summary>
        /// <see cref="TaskDefinitionInfoEto"/>
        /// </summary>
        public TaskDefinitionInfoEto TaskDefinition { get; set; }

        /// <summary>
        /// <see cref="OperatorInfoEto"/>
        /// </summary>
        public OperatorInfoEto Operator { get; set; }

        /// <summary>
        /// <see cref="TargetUserInfoEto"/>任务认领人
        /// </summary>
        public TargetUserInfoEto TargetUser { get; set; }
    }
}
