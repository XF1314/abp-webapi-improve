using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Com.OPPO.Mo.Bpm.Dtos
{
    /// <summary>
    /// Eai任务实例归属Dto
    /// </summary>
    public class EaiTaskInstanceBelongDto
    {
        /// <summary>
        /// <see cref="IEntity{Guid}.Id"/>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 应用Id
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// Eai任务实例Id
        /// </summary>
        public string EaiTaskInstanceId { get; set; }

        /// <summary>
        /// Eai任务业务Id
        /// </summary>
        public string EaiTaskBizId { get; set; }

        /// <summary>
        /// Eai任务标题
        /// </summary>
        public string EaiTaskTitle { get; set; }

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
