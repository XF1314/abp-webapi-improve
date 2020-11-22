using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes.Responses
{
    /// <summary>
    /// ActionSoft流程信息
    /// </summary>
    public class ActionSoftProcessInfo
    {
        /// <summary>
        /// 流程实例Id
        /// </summary>
        [JsonProperty("id")]
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 流程实例编码
        /// </summary>
        [JsonProperty("processBusinessKey")]
        public string ProcessInstanceCode { get; set; }

        /// <summary>
        /// 流程标题
        /// </summary>
        [JsonProperty("title")]
        public string ProcessTitle { get; set; }

        /// <summary>
        /// 流程备注信息
        /// </summary>
        [JsonProperty("remark")]
        public string ProcessRemark { get; set; }

        /// <summary>
        /// 是否子流程
        /// </summary>
        [JsonProperty("subProcess")]
        public bool IsSubProcess { get; set; }

        /// <summary>
        /// 创建该流程的父流程实例Id
        /// </summary>
        [JsonProperty("parentProcessInstId")]
        public string ParentProcessInstanceId { get; set; }

        /// <summary>
        /// 创建该流程的父流程任务实例Id
        /// </summary>
        [JsonProperty("parentTaskInstId")]
        public string ParentTaskInstanceId { get; set; }

        /// <summary>
        /// 是否异步执行流程
        /// </summary>
        [JsonProperty("async")]
        public bool IsAsyncProcess { get; set; }

        /// <summary>
        /// 是否已启动流程
        /// </summary>
        [JsonProperty("start")]
        public bool IsStartedProcess { get; set; }

        /// <summary>
        /// 流程第一个任务（拟制）的定义Id
        /// </summary>
        [JsonProperty("startActivityId")]
        public string StartTaskDefinitionId { get; set; }

        /// <summary>
        /// 流程第一个任务（拟制）实例Id
        /// </summary>
        [JsonProperty("startTaskInstId")]
        public string StartTaskInstanceId { get; set; }

        /// <summary>
        /// 启动时间
        /// </summary>
        [JsonConverter(typeof(DateTimeMillisecondConverter))]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 是否已结束流程
        /// </summary>
        [JsonProperty("end")]
        public bool IsTerminatedProcess { get; set; }

        /// <summary>
        /// 流程结束时所在的审批节点Id
        /// </summary>
        public string EndActivityId { get; set; }

        /// <summary>
        /// 完成时间
        /// </summary>
        [JsonConverter(typeof(DateTimeMillisecondConverter))]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonConverter(typeof(DateTimeMillisecondConverter))]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人用户工号
        /// </summary>
        [JsonProperty("createUser")]
        public string CreatorUserCode { get; set; }

        /// <summary>
        /// 创建人部门编号
        /// </summary>
        [JsonProperty("createUserDeptId")]
        public string CreatorDepartmentCode { get; set; }

        /// <summary>
        /// 创建人组织编码
        /// </summary>
        [JsonProperty("createUserOrgId")]
        public string CreatorOrganizationCode { get; set; }

        /// <summary>
        /// 创建人角色Id
        /// </summary>
        [JsonProperty("createUserRoleId")]
        public string CreatorRoleId { get; set; }

        /// <summary>
        /// 创建人身份信息
        /// </summary>
        [JsonProperty("createUserLocation")]
        public string CreatorLocation { get; set; }

        /// <summary>
        /// 流程从创建到结束所耗费的时长（单位：毫秒）
        /// </summary>
        public long ExcuteCostTime { get; set; }

        /// <summary>
        /// 是否异常流程
        /// </summary>
        [JsonProperty("exception")]
        public bool IsExceptionProcess { get; set; }

        /// <summary>
        /// 流程被催办的次数，来自该实例产生任务发生催办次数的合计
        /// </summary>
        public int RemindTimes { get; set; }

        /// <summary>
        /// 密级等级
        /// </summary>
        public int SecurityLayer { get; set; }

        /// <summary>
        /// 是否已超时
        /// </summary>
        [JsonProperty("overtime")]
        public bool IsOvertime { get; set; }

        /// <summary>
        /// 流程从创建到结束的逾期时间（单位：毫秒），该值与流程模型设置的KPI有关
        /// </summary>
        [JsonProperty("excuteExpireTime")]
        public long ExpireTime { get; set; }

        /// <summary>
        /// <see cref="ActionSoftProcessControlState"/>
        /// </summary>
        public string ControlState { get; set; }

        /// <summary>
        /// 流程实例业务状态<see cref="ActionSoftProcessState"/>
        /// </summary>
        [JsonProperty(ActionSoftProcessExtensionFieldNames.ProcessState)]
        public string ProcessState { get; set; }

        /// <summary>
        /// 流程定义Id
        /// </summary>
        [JsonProperty("processDefId")]
        public string ProcessDefinitionId { get; set; }

        /// <summary>
        /// 流程定义版本Id
        /// </summary>
        [JsonProperty("processDefVerId")]
        public string ProcessDefinitionVersionId { get; set; }

        /// <summary>
        /// 流程组Id
        /// </summary>
        public string ProcessGroupId { get; set; }

        /// <summary>
        /// ?如果是子流程，控制该流程实例行为的策略定义Id
        /// </summary>
        public string ProcessProfileId { get; set; }

        /// <summary>
        /// 流程实例所属业务域分类，Instance Of Business Domain
        /// </summary>
        [JsonProperty("IOBD")]
        public string BusinessDomainClassify { get; set; }

        /// <summary>
        /// 流程实例所属自定义分类，Instance Of Customize
        /// </summary>
        [JsonProperty("IOC")]
        public string CustomizeClassify { get; set; }

        /// <summary>
        /// 流程实例所属组织区域分类，Instance Of Regional
        /// </summary>
        [JsonProperty("IOR")]
        public string RegionalClassify { get; set; }

        /// <summary>
        /// 流程实例所属系统分类，Instance Of System
        /// </summary>
        [JsonProperty("IOS")]
        public string SystemClassify { get; set; }

    }
}
