using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.Dtos
{
    /// <summary>
    /// 流程发起权限授予Input
    /// </summary>
    public class ProcessLaunchPermissionGrantInput
    {
        /// <summary>
        /// 【必填项】应用Id
        /// </summary>
        [JsonRequired]
        public string AppId { get; set; }

        /// <summary>
        /// 【必填项】应用名称
        /// </summary>
        [JsonRequired]
        public string AppName { get; set; }

        /// <summary>
        /// 【必填项】流程定义Id
        /// </summary>
        [JsonRequired]
        public string ProcessDefinitionId { get; set; }

        /// <summary>
        /// 【必填项】流程名称
        /// </summary>
        [JsonRequired]
        public string ProcessName { get; set; }
    }
}
