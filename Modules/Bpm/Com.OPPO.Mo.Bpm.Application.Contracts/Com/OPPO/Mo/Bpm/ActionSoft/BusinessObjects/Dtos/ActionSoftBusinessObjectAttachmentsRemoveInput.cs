using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Dtos
{
    /// <summary>
    /// ActionSoft业务附件删除Input
    /// </summary>
    public class ActionSoftBusinessObjectAttachmentsRemoveInput
    {
        /// <summary>
        /// 【必填项】业务对象Id
        /// </summary>
        [JsonRequired]
        public string BusinessObjectId { get; set; }

        /// <summary>
        /// 【必填项】附件Id
        /// </summary>
        [JsonRequired]
        public string AttachmentId { get; set; }
    }
}
