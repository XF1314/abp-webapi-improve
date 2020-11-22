using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Requests
{
    /// <summary>
    /// ActionSoftActionSoft通过业务标识删除Eai任务请求Dto
    /// </summary>
    public class ActionSoftEaiTaskDeleteByBizIdRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftEaiTaskDeleteByBizIdRequest"/>
        /// </summary>
        public ActionSoftEaiTaskDeleteByBizIdRequest() : base(ActionSoftTaskCommands.EaiTaskDeleteByBizId)
        { }

        /// <summary>
        ///【必填项】应用系统简称，最长36个字符
        /// </summary>
        [JsonRequired]
        [JsonProperty("applicationName")]
        public string AppName { get; set; }

        /// <summary>
        ///【必填项】Eai任务业务标识（由业务系统提供）
        /// </summary>
        [JsonRequired]
        [JsonProperty("outerId")]
        public string EaiTaskBizId { get; set; }
    }
}
