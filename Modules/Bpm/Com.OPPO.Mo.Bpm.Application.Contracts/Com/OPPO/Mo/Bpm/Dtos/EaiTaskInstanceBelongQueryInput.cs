using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.Dtos
{
    /// <summary>
    /// Eai任务实例归属查询Input
    /// </summary>
    public class EaiTaskInstanceBelongQueryInput
    {
        /// <summary>
        /// 【选填项】应用Id
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 【选填项】Eai任务实例Id
        /// </summary>
        public string EaiTaskInstanceId { get; set; }

        /// <summary>
        /// 【选填项】Eai任务业务Id
        /// </summary>
        public string EaiTaskBizId { get; set; }

        /// <summary>
        /// 【选填项】Eai任务标题
        /// </summary>
        public string EaiTaskTitle { get; set; }

        /// <summary>
        /// 【选填项】创建时间From
        /// </summary>
        public DateTime? CreationTimeFrom { get; set; }

        /// <summary>
        /// 【选填项】创建时间To
        /// </summary>
        public DateTime? CreationTimeTo { get; set; }

    }
}
