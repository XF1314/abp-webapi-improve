using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Requests
{
    /// <summary>
    /// ActionSoft Eai任务删除Request
    /// </summary>
    public class ActionSoftEaiTaskDeleteRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftEaiTaskDeleteRequest"/>
        /// </summary>
        public ActionSoftEaiTaskDeleteRequest() : base(ActionSoftTaskCommands.EaiTaskDelete)
        { 
        
        }

        /// <summary>
        /// 【必填项】Eai任务实例Id
        /// </summary>
        [JsonProperty("taskInstId")]
        public string EaiTaskInstanceId { get; set; }

        /// <summary>
        /// 【必填项】操作人工号
        /// </summary>
        [JsonProperty("uid")]
        public string OperatorUserCode { get; set; }
 
    }
}
