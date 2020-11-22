using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.Dtos
{
    /// <summary>
    /// 流程发起权限批量新增/更新Input
    /// </summary>
    public class ProcessLaunchPermissionBatchGrantInput
    {
        /// <summary>
        /// <see cref="ProcessLaunchPermissionBatchGrantInput"/>
        /// </summary>
        public ProcessLaunchPermissionBatchGrantInput()
        {
            ProcesseDefinitions = new Dictionary<string, string> { };
        }

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
        /// 【必填项】流程s，Key-ProcessDefinitionId，Value-ProcessName
        /// </summary>
        [JsonRequired]
        public Dictionary<string, string> ProcesseDefinitions { get; set; }
    }
}
