using Com.OPPO.Mo.Bpm.ActionSoft.Processes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.Dtos
{
    /// <summary>
    /// 流程实例信息Dto
    /// </summary>
    public class ProcessInstanceInfoDto
    {
        /// <summary>
        /// 【必填项】流程实例Id
        /// </summary>
        [JsonRequired]
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 流程Title
        /// </summary>
        public string ProcessTitle { get; set; }

        /// <summary>
        /// ActionSoft流程状态（系统）<see cref="ActionSoftProcessControlState"/>
        /// </summary>
        public string ProcessControlState { get; set; }
    }
}
