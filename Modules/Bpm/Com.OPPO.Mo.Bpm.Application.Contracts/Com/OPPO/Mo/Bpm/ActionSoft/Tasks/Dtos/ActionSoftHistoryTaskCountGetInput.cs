using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Dtos
{
    /// <summary>
    /// ActionSoft历史任务数量获取Input
    /// </summary>
    public class ActionSoftHistoryTaskCountGetInput
    {
        /// <summary>
        /// <see cref="ActionSoftHistoryTaskCountGetInput"/>
        /// </summary>
        public ActionSoftHistoryTaskCountGetInput()
        {
            ExtensionConditions = new Dictionary<string, object> { };
        }

        #region 任务实例
        /// <summary>
        /// 【选填项】任务定义Id
        /// </summary>
        public string TaskDefinitionId { get; set; }

        /// <summary>
        /// 【选填项】<see cref="ActionSoftTaskType"/>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ActionSoftTaskType? TaskType { get; set; }

        /// <summary>
        /// 【选填项】任务标题（模糊匹配）
        /// </summary>
        public string TaskTitle { get; set; }

        /// <summary>
        /// 【选填项】创建人账户名，如果是Eai外部任务，该值为Eai任务的系统简称
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// 【选填项】一组创建人账户名，如果是Eai外部任务，该值为Eai任务的系统简称
        /// </summary>
        public List<string> Owners { get; set; }

        /// <summary>
        /// 【选填项】Eai任务的业务标识Id，如果非Eai任务则返回空
        /// </summary>
        public string EaiTaskBizId { get; set; }

        /// <summary>
        /// 【选填项】Eai任务的业务Url，如果非Eai任务则返回空
        /// </summary>
        public string EaiTaskBizUrl { get; set; }

        /// <summary>
        /// 【选填项】前一任务实例Id，如果该任务为流程实例的首个任务，返回空串
        /// </summary>
        public string PreviousTaskInstanceId { get; set; }

        /// <summary>
        /// 【选填项】<see cref="ActionSoftPriority"/>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ActionSoftPriority? Priority { get; set; }

        /// <summary>
        /// 【选填项】是否由管理员认领（如果任务没有参与者，暂时认领给管理员的异常任务）
        /// </summary>
        public bool? IsClaimToAdministrator { get; set; }

        /// <summary>
        /// 【选填项】是否合并从公共池待认领的任务，
        /// 该特性受bpmn.properties文件ENGINE_CLAIM_SUPPORT配置的影响， 引擎支持的公共池任务类型包括团队、角色和部门
        /// </summary>
        public bool? IsSupportClaimTask { get; set; }

        /// <summary>
        /// 【选填项】是否合并可委托的任务，
        /// 除claim类型共享任务外，都允许代理人处理，代理范围权限和有效期由委托申请存根提供
        /// </summary>
        public bool? IsSupportDelegateTask { get; set; }

        /// <summary>
        /// 【选填项】是否正常活动的任务
        /// </summary>
        public bool? IsActiveTask { get; set; }

        /// <summary>
        /// 【选填项】是否已发生错误的任务
        /// </summary>
        public bool? IsExceptionTask { get; set; }

        /// <summary>
        /// 【选填项】是否异步任务
        /// </summary>
        public bool? IsAsyncTask { get; set; }

        /// <summary>
        /// 【选填项】是否Eai任务
        /// </summary>
        public bool? IsEaiTask { get; set; }

        /// <summary>
        /// 【选填项】是否被超时策略监控的任务
        /// </summary>
        public bool? IsMonitorTask { get; set; }

        /// <summary>
        /// 【选填项】是否已读任务
        /// </summary>
        public bool? IsReadedTask { get; set; }

        /// <summary>
        /// 【选填项】是否已挂起的任务
        /// </summary>
        public bool? IsSuspendedTask { get; set; }

        /// <summary>
        /// 【选填项】是否人工任务
        /// </summary>
        public bool? IsUserTask { get; set; }

        /// <summary>
        /// 【选填项】是否通知类待办任务（传阅、系统通知）
        /// </summary>
        public bool? IsUserTaskOfNotification { get; set; }

        /// <summary>
        /// 【选填项】待办工作类任务（正常待办、等待加签及加签类待办）
        /// </summary>
        public bool? IsUserTaskOfWorking { get; set; }

        /// <summary>
        /// 【选填项】认领任务的部门编码
        /// </summary>
        public string ClaimToDepartmentCode { get; set; }

        /// <summary>
        /// 【选填项】认领任务的角色Id
        /// </summary>
        public string ClaimToRoleId { get; set; }

        /// <summary>
        /// 【选填项】认领任务的群组
        /// </summary>
        public string ClaimToTeamId { get; set; }
        #endregion

        #region 流程
        /// <summary>
        /// 【选填项】流程组Id
        /// </summary>
        public string ProcessGroupId { get; set; }

        /// <summary>
        /// 【选填项】一组流程组Id
        /// </summary>
        public List<string> ProcessGroupIds { get; set; }

        /// <summary>
        /// 【选填项】任务实例所关联的流程实例Id
        /// </summary>
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 【选填项】任务实例所关联的流程实例编码
        /// </summary>
        public string ProcessInstanceCode { get; set; }

        /// <summary>
        /// 【选填项】任务实例所关联的流程定义Id
        /// </summary>
        public string ProcessDefinitionId { get; set; }

        /// <summary>
        /// 【选填项】任务实例所关联的流程定义版本Id
        /// </summary>
        public string ProcessDefinitionVersionId { get; set; }

        /// <summary>
        /// 【选填项】该任务被创建的AWS服务节点
        /// </summary>
        public string BeginEngineNodeTask { get; set; }

        /// <summary>
        /// 【选填项】流程实例所属业务域分类，Instance Of Business Domain
        /// </summary>
        public string BusinessDomainClassify { get; set; }

        /// <summary>
        /// 【选填项】流程实例所属自定义分类，Instance Of Customize
        /// </summary>
        public string CustomizeClassify { get; set; }

        /// <summary>
        /// 【选填项】流程实例所属组织区域分类，Instance Of Regional
        /// </summary>
        public string RegionalClassify { get; set; }

        /// <summary>
        /// 【选填项】流程实例所属系统分类，Instance Of System
        /// </summary>
        public string SystemClassify { get; set; }
        #endregion

        /// <summary>
        /// 【选填项】创建时间From
        /// </summary>
        public DateTime? CreateTimeFrom { get; set; }

        /// <summary>
        /// 【选填项】创建时间To
        /// </summary>
        public DateTime? BeginTimeTo { get; set; }

        /// <summary>
        /// 【选填项】是否按创建时间升序
        /// </summary>
        public bool? IsOrderByCreateTimeAsc { get; set; }

        /// <summary>
        /// 【选填项】是否按优先级升序
        /// </summary>
        public bool? IsOrderByPriorityAsc { get; set; }

        /// <summary>
        /// 【选填项】是否按标题升序
        /// </summary>
        public bool IsOrderByTaskTitleAsc { get; set; }

        /// <summary>
        /// 【选填项】扩展条件s，以字段名与字段值的键值对形式呈现
        /// </summary>
        public Dictionary<string, object> ExtensionConditions { get; set; }
    }
}
