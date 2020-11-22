using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes.Dtos
{
    /// <summary>
    /// ActionSoft流程创建Input
    /// </summary>
    public class ActionSoftProcessCreateInput
    {
        /// <summary>
        /// <see cref="ActionSoftProcessCreateInput"/>
        /// </summary>
        public ActionSoftProcessCreateInput()
        {
            ProcessVars = new Dictionary<string, string>();
            ActivityApprovers = new List<ActivityApprover>();
        }

        /// <summary>
        /// 【必填项】流程定义Id
        /// </summary>
        [JsonRequired]
        public string ProcessDefinitionId { get; set; }

        /// <summary>
        /// 【必填项】流程标题
        /// </summary>
        [JsonRequired]
        public string ProcessTitle { get; set; }

        /// <summary>
        /// 【选填项】流程实例编码，如果不填写则使用系统默认生成的流程实例编码
        /// 外部业务系统数据主键标识值或一个组合值，在工作流引擎实例表中全局不能重复
        /// </summary>
        public string ProcessInstanceCode { get; set; }

        /// <summary>
        /// 【选填项】流程变量s
        /// </summary>
        public Dictionary<string, string> ProcessVars { get; set; }

        /// <summary>
        /// 【选填项】环节审批人s
        /// </summary>
        public List<ActivityApprover> ActivityApprovers { get; set; }

        /// <summary>
        /// 【必填项】拟制人工号
        /// </summary>
        [JsonRequired]
        public string CreatorUserCode { get; set; }
    }
}
