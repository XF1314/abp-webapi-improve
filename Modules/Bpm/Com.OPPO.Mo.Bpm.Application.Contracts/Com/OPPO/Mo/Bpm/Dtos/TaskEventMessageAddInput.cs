using Com.OPPO.Mo.Bpm.ActionSoft;
using Com.OPPO.Mo.Bpm.ActionSoft.Tasks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.Dtos
{
    /// <summary>
    /// 任务事件消息新增Input
    /// </summary>
    public class TaskEventMessageAddInput
    {
        /// <summary>
        /// 【必填项】任务实例Id
        /// </summary>
        [JsonRequired]
        public string TaskInstanceId { get; set; }

        /// <summary>
        /// ActionSfot任务状态<see cref="ActionSoftTaskControlState"/>
        /// </summary>
        [JsonRequired]
        public string TaskControlState { get; set; }

        /// <summary>
        /// 【必填项】审批动作<see cref="ActionSoftApprovalAction"/>
        /// </summary>
        [JsonRequired]
        public string Action { get; set; }

        /// <summary>
        /// 【必填项】审批意见
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// 【必填项】任务事件事件名称
        /// </summary>
        [JsonRequired]
        public string TaskEventName { get; set; }

        /// <summary>
        /// 【必填项】任务事件发生时间
        /// </summary>
        [JsonRequired]
        public DateTime TaskEventTime { get; set; }

        /// <summary>
        /// 【非必填项】历史任务实例Ids
        /// </summary>
        public List<string> HistoryTaskInstanceIds { get; set; }

        /// <summary>
        /// 【必填项】<see cref="ProcessInstanceInfoDto"/>
        /// </summary>
        [JsonRequired]
        public ProcessInstanceInfoDto ProcessInstance { get; set; }

        /// <summary>
        /// 【必填项】<see cref="ProcessDefinitionInfoDto"/>
        /// </summary>
        [JsonRequired]
        public ProcessDefinitionInfoDto ProcessDefinition { get; set; }

        /// <summary>
        /// 【必填项】<see cref="TaskDefinitionInfoDto"/>
        /// </summary>
        [JsonRequired]
        public TaskDefinitionInfoDto TaskDefinition { get; set; }

        /// <summary>
        /// 【必填项】<see cref="OperatorInfoDto"/>
        /// </summary>
        [JsonRequired]
        public OperatorInfoDto Operator { get; set; }

        /// <summary>
        /// 【非必填项】<see cref="TargetUserInfoDto"/>任务认领人信息
        /// </summary>
        public TargetUserInfoDto TargetUser { get; set; }
    }
}
