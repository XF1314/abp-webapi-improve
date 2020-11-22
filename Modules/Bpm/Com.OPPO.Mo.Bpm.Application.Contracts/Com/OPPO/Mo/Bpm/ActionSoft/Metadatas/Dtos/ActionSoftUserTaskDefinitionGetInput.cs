using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Metadatas.Dtos
{
    /// <summary>
    /// ActionSoft人工任务定义获取Input
    /// </summary>
    public class ActionSoftUserTaskDefinitionGetInput
    {
        /// <summary>
        /// 【必填项】流程定义Id
        /// </summary>
        [JsonRequired]
        public string ProcessDefinitionId { get; set; }

        /// <summary>
        /// 【必填项】人工任务定义Id
        /// </summary>
        [JsonRequired]
        public string UserTaskDefinitionId { get; set; }
    }
}
