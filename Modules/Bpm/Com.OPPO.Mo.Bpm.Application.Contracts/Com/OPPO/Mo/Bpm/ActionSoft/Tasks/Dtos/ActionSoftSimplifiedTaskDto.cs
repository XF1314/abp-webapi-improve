using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Dtos
{
    /// <summary>
    /// 简化的ActionSoft任务Dto
    /// </summary>
    public class ActionSoftSimplifiedTaskDto
    {
        /// <summary>
        /// 流程实例Id
        /// </summary>
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 任务实例Id
        /// </summary>
        public string TaskInstanceId { get; set; }

        /// <summary>
        /// 任务定义Id
        /// </summary>
        public string TaskDefinitionId { get; set; }

        /// <summary>
        /// 任务标题
        /// </summary>
        public string TaskTitle { get; set; }

        /// <summary>
        /// 任务创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// <see cref="ActionSoftTaskType"/>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ActionSoftTaskType TaskType { get; set; }

        /// <summary>
        /// <see cref="ActionSoftPriority"/>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ActionSoftPriority Priority { get; set; }

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
