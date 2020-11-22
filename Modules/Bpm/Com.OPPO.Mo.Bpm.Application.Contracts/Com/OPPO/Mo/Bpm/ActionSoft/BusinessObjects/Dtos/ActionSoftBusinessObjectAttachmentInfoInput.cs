using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Dtos
{
    /// <summary>
    /// ActionSoft业务附件信息Input
    /// </summary>
    public class ActionSoftBusinessObjectAttachmentInfoInput
    {
        /// <summary>
        /// 附件Id，为空则新增业务附件，不空则更新业务附件
        /// </summary>
        public string AttachmentId { get; set; }

        /// <summary>
        /// 【必填项】应用Id，对应ActionSoft中的应用Id
        /// </summary>
        [JsonRequired]
        public string AppId { get; set; }

        /// <summary>
        /// 【必填项】业务对象表名称
        /// </summary>
        [JsonRequired]
        public string BusinessObjectTableName { get; set; }

        /// <summary>
        /// 【必填项】流程实例Id
        /// </summary>
        [JsonRequired]
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 【必填项】任务实例Id
        /// </summary>
        [JsonRequired]
        public string TaskInstanceId { get; set; }

        /// <summary>
        /// 【必填项】业务对象Id，对应ActionSoft业务对象表中的Id
        /// </summary>
        [JsonRequired]
        public string BusinessObjectId { get; set; }

        /// <summary>
        /// 【必填项】业务对象字段名称，对应ActionSoft业务对象表中的字段
        /// </summary>
        [JsonRequired]
        public string BusinessObjectFieldName { get; set; }

        /// <summary>
        /// 【必填项】附件名称，用于附件展示，需要带扩展名
        /// </summary>
        [JsonRequired]
        public string AttachmentName { get; set; }

        /// <summary>
        /// 【选填项】附件备注，会在用户侧呈现
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 【必填项】操作人工号
        /// </summary>
        [JsonRequired]
        public string OperatorUserCode { get; set; }
    }
}
