using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace Com.OPPO.Mo.Bpm
{
    /// <summary>
    /// 业务对象表权限
    /// </summary>
    public class BusinessObjectTablePermission : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 应用Id
        /// </summary>
        [NotNull]
        public string AppId { get; set; }

        /// <summary>
        /// 应用名称
        /// </summary>
        [NotNull]
        public string AppName { get; set; }

        /// <summary>
        /// 业务对象表名称
        /// </summary>
        [NotNull]
        public string BusinessObjectTableName { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsValid { get; set; } = true;
    }
}
