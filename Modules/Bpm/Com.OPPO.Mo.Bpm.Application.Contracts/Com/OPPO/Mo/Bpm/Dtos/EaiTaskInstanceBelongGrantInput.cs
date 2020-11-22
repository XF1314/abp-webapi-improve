using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.Dtos
{
    /// <summary>
    /// Eai任务实例归属授予Input
    /// </summary>
    public class EaiTaskInstanceBelongGrantInput
    {
        /// <summary>
        /// 【必填项】Eai任务实例Id
        /// </summary>
        [JsonRequired]
        public string EaiTaskInstanceId { get; set; }

        /// <summary>
        /// 【必填项】应用Id
        /// </summary>
        [JsonRequired]
        public string AppId { get; set; }

    }
}
