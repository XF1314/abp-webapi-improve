using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes.Dtos
{
    /// <summary>
    /// ActionSoft流程数量获取Input
    /// </summary>
    public class ActionSoftProcessCountGetInput
    {
        /// <summary>
        /// <see cref="ActionSoftProcessCountGetInput"/>
        /// </summary>
        public ActionSoftProcessCountGetInput() 
        {
            ExtensionConditions = new Dictionary<string, object>();
        }

        #region 流程实例
        /// <summary>
        /// 【选填项】一组流程实例Id
        /// </summary>
        public List<string> ProcessInstanceIds { get; set; }

        /// <summary>
        /// 【选填项】一组流程实例Code
        /// </summary>
        public List<string> ProcessInstanceCodes { get; set; }

        /// <summary>
        /// 【选填项】父流程实例Id，用于通过父流程实例Id查所有的子流程实例
        /// </summary>
        public string ParentProcessInstanceId { get; set; }

        /// <summary>
        /// 【选填项】父流程实例中的任务实例Id，用于通过任务实例Id查由当前任务创建的子流程实例
        /// </summary>
        public string ParentTaskInstanceId { get; set; }

        /// <summary>
        /// 【选填项】流程标题
        /// </summary>
        public string ProcessTitle { get; set; }

        /// <summary>
        /// 【选填项】流程备注（模糊匹配）
        /// </summary>
        public string ProcessRemark { get; set; }

        /// <summary>
        /// 【选填项】是否BO(DW的仅存储)流程
        /// </summary>
        public bool? IsBoProcess { get; set; }

        /// <summary>
        /// 【选填项】是否Short(编排)流程
        /// </summary>
        public bool? IsShortProcess { get; set; }

        /// <summary>
        /// 【选填项】是否子流程
        /// </summary>
        public bool? IsSubProcess { get; set; }

        /// <summary>
        /// 【选填项】是否活动流程
        /// </summary>
        public bool? IsActiveProcess { get; set; }

        /// <summary>
        /// 【选填项】是否已启动流程
        /// </summary>
        public bool? IsStartedProcess { get; set; }

        /// <summary>
        /// 【选填项】是否已取消流程
        /// </summary>
        public bool? IsCanceledProcess { get; set; }

        /// <summary>
        /// 【选填项】是否包含子流程
        /// </summary>
        public bool? IsExistSubProcess { get; set; }

        /// <summary>
        /// 【选填项】是否已挂起流程
        /// </summary>
        public bool? IsSuspendedProcess { get; set; }

        /// <summary>
        /// 【选填项】是否已结束流程
        /// </summary>
        public bool? IsTerminatedProcess { get; set; }

        /// <summary>
        /// 【选填项】是否未启动流程
        /// </summary>
        public bool? IsUnStartedProcess { get; set; }

        /// <summary>
        /// 【选填项】拟制人工号
        /// </summary>
        public string CreatorUserCode { get; set; }
        #endregion

        #region 流程定义
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
        /// 【选填项】流程实例所属系统分类
        /// </summary>
        public string SystemClassify { get; set; }

        /// <summary>
        /// 【选填项】流程定义Id
        /// </summary>
        public string ProcessDefinitionId { get; set; }

        /// <summary>
        /// 【选填项】流程定义版本Id
        /// </summary>
        public string ProcessDefinitionVersionId { get; set; }

        /// <summary>
        /// 【选填项】流程组Id
        /// </summary>
        public string ProcessGroupId { get; set; }

        /// <summary>
        /// 【选填项】一组流程组Id
        /// </summary>
        public List<string> ProcessGroupIds { get; set; }
        #endregion

        /// <summary>
        /// 【选填项】创建时间From
        /// </summary>
        public DateTime? CreateTimeFrom { get; set; }

        /// <summary>
        /// 【选填项】创建时间To
        /// </summary>
        public DateTime? CreateTimeTo { get; set; }

        /// <summary>
        /// 【选填项】完成时间From
        /// </summary>
        public DateTime? FinishTimeFrom { get; set; }

        /// <summary>
        /// 【选填项】完成时间To
        /// </summary>
        public DateTime? FinishTimeTo { get; set; }

        /// <summary>
        /// 【选填项】扩展条件s，以字段名与字段值的键值对形式呈现
        /// </summary>
        public Dictionary<string, object> ExtensionConditions { get; set; }
    }
}
