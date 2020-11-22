using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Dtos
{
    /// <summary>
    /// ActionSoft业务附件数据Dto
    /// </summary>
    public class ActionSoftBusinessObjectAttachmentDataDto
    {
        /// <summary>
        /// 附件名称
        /// </summary>
        public string AttachmentName { get; set; }

        /// <summary>
        /// 附件内容
        /// </summary>
        public byte[] AttachmentContent { get; set; }
    }
}
