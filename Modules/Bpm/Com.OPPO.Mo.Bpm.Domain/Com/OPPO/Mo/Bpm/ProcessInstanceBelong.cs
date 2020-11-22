using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace Com.OPPO.Mo.Bpm
{
    /// <summary>
    /// 流程实例归属
    /// </summary>
    public class ProcessInstanceBelong : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 流程实例Id
        /// </summary>
        [NotNull]
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 流程实例编码
        /// </summary>
        public string ProcessInstanceCode { get; set; }

        /// <summary>
        /// 流程标题
        /// </summary>
        public string ProcessTitle { get; set; }

        /// <summary>
        /// 应用Id
        /// </summary>
        [NotNull]
        public string AppId { get; set; }
    }
}
