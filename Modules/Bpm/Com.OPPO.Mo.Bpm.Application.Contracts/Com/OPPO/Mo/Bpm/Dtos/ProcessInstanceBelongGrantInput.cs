using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.Dtos
{
    /// <summary>
    /// 流程实例归属授予Input
    /// </summary>
    public class ProcessInstanceBelongGrantInput
    {
        /// <summary>
        /// 流程实例Id
        /// </summary>
        [JsonRequired]
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 应用Id
        /// </summary>
        [JsonRequired]
        public string AppId { get; set; }
    }
}
