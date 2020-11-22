using Com.OPPO.Mo.Bpm.BusinessObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Requests
{
    /// <summary>
    /// ActionSoft业务附件删除Request
    /// </summary>
    public class ActionSoftBusinessObjectAttachmentRemoveRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftBusinessObjectAttachmentRemoveRequest"/>
        /// </summary>
        public ActionSoftBusinessObjectAttachmentRemoveRequest() : base(ActionSoftBusinessObjectCommands.BusinessObjectAttachmentRemove)
        { }

        /// <summary>
        /// 【必填项】附件Id
        /// </summary>
        [JsonRequired]
        [JsonProperty("AttachmentId")]
        public string AttachmentId { get; set; }
    }
}
