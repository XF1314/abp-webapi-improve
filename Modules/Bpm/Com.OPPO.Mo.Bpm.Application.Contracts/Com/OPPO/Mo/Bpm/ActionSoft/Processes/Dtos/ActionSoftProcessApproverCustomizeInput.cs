using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes.Dtos
{
    /// <summary>
    /// ActionSoft流程审批人自定义Input
    /// </summary>
    public class ActionSoftProcessApproverCustomizeInput
    {
        /// <summary>
        /// <see cref="ActionSoftProcessApproverCustomizeInput"/>
        /// </summary>
        public ActionSoftProcessApproverCustomizeInput()
        {
            ActivityApprovers = new List<ActivityApprover>();
        }

        /// <summary>
        /// 【必填项】流程实例Id
        /// </summary>
        [JsonRequired]
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 【必填项】环节审批人s
        /// </summary>
        [JsonRequired]
        public List<ActivityApprover> ActivityApprovers { get; set; }

    }

    /// <summary>
    /// 环节审批人
    /// </summary>
    public class ActivityApprover
    {
        /// <summary>
        /// <see cref="ActivityApprover"/>
        /// </summary>
        public ActivityApprover()
        {
            ApproverUserCodes = new List<string>();
        }

        /// <summary>
        /// 【必填项】任务定义Id
        /// </summary>
        [JsonRequired]
        public string TaskDefinitionId { get; set; }

        /// <summary>
        /// 【必填项】审批人工号s
        /// </summary>
        [JsonRequired]
        public List<string> ApproverUserCodes { get; set; }

    }


}
