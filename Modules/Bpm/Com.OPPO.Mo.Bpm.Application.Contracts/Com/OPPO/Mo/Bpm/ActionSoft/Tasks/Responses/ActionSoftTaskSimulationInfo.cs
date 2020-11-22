using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Responses
{
    /// <summary>
    /// ActionSoft任务模拟后继路径信息
    /// </summary>
    public class ActionSoftTaskSimulationInfo
    {
        /// <summary>
        /// 即将到达的任务实例Id
        /// </summary>
        [JsonProperty("id")]
        public string TaskInstanceId { get; set; }

        /// <summary>
        /// <see cref="ActionSoftActivityType"/>
        /// </summary>
        [JsonProperty("type")]
        public ActionSoftActivityType ActivityType { get; set; } 

        /// <summary>
        /// 参数1
        /// </summary>
        [JsonProperty("para1")]
        public string Parameter1 { get; set; }

        /// <summary>
        /// 参数2
        /// </summary>
        [JsonProperty("para2")]
        public string Parameter2 { get; set; }

    }
}
