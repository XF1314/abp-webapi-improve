using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Values;

namespace Com.OPPO.Mo.Bpm
{
    /// <summary>
    /// 流程实例信息
    /// </summary>
    public class ProcessInstanceInfo : ValueObject
    {
        /// <summary>
        /// 流程实例Id
        /// </summary>
        [NotNull]
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 流程Title
        /// </summary>
        public string ProcessTitle { get; set; }

        /// <summary>
        /// ActionSoft流程状态（系统）
        /// </summary>
        public string ProcessControlState { get; set; }

        /// <inheritdoc/>
        protected override IEnumerable<object> GetAtomicValues()
        {
            return new object[] { ProcessInstanceId, ProcessTitle, ProcessControlState };
        }
    }
}
