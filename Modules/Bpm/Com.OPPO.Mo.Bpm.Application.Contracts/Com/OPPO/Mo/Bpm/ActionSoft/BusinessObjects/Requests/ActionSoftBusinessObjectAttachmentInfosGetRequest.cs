using Com.OPPO.Mo.Bpm.BusinessObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Requests
{
    /// <summary>
    /// ActionSoft业务附件信息s获取Request
    /// </summary>
    public class ActionSoftBusinessObjectAttachmentInfosGetRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftBusinessObjectAttachmentInfosGetRequest"/>
        /// </summary>
        public ActionSoftBusinessObjectAttachmentInfosGetRequest() : base(ActionSoftBusinessObjectCommands.BusinessOjecAttachmentsGetByField)
        {

        }

        /// <summary>
        /// 业务对象Id
        /// </summary>
        [JsonRequired]
        [JsonProperty("boId")]
        public string BusinessObjectId { get; set; }

        /// <summary>
        /// 业务对象字段名称
        /// </summary>
        [JsonRequired]
        [JsonProperty("fieldName")]
        public string BusinessObjectFieldName { get; set; }

    }
}
