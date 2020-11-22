using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Values;

namespace Com.OPPO.Mo.Bpm
{
    /// <summary>
    /// 流程定义信息
    /// </summary>
    public class ProcessDefinitionInfo : ValueObject
    {
        /// <summary>
        /// 流程定义Id
        /// </summary>
        [NotNull]
        public string ProcessDefinitionId { get; set; }

        /// <summary>
        /// 流程名称
        /// </summary>
        public string ProcessName { get; set; }

        /// <summary>
        /// 所属应用Id
        /// </summary>
        public string AppId { get; set; }

        /// <inheritdoc/>
        protected override IEnumerable<object> GetAtomicValues()
        {
            return new object[] { ProcessDefinitionId, ProcessName, AppId };
        }
    }
}
