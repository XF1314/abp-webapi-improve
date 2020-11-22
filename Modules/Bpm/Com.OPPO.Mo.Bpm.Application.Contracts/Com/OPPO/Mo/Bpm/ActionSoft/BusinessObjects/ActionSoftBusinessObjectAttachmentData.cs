using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects
{
    /// <summary>
    /// ActionSoft业务附件数据
    /// </summary>
    public class ActionSoftBusinessObjectAttachmentData
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        [JsonProperty("name")]
        public string AttachmentName { get; set; }

        /// <summary>
        /// 文件内容
        /// </summary>
        [JsonProperty("content")]
        public byte[] AttachmentContent { get; set; }

    }
}
