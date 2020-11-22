using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.BusinessObjects
{
    /// <summary>
    /// ActionSoft业务对象相关命令s
    /// </summary>
    public class ActionSoftBusinessObjectCommands
    {
        /// <summary>
        /// 创建业务对象并绑定到流程
        /// </summary>
        public const string BusinessObjectCreateAndBindToProcess = "bo.create";

        /// <summary>
        /// 批量创建业务对象并绑定到流程
        /// </summary>
        public const string BusinessObjectBatchCreateAndBindToProcess = "bo.creates";


        /// <summary>
        /// 根据业务对象Id批量更新业务对象字段，业务对象的Id需要在Map中指定，KEY要求大写
        /// </summary>
        public const string BusinessObjectFieldBatchUpdateByBoId = "bo.update";

        /// <summary>
        /// 按流程更新业务对象字段
        /// </summary>
        public const string BusinessObjectFieldUpdateByProcess = "bo.field.update";

        /// <summary>
        /// 根据业务对象Id获取业务对象
        /// </summary>
        public const string BusinessObjectGetById = "bo.get";

        /// <summary>
        /// 根据业务对象Id获取特定的业务对象字段
        /// </summary>
        public const string BusinessObjectFieldGetById = "bo.value.get";

        /// <summary>
        /// 查询业务对象记录
        /// </summary>
        public const string BusinessObjectQuery = "bo.query";

        /// <summary>
        /// 删除与流程相关的业务对象
        /// </summary>
        public const string BusinessObjectDeleteByProcess = "bo.remove.bindId";

        /// <summary>
        /// 根据业务对象Id删除业务对象
        /// </summary>
        public const string BusinessObjectDeleteById = "bo.remove";

        /// <summary>
        /// 上传文件并绑定到业务附件字段
        /// </summary>
        public const string BusinessObjectAttachmentUpload = "bo.file.up";

        /// <summary>
        /// 获取业务附件字段上所绑定的附件信息s
        /// </summary>
        public const string BusinessOjecAttachmentsGetByField = "bo.files.get";

        /// <summary>
        /// 下载业务附件
        /// </summary>
        public const string BusinessObjectAttachmentDownload = "bo.file.down";

        /// <summary>
        /// 删除业务附件
        /// </summary>
        public const string BusinessObjectAttachmentRemove = "bo.file.remove";

        /// <summary>
        /// 删除业务附件字段上所绑定的附件s
        /// </summary>
        public const string BusinessObjectAttachmentRemoveByField = "bo.files.remove";

    }
}
