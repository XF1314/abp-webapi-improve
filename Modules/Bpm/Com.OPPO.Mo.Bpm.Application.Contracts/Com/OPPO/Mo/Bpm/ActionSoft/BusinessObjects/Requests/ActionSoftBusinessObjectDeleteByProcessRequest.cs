using Com.OPPO.Mo.Bpm.BusinessObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Requests
{
    /// <summary>
    /// ActionSoft业务记录按流程删除Request
    /// </summary>
    public class ActionSoftBusinessObjectDeleteByProcessRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftBusinessObjectDeleteByProcessRequest"/>
        /// </summary>
        public ActionSoftBusinessObjectDeleteByProcessRequest() : base(ActionSoftBusinessObjectCommands.BusinessObjectDeleteByProcess)
        { }

        /// <summary>
        /// 【必填项】业务对象表名称
        /// </summary>
        [JsonRequired]
        [JsonProperty("boName")]
        public string BusinessObjectTableName { get; set; }

        /// <summary>
        /// 【必填项】绑定的流程实例Id
        /// </summary>
        [JsonRequired]
        [JsonProperty("bindId")]
        public string ProcessInstanceId { get; set; }

    }
}
