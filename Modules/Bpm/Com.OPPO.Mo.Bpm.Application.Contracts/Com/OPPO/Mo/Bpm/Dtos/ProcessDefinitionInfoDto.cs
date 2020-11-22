using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.Dtos
{
    /// <summary>
    /// 流程定义信息Dto
    /// </summary>
    public class ProcessDefinitionInfoDto
    {
        /// <summary>
        /// 流程定义Id
        /// </summary>
        [JsonRequired]
        public string ProcessDefinitionId { get; set; }

        /// <summary>
        /// 流程名称
        /// </summary>
        public string ProcessName { get; set; }

        /// <summary>
        /// 所属应用Id
        /// </summary>
        public string AppId { get; set; }
    }
}
