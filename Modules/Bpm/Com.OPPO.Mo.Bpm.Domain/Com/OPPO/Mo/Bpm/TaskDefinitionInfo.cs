using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Values;

namespace Com.OPPO.Mo.Bpm
{
    /// <summary>
    /// 任务定义信息
    /// </summary>
    public class TaskDefinitionInfo : ValueObject
    {
        /// <summary>
        /// 任务定义Id
        /// </summary>
        [NotNull]
        public string TaskDefinitionId { get; set; }

        /// <summary>
        /// 任务名称
        /// </summary>
        public string TaskName { get; set; }

        /// <inheritdoc/>
        protected override IEnumerable<object> GetAtomicValues()
        {
            return new object[] { TaskDefinitionId, TaskName };
        }
    }
}
