using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Dtos
{
    /// <summary>
    /// ActionSoft任务模拟Input
    /// </summary>
    public class ActionSoftTaskSimulateInput
    {
        /// <summary>
        /// 【必填项】合法工号
        /// </summary>
        public string UserCode { get; set; } = MoBpmConsts.ActionSoftAdminUserCode;

        /// <summary>
        /// 【必填项】流程实例Id
        /// </summary>
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 【必填项】任务实例Id
        /// </summary>
        public string TaskInstanceId { get; set; }
    }
}
