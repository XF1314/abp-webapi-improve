﻿using Com.OPPO.Mo.Bpm.ActionSoft.Processes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Dtos
{
    /// <summary>
    /// ActionSoft历史任务Dto
    /// </summary>
    public class ActionSoftHistoryTaskDto
    {
        /// <summary>
        /// 任务实例Id
        /// </summary>
        public string TaskInstanceId { get; set; }

        /// <summary>
        /// 任务信息
        /// </summary>
        public string TaskInfo { get; set; }

        /// <summary>
        /// 任务标题
        /// </summary>
        public string TaskTitle { get; set; }

        /// <summary>
        /// 是否异步任务
        /// </summary>
        public bool IsAsyncTask { get; set; }

        /// <summary>
        /// 是否可收回任务
        /// </summary>
        public bool IsRecoverableTask { get; set; }

        /// <summary>
        /// 任务定义Id
        /// </summary>
        public string TaskDefinitionId { get; set; }

        /// <summary>
        /// <see cref="ActionSoftActivityType"/>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ActionSoftActivityType ActivityType { get; set; }

        /// <summary>
        /// <see cref="ActionSoftTaskType"/>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ActionSoftTaskType TaskType { get; set; }

        /// <summary>
        ///  创建该任务的AWS引擎节点
        /// </summary>
        public string BeginEngineNode { get; set; }

        /// <summary>
        /// 结束该任务的AWS引擎节点
        /// </summary>
        public string EndEngineNode { get; set; }

        /// <summary>
        /// 任务创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 任务结束时间，如果无完成结束时间，返回Null
        /// </summary>
        public DateTime? FinishTime { get; set; }

        /// <summary>
        /// 认领对象Id（一个36位长度的Id，如果不是公共任务池任务，返回空串）
        /// </summary>
        public string ClaimResourceId { get; set; }

        /// <summary>
        /// 公共任务池认领类型
        /// </summary>
        public int ClaimType { get; set; }

        /// <summary>
        /// <see cref="ActionSoftTaskControlState"/>
        /// </summary>
        public string ControlState { get; set; }        

        /// <summary>
        /// 代理人员工工号（如果该任务不是被委托的代理人执行，返回空）
        /// </summary>
        public string DelegateUserCode { get; set; }

        /// <summary>
        /// 多例调度Id
        /// </summary>
        public string DispatchId { get; set; }

        /// <summary>
        /// 任务从创建到执行完毕的总耗时（单位：毫秒）
        /// </summary>
        public long CostTime { get; set; }

        /// <summary>
        /// 任务已过期的时间（单位：毫秒）
        /// </summary>
        public long ExpireTime { get; set; }

        /// <summary>
        /// 是否Eai任务（这类任务不需要工作流引擎驱动，用于统一企业工作中心的方案）
        /// </summary>
        public bool IsEaiTask { get; set; }

        /// <summary>
        /// Eai任务的业务标识Id，如果非Eai任务则返回空
        /// </summary>
        public string EaiTaskBizId { get; set; }

        /// <summary>
        /// Eai任务的业务Url，如果非Eai任务则返回空
        /// </summary>
        public string EaiTaskBizUrl { get; set; }

        /// <summary>
        /// <see cref="ActionSoftProcessState"/>
        /// </summary>
        public string ProcessState { get; set; }

        /// <summary>
        /// 是否是已结束的历史任务
        /// </summary>
        public bool IsHistoryTask { get; set; }

        /// <summary>
        /// 是否根任务
        /// </summary>
        public bool IsRootTask { get; set; }

        /// <summary>
        /// 是否被超时策略监控的任务
        /// </summary>
        public bool IsMonitorTask { get; set; }

        /// <summary>
        /// 创建人工号，如果是Eai外部任务，该值为Eai任务的系统简称
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// 认领工号，适用于人工任务和Eai外部任务
        /// </summary>
        public string ClaimToUserCode { get; set; }

        /// <summary>
        /// 任务创建人部门编码，如果是Eai外部任务，该值为空
        /// </summary>
        public string CreatorDepartmentCode { get; set; }

        /// <summary>
        /// 认领部门编码
        /// </summary>
        public string ClaimToDepartmentCode { get; set; }

        /// <summary>
        /// 认领单位编码
        /// </summary>
        public string ClaimToCompanyCode { get; set; }

        /// <summary>
        /// 认领角色Id
        /// </summary>
        public string ClaimToRoleId { get; set; }

        /// <summary>
        /// 前一任务实例Id，如果该任务为流程实例的首个任务，返回空串
        /// </summary>
        public string PreviousTaskInstanceId { get; set; }

        /// <summary>
        /// <see cref="ActionSoftPriority"/>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ActionSoftPriority Priority { get; set; }

        /// <summary>
        /// 流程定义Id
        /// </summary>
        public string ProcessDefinitionId { get; set; }

        /// <summary>
        /// 流程版本定义Id
        /// </summary>
        public string ProcessDefinitionVersionId { get; set; }

        /// <summary>
        /// 流程组Id，一个流程组可以包含多个流程版本
        /// </summary>
        public string ProcessGroupId { get; set; }

        /// <summary>
        /// 流程实例Id
        /// </summary>
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 查看状态（0:未读,1:已读）
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ActionSoftReadState ReadState { get; set; }

        /// <summary>
        /// 查看时间
        /// </summary>
        public DateTime? ReadTime { get; set; }

        /// <summary>
        /// 流程实例所属业务域分类，Instance Of Business Domain
        /// </summary>
        public string BusinessDomainClassify { get; set; }

        /// <summary>
        /// 流程实例所属自定义分类，Instance Of Customize
        /// </summary>
        public string CustomizeClassify { get; set; }

        /// <summary>
        /// 流程实例所属组织区域分类，Instance Of Regional
        /// </summary>
        public string RegionalClassify { get; set; }

        /// <summary>
        /// 流程实例所属系统分类，Instance Of System
        /// </summary>
        public string SystemClassify { get; set; }
    }
}
