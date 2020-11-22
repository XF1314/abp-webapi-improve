using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes.Requests
{
    /// <summary>
    /// ActionSoft流程查询模型
    /// </summary>
    public class ActionSoftProcessQueryModel
    {
        /// <summary>
        /// <see cref="ActionSoftProcessQueryModel"/>
        /// </summary>
        public ActionSoftProcessQueryModel()
        {
            ProcessInstanceIds = new List<string>();
            ProcessInstanceCodes = new List<string>();
            ExtensionConditions = new Dictionary<string, object>();
        }

        #region 流程实例
        /// <summary>
        /// 【选填项】一组流程实例Id
        /// </summary>
        [JsonProperty("ids")]
        public List<string> ProcessInstanceIds { get; set; }

        ///// <summary>
        ///// 【选填项】一组流程实例Id
        ///// </summary>
        //[JsonProperty("ids")]
        //public string _processInstanceIds => JsonConvert.SerializeObject(ProcessInstanceIds);

        /// <summary>
        /// 【选填项】一组流程实例Code
        /// </summary>
        [JsonProperty("keys")]
        public List<string> ProcessInstanceCodes { get; set; }

        ///// <summary>
        ///// 【选填项】一组流程实例Code
        ///// </summary>
        //[JsonProperty("keys")]
        //public string _processInstanceCodes => JsonConvert.SerializeObject(ProcessInstanceCodes);

        /// <summary>
        /// 【选填项】父流程实例Id，用于通过父流程实例Id查所有的子流程实例
        /// </summary>
        [JsonProperty("parentProcessInstId")]
        public string ParentProcessInstanceId { get; set; }

        /// <summary>
        /// 【选填项】父流程实例中的任务实例Id，用于通过任务实例Id查由当前任务创建的子流程实例
        /// </summary>
        [JsonProperty("parentTaskInstId")]
        public string ParentTaskInstanceId { get; set; }

        /// <summary>
        /// 【选填项】流程标题
        /// </summary>
        [JsonProperty("titleLike")]
        public string ProcessTitle { get; set; }

        /// <summary>
        /// 【选填项】流程备注（模糊匹配）
        /// </summary>
        [JsonProperty("remarkLike")]
        public string ProcessRemark { get; set; }

        /// <summary>
        /// 【选填项】是否BO(DW的仅存储)流程
        /// </summary>
        [JsonProperty("nonProcess")]
        public bool? IsBoProcess { get; set; }

        /// <summary>
        /// 【选填项】是否Short(编排)流程
        /// </summary>
        [JsonProperty("shortProcess")]
        public bool? IsShortProcess { get; set; }

        /// <summary>
        /// 【选填项】是否子流程
        /// </summary>
        [JsonProperty("subProcess")]
        public bool? IsSubProcess { get; set; }

        /// <summary>
        /// 【选填项】是否活动流程
        /// </summary>
        [JsonProperty("activeProcess")]
        public bool? IsActiveProcess { get; set; }

        /// <summary>
        /// 【选填项】是否已启动流程
        /// </summary>
        [JsonProperty("started")]
        public bool? IsStartedProcess { get; set; }

        /// <summary>
        /// 【选填项】是否已取消流程
        /// </summary>
        [JsonProperty("canceledProcess")]
        public bool? IsCanceledProcess { get; set; }

        /// <summary>
        /// 【选填项】是否包含子流程
        /// </summary>
        [JsonProperty("existSubProcess")]
        public bool? IsExistSubProcess { get; set; }

        /// <summary>
        /// 【选填项】是否已挂起流程
        /// </summary>
        [JsonProperty("suspendedProcess")]
        public bool? IsSuspendedProcess { get; set; }

        /// <summary>
        /// 【选填项】是否已结束流程
        /// </summary>
        [JsonProperty("terminatedProcess")]
        public bool? IsTerminatedProcess { get; set; }

        /// <summary>
        /// 【选填项】是否未启动流程
        /// </summary>
        [JsonProperty("unStarted")]
        public bool? IsUnStartedProcess { get; set; }

        /// <summary>
        /// 【选填项】拟制人工号
        /// </summary>
        [JsonProperty("createBy")]
        public string CreatorUserCode { get; set; }
        #endregion

        #region 流程定义
        /// <summary>
        /// 【选填项】流程实例所属业务域分类，Instance Of Business Domain
        /// </summary>
        [JsonProperty("IOBD")]
        public string BusinessDomainClassify { get; set; }

        /// <summary>
        /// 【选填项】流程实例所属自定义分类，Instance Of Customize
        /// </summary>
        [JsonProperty("IOC")]
        public string CustomizeClassify { get; set; }

        /// <summary>
        /// 【选填项】流程实例所属组织区域分类，Instance Of Regional
        /// </summary>
        [JsonProperty("IOR")]
        public string RegionalClassify { get; set; }

        /// <summary>
        /// 【选填项】流程实例所属系统分类
        /// </summary>
        [JsonProperty("IOS")]
        public string SystemClassify { get; set; }

        /// <summary>
        /// 【选填项】流程定义Id
        /// </summary>
        [JsonProperty("processDefId")]
        public string ProcessDefinitionId { get; set; }

        /// <summary>
        /// 【选填项】流程定义版本Id
        /// </summary>
        [JsonProperty("processDefVefId")]
        public string ProcessDefinitionVersionId { get; set; }

        /// <summary>
        /// 【选填项】流程组Id
        /// </summary>
        [JsonProperty("processGroupId")]
        public string ProcessGroupId { get; set; }

        /// <summary>
        /// 【选填项】一组流程组Id
        /// </summary>
        [JsonProperty("processGroupIds")]
        public List<string> ProcessGroupIds { get; set; }
        #endregion

        /// <summary>
        /// 【选填项】创建时间From
        /// </summary>
        [JsonProperty("createdAfter")]
        public DateTime? CreateTimeFrom { get; set; }

        /// <summary>
        /// 【选填项】创建时间To
        /// </summary>
        [JsonProperty("createdBefore")]
        public DateTime? CreateTimeTo { get; set; }

        /// <summary>
        /// 【选填项】完成时间From
        /// </summary>
        [JsonProperty("finishedAfter")]
        public DateTime? FinishTimeFrom { get; set; }

        /// <summary>
        /// 【选填项】完成时间To
        /// </summary>
        [JsonProperty("finishedBefore")]
        public DateTime? FinishTimeTo { get; set; }

        /// <summary>
        /// 【选填项】是否按流程实例创建时间升序排列
        /// </summary>
        [JsonProperty("orderByCreateTimeASC")]
        public bool? IsOrderByCreateTimeAsc { get; set; }

        /// <summary>
        /// 【选填项】是否按流程实例启动时间升序排列
        /// </summary>
        [JsonProperty("orderByStartTimeASC")]
        public bool? IsOrderByStartTimeAsc { get; set; }

        /// <summary>
        /// 【选填项】是否按流程定义Id升序排列
        /// </summary>
        [JsonProperty("orderByProcessDefId")]
        public bool? IsOrderByProcessDefinitionIdAsc { get; set; }

        /// <summary>
        /// 【选填项】是否按流程定义版本Id长统排列
        /// </summary>
        [JsonProperty("orderByProcessDefVerId")]
        public bool? IsOrderByProcessDefinitionVersionIdAsc { get; set; }

        /// <summary>
        /// 【选填项】扩展条件s，以字段名与字段值的键值对形式呈现
        /// </summary>
        [JsonIgnore]
        public Dictionary<string, object> ExtensionConditions { get; set; }

        ///// <summary>
        ///// 【选填项】扩展条件s，以字段名与字段值的键值对形式呈现
        ///// </summary>
        //[JsonProperty("query")]
        //public string _extensionConditions => JsonConvert.SerializeObject(ExtensionConditions);
    }
}
