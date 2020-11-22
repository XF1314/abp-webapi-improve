using Com.OPPO.Mo.Bpm.BusinessObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Requests
{
    /// <summary>
    /// ActionSoft业务附件s移除Request
    /// </summary>
    public class ActionSoftBusinessObjectAttachmentsRemoveRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftBusinessObjectAttachmentsRemoveRequest"/>
        /// </summary>
        public ActionSoftBusinessObjectAttachmentsRemoveRequest() : base(ActionSoftBusinessObjectCommands.BusinessObjectAttachmentRemoveByField)
        { }

        /// <summary>
        /// 【必填项】业务对象Id
        /// </summary>
        [JsonRequired]
        [JsonProperty("boId")]
        public string BusinessObjectId { get; set; }

        /// <summary>
        /// 【必填项】业务对象字段名称
        /// </summary>
        [JsonRequired]
        [JsonProperty("fieldName")]
        public string BusinessObjectFieldName { get; set; }

    }
}
