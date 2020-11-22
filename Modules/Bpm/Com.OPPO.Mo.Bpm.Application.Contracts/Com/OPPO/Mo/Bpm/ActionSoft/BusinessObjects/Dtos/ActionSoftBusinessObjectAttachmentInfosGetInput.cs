using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Dtos
{
    /// <summary>
    /// ActionSoft业务对象文件信息获取Input
    /// </summary>
    public class ActionSoftBusinessObjectAttachmentInfosGetInput
    {
        /// <summary>
        /// 【必填项】业务对象Id
        /// </summary>
        [JsonRequired]
        public string BusinessObjectId { get; set; }

        /// <summary>
        /// 【必填项】业务对象字段名称
        /// </summary>
        [JsonRequired]
        public string BusinessObjectFieldName { get; set; }
    }
}
