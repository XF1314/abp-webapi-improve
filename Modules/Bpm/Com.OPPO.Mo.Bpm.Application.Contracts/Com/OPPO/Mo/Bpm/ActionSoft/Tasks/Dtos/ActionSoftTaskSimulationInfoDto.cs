using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Dtos
{
    /// <summary>
    /// ActionSoft任务模拟后继路径信息Dto
    /// </summary>
    public class ActionSoftTaskSimulationInfoDto
    {
        /// <summary>
        /// 即将到达的任务实例Id
        /// </summary>
        public string TaskInstanceId { get; set; }

        /// <summary>
        /// <see cref="ActionSoftActivityType"/>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ActionSoftActivityType ActivityType { get; set; }

        /// <summary>
        /// 参数1
        /// </summary>
        public string Parameter1 { get; set; }

        /// <summary>
        /// 参数2
        /// </summary>
        public string Parameter2 { get; set; }
    }
}
