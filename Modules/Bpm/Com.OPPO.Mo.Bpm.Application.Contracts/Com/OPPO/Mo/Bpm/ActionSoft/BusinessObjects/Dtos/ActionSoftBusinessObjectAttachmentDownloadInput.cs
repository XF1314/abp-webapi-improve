﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Dtos
{
    /// <summary>
    /// ActionSoft业务附件下载Input
    /// </summary>
    public class ActionSoftBusinessObjectAttachmentDownloadInput
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
