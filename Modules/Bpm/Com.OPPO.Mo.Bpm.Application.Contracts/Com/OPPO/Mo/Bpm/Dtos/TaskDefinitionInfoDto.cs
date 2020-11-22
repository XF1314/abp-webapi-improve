using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.Dtos
{
    /// <summary>
    /// 流程任务定义信息Dto
    /// </summary>
    public class TaskDefinitionInfoDto
    {
        /// <summary>
        /// 【必填项】任务定义Id
        /// </summary>
        [JsonRequired]
        public string TaskDefinitionId { get; set; }

        /// <summary>
        /// 任务名称
        /// </summary>
        public string TaskName { get; set; }
    }
}
