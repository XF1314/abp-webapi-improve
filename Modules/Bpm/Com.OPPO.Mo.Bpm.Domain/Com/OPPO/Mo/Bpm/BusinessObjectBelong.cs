using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Com.OPPO.Mo.Bpm
{
    /// <summary>
    /// 业务模型归属
    /// </summary>
    public class BusinessObjectBelong : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 业务对象Id
        /// </summary>
        [NotNull]
        public string BusinessObjectId { get; set; }

        /// <summary>
        /// 业务对象表Name
        /// </summary>
        [NotNull]
        public string BusinessObjectTableName { get; set; }

        /// <summary>
        /// 绑定的流程实例Id
        /// </summary>
        [NotNull]
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 归属的应用Id
        /// </summary>
        [NotNull]
        public string AppId { get; set; }
    }
}
