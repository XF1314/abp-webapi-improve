using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects
{
    /// <summary>
    /// ActionSoft业务附件信息
    /// </summary>
    public class ActionSoftBusinessObjectAttachmentInfo
    {
        /// <summary>
        /// 应用Id，对应ActionSoft中的微应用
        /// </summary>
        [JsonProperty("appId")]
        public string AppId { get; set; }

        /// <summary>
        /// 业务对象表名称
        /// </summary>
        [JsonProperty("boName")]
        public string BusinessObjectTableName { get; set; }

        /// <summary>
        /// 流程实例Id
        /// </summary>
        [JsonProperty("processInstId")]
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 任务实例Id
        /// </summary>
        [JsonProperty("taskInstId")]
        public string TaskInstanceId { get; set; }

        /// <summary>
        /// 业务对象Id，对应ActionSoft业务对象表中的Id
        /// </summary>
        [JsonProperty("boId")]
        public string BusinessObjectId { get; set; }

        /// <summary>
        /// 业务对象字段名称，对应ActionSoft业务对象表中的字段
        /// </summary>
        [JsonProperty("boItemName")]
        public string BusinessObjectFieldName { get; set; }

        /// <summary>
        /// 附件Id
        /// </summary>
        [JsonProperty("id")]
        public string AttachmentId { get; set; }

        /// <summary>
        /// 附件名称，用于附件展示
        /// </summary>
        [JsonProperty("name")]
        public string AttachmentName { get; set; }

        /// <summary>
        /// 附件大小
        /// </summary>
        [JsonProperty("fileSize")]
        public long? AttachmentSize { get; set; }

        /// <summary>
        /// 附件备注，会在用户侧呈现
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建人工号
        /// </summary>
        [JsonProperty("createUser")]
        public string OperatorUserCode { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonProperty("createDate")]
        [JsonConverter(typeof(DateTimeMillisecondConverter))]
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
