using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Requests
{
    /// <summary>
    /// ActionSoft通过业务标识获取Eai任务Request
    /// </summary>
    public class ActionSoftEaiTaskGetByBizIdRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftEaiTaskGetByBizIdRequest"/>
        /// </summary>
        public ActionSoftEaiTaskGetByBizIdRequest() : base(ActionSoftTaskCommands.EaiTaskGetByBizId)
        {

        }

        /// <summary>
        /// 【必填项】业务系统名称
        /// </summary>
        [JsonRequired]
        [JsonProperty("applicationName")]
        public string AppName { get; set; }

        /// <summary>
        /// 【必填项】Eai任务业务标识(由业务系统提供)
        /// </summary>
        [JsonRequired]
        [JsonProperty("outerId")]
        public string EaiTaskBizId { get; set; }
    }
}
