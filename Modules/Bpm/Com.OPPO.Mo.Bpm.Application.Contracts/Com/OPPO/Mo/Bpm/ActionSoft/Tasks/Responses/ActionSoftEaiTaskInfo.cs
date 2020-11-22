using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Responses
{
    /// <summary>
    /// ActionSoft Eai任务信息
    /// </summary>
    public class ActionSoftEaiTaskInfo
    {
        /// <summary>
        /// Eai任务实例Id
        /// </summary>
        [JsonProperty("id")]
        public string EaiTaskInstanceId { get; set; }

        /// <summary>
        /// Eai任务业务Id
        /// </summary>
        [JsonProperty("outerId")]
        public string EaiTaskBizId { get; set; }

        /// <summary>
        /// 创建人工号
        /// </summary>
        [JsonProperty("createUid")]
        public string Owner { get; set; }

        /// <summary>
        /// 任务创建时间
        /// </summary>
        [JsonProperty("beginTime")]
        [JsonConverter(typeof(DateTimeMillisecondConverter))]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 到期时间
        /// </summary>
        [JsonConverter(typeof(DateTimeMillisecondConverter))]
        public DateTime DueTime { get; set; }

        /// <summary>
        /// 是否是已结束的历史任务
        /// </summary>
        [JsonProperty("historyTask")]
        public bool IsHistoryTask { get; set; }

        /// <summary>
        /// 任务标题
        /// </summary>
        [JsonProperty("title")]
        public string EaiTaskTitle { get; set; }

        /// <summary>
        /// Eai任务的业务Url，如果非Eai任务则返回空
        /// </summary>
        [JsonProperty("ext3")]
        public string EaiTaskBizUrl { get; set; }

        /// <summary>
        /// <see cref="ActionSoftPriority"/>
        /// </summary>
        public ActionSoftPriority Priority { get; set; }

        /// <summary>
        /// 认领人工号
        /// </summary>
        [JsonProperty("targetUid")]
        public string ClaimToUserCode { get; set; }

        /// <summary>
        /// 查看状态（0:未读,1:已读）
        /// </summary>
        public ActionSoftReadState ReadState { get; set; }

        /// <summary>
        /// 查看时间
        /// </summary>
        [JsonConverter(typeof(DateTimeMillisecondConverter))]
        public DateTime? ReadTime { get; set; } = null;

        /// <summary>
        /// 应用名称
        /// </summary>
        [JsonProperty("applicationName")]
        public string AppName { get; set; }

        /// <summary>
        /// 在待办中构建和点击该任务时，该任务提供的配置参数
        /// </summary>
        [JsonProperty("actionParameter")]
        public string ActionParams { get; set; }

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
