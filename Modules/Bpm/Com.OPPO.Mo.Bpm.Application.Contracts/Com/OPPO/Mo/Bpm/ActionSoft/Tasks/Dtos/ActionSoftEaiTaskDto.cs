using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Dtos
{
    /// <summary>
    /// ActionSoft Eai任务Dto
    /// </summary>
    public class ActionSoftEaiTaskDto
    {
        /// <summary>
        /// Eai任务实例Id
        /// </summary>
        public string EaiTaskInstanceId { get; set; }

        /// <summary>
        /// Eai任务业务Id
        /// </summary>
        public string EaiTaskBizId { get; set; }

        /// <summary>
        /// Eai任务的系统简称
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// 任务创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 到期时间
        /// </summary>
        public DateTime DueTime { get; set; }

        /// <summary>
        /// 是否是已结束的历史任务
        /// </summary>
        public bool IsHistoryTask { get; set; }

        /// <summary>
        /// 任务标题
        /// </summary>
        public string EaiTaskTitle { get; set; }

        /// <summary>
        /// Eai任务的业务Url，如果非Eai任务则返回空
        /// </summary>
        public string EaiTaskBizUrl { get; set; }

        /// <summary>
        /// <see cref="ActionSoftPriority"/>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ActionSoftPriority Priority { get; set; }

        /// <summary>
        /// 认领人工号
        /// </summary>
        public string ClaimToUserCode { get; set; }

        /// <summary>
        /// 查看状态（0:未读,1:已读）
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ActionSoftReadState ReadState { get; set; }

        /// <summary>
        /// 查看时间,如果未读或该任务非人工任务/Eai外部任务，返回Null
        /// </summary>
        public DateTime? ReadTime { get; set; } = null;

        /// <summary>
        /// 应用名称
        /// </summary>
        public string AppName { get; set; }

        /// <summary>
        /// 在待办中构建和点击该任务时，该任务提供的配置参数
        /// </summary>
        public string ActionParams { get; set; }

        /// <summary>
        /// 流程实例所属业务域分类，Instance Of Business Domain
        /// </summary>
        public string BusinessDomainClassify { get; set; }

        /// <summary>
        /// 流程实例所属自定义分类，Instance Of Customize
        /// </summary>
        public string CustomizeClassify { get; set; }

        /// <summary>
        /// 流程实例所属组织区域分类，Instance Of Regional
        /// </summary>
        public string RegionalClassify { get; set; }

        /// <summary>
        /// 流程实例所属系统分类，Instance Of System
        /// </summary>
        public string SystemClassify { get; set; }
    }
}
