using Com.OPPO.Mo.Bpm.BusinessObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Requests
{
    /// <summary>
    /// ActionSoft业务附件Request
    /// </summary>
    public class ActionSoftBusinessObjectAttachmentUploadRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftBusinessObjectAttachmentUploadRequest"/>
        /// </summary>
        public ActionSoftBusinessObjectAttachmentUploadRequest() : base(ActionSoftBusinessObjectCommands.BusinessObjectAttachmentUpload)
        {

        }

        /// <summary>
        /// <see cref="ActionSoftBusinessObjectAttachmentInfo"/>
        /// </summary>
        [JsonIgnore]
        public ActionSoftBusinessObjectAttachmentInfo AttachmentInfo { get; set; }

        /// <summary>
        /// <see cref="ActionSoftBusinessObjectAttachmentInfo"/>
        /// </summary>
        [JsonProperty("formFileModel")]
        private string attachmentInfo => JsonConvert.SerializeObject(AttachmentInfo,Formatting.None);

        /// <summary>
        /// <see cref="ActionSoftBusinessObjectAttachmentData"/>
        /// </summary>
        [JsonIgnore]
        public ActionSoftBusinessObjectAttachmentData AttachmentData { get; set; }

        /// <summary>
        /// <see cref="ActionSoftBusinessObjectAttachmentData"/>
        /// </summary>
        [JsonProperty("data")]
        private string attachmentData => JsonConvert.SerializeObject(AttachmentData,Formatting.None);
    }
}
