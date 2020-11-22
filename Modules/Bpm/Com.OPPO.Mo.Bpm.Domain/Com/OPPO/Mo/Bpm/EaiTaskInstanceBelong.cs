using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Com.OPPO.Mo.Bpm
{
    /// <summary>
    /// Eai任务实例归属
    /// </summary>
    public class EaiTaskInstanceBelong : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// Eai任务实例Id
        /// </summary>
        [NotNull]
        public string EaiTaskInstanceId { get; set; }

        /// <summary>
        /// Eai任务业务Id
        /// </summary>
        [NotNull]
        public string EaiTaskBizId { get; set; }

        /// <summary>
        /// Eai任务标题
        /// </summary>
        [NotNull]
        public string EaiTaskTitle { get; set; }

        /// <summary>
        /// 归属的应用Id
        /// </summary>
        [NotNull]
        public string AppId { get; set; }

    }
}
