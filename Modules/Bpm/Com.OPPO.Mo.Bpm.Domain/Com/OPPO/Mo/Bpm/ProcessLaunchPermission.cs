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
    /// 流程发起权限
    /// </summary>
    public class ProcessLaunchPermission : FullAuditedEntity<Guid>
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
        /// 流程定义Id
        /// </summary>
        [NotNull]
        public string ProcessDefinitionId { get; set; }

        /// <summary>
        /// 流程名称
        /// </summary>
        [NotNull]
        public string ProcessName { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsValid { get; set; } = true;
    }
}
