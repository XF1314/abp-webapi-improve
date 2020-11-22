using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Com.OPPO.Mo.Bpm.Dtos
{
    /// <summary>
    /// 流程实例归属Dto
    /// </summary>
    public class ProcessInstanceBelongDto
    {
        /// <summary>
        /// <see cref="IEntity{Guid}.Id"/>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 流程实例Id
        /// </summary>
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
        public string AppId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? LastModificationTime { get; set; }

    }
}
