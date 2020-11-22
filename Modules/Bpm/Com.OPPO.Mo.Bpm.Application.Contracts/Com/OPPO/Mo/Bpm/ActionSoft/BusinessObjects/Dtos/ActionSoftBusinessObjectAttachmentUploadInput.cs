using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Dtos
{
    /// <summary>
    /// AcionSoft业务附件上传Input
    /// </summary>
    public class ActionSoftBusinessObjectAttachmentUploadInput : ActionSoftBusinessObjectAttachmentInfoInput
    {
        /// <summary>
        /// 附件地址，需保证访问权限
        /// PS：附件最大支持50M
        /// </summary>
        [JsonRequired]
        public Uri AttachmentUri { get; set; }

    }
}
