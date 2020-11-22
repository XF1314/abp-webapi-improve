using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft
{
    /// <summary>
    /// ActionSoft活动类型
    /// </summary>
    public enum ActionSoftActivityType
    {
        /// <summary>
        /// 业务规则任务
        /// </summary>
        [Description("业务规则任务")]
        BusinessRuleTask,

        /// <summary>
        /// 调用活动
        /// </summary>
        [Description("调用活动")]
        CallActivity,

        /// <summary>
        /// 捕获事件
        /// </summary>
        [Description("捕获事件")]
        CatchEvent,

        /// <summary>
        /// 一种非工作流引擎的外部任务，用于统一企业工作中心的方案
        /// </summary>
        [Description("EAI任务")]
        EAI,

        /// <summary>
        /// 结束任务
        /// </summary>
        [Description("结束任务")]
        EndEvent,

        /// <summary>
        /// 脚本任务
        /// </summary>
        [Description("脚本任务")]
        ScriptTask,

        /// <summary>
        /// 服务任务
        /// </summary>
        [JsonProperty("服务任务")]
        ServiceTask,

        /// <summary>
        /// 抛出事件
        /// </summary>
        [JsonProperty("抛出事件")]
        ThrowEvent,

        /// <summary>
        /// 人工任务
        /// </summary>
        [JsonProperty("人工任务")]
        UserTask

    }
}
