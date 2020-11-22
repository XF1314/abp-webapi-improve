using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Dtos
{
    /// <summary>
    /// ActionSoft业务附件信息Dto
    /// </summary>
    public class ActionSoftBusinessObjectAttachmentInfoDto
    {
        /// <summary>
        /// 应用Id，对应ActionSoft中的应用
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 业务对象表名称
        /// </summary>
        public string BusinessObjectTableName { get; set; }

        /// <summary>
        /// 流程实例Id
        /// </summary>
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 任务实例Id
        /// </summary>
        public string TaskInstanceId { get; set; }

        /// <summary>
        /// 业务对象Id，对应ActionSoft业务对象表中的Id
        /// </summary>
        public string BusinessObjectId { get; set; }

        /// <summary>
        /// 业务对象字段名称，对应ActionSoft业务对象表中的字段
        /// </summary>
        public string BusinessObjectFieldName { get; set; }

        /// <summary>
        /// 附件Id
        /// </summary>
        public string AttachmentId { get; set; }

        /// <summary>
        /// 附件名称，用于附件展示
        /// </summary>
        public string AttachmentName { get; set; }

        /// <summary>
        /// 附件大小
        /// </summary>
        public long? AttachmentSize { get; set; }

        /// <summary>
        /// 附件备注，会在用户侧呈现
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 操作人工号
        /// </summary>
        public string OperatorUserCode { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
