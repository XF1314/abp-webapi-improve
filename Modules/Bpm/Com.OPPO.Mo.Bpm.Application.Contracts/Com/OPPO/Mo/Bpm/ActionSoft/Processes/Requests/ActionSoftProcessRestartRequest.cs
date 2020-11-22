using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Processes.Requests
{
    /// <summary>
    /// ActionSoft流程重置
    /// 通过id重置流程到第一个节点，将任务创建给流程启动者，
    /// 等同于由启动者撤销重办业务（适用于开始事件后是UserTask的人工流程）。
    /// 撤销操作将删除令牌、 所有待办已办任务等流程数据， 
    /// 如果给定了reStartReason值 ，将撤销原因初始化成审批记录。如果该流程启动了子流程一并将子流程删除
    /// </summary>
    public class ActionSoftProcessRestartRequest:BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftProcessRestartRequest"/>
        /// </summary>
        public ActionSoftProcessRestartRequest() : base(ActionSoftProcessCommands.ProcessRestart)
        { }

        /// <summary>
        /// 【必填项】流程实例Id
        /// </summary>
        [JsonRequired]
        [JsonProperty("processInstId")]
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 【必填项】重新启动原因
        /// </summary>
        [JsonRequired]
        public string RestartReason { get; set; }

    }
}
