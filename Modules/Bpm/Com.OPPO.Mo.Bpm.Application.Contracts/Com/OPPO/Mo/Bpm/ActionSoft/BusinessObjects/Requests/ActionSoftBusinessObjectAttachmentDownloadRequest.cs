using Com.OPPO.Mo.Bpm.BusinessObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Requests
{
    /// <summary>
    /// ActionSoft业务附件下载Request
    /// </summary>
    public class ActionSoftBusinessObjectAttachmentDownloadRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftBusinessObjectAttachmentDownloadRequest"/>
        /// </summary>
        public ActionSoftBusinessObjectAttachmentDownloadRequest() : base(ActionSoftBusinessObjectCommands.BusinessObjectAttachmentDownload)
        { 
        
        }

        /// <summary>
        /// 【必填项】附件Id
        /// </summary>
        [JsonRequired]
        [JsonProperty("fileId")]
        public string AttachmentId { get; set; }
    }
}
