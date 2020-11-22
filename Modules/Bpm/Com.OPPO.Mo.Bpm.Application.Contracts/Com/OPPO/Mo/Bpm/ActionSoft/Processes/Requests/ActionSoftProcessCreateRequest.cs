using Com.OPPO.Mo.Bpm.ActionSoft.Processes.Dtos;
using Com.OPPO.Mo.Bpm.ActionSoft.Processes.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes.Requests
{
    /// <summary>
    /// ActionSoft流程创建Request
    /// </summary>
    public class ActionSoftProcessCreateRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftProcessCreateRequest"/>
        /// </summary>
        public ActionSoftProcessCreateRequest() : base(ActionSoftProcessCommands.ProcessCreate)
        {
            ProcessVars = new Dictionary<string, string>();
        }

        /// <summary>
        /// 【必填项】流程定义Id
        /// </summary>
        [JsonRequired]
        [JsonProperty("processDefId")]
        public string ProcessDefinitionId { get; set; }

        /// <summary>
        /// 【必填项】流程标题
        /// </summary>
        [JsonRequired]
        [JsonProperty("title")]
        public string ProcessTitle { get; set; }

        /// <summary>
        /// 【必填项】拟制人工号
        /// </summary>
        [JsonRequired]
        [JsonProperty("uid")]
        public string CreatorUserCode { get; set; }

        /// <summary>
        /// 【选填项】流程实例编码，如果不填写则使用系统默认生成的流程实例编码
        /// 外部业务系统数据主键标识值或一个组合值，在工作流引擎实例表中全局不能重复
        /// </summary>
        [JsonProperty("processBusinessKey")]
        public string ProcessInstanceCode { get; set; }

        /// <summary>
        /// 【选填项】<see cref="ActionSoftProcessType"/>，其值为
        /// 空：<see cref="ActionSoftProcessInfo.ProcessInstanceCode"/>返回<see cref="ActionSoftProcessInfo.ProcessInstanceId"/>
        /// <see cref="ActionSoftProcessType.D"/>：<see cref="ActionSoftProcessInfo.ProcessInstanceCode"/>返回资讯类编码
        /// <see cref="ActionSoftProcessType.P"/>：<see cref="ActionSoftProcessInfo.ProcessInstanceCode"/>返回流程类编码
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ActionSoftProcessType? ProcessType { get; set; } = ActionSoftProcessType.P;

        /// <summary>
        /// 【选填项】流程变量s
        /// </summary>
        [JsonIgnore]
        public Dictionary<string, string> ProcessVars { get; set; }

        /// <summary>
        /// 【选填项】流程变量s
        /// </summary>
        [JsonProperty("vars")]
        private string processVars => JsonConvert.SerializeObject(ProcessVars);

        ///// <summary>
        ///// 【选填项】环节审批人
        ///// </summary>
        //[JsonIgnore]
        //private List<ActivityApprover> ActivityApprovers { get; set; }


    }
}
