using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.Dtos
{
    /// <summary>
    /// 业务对象归属查询Input
    /// </summary>
    public class BusinessObjectBelongQueryInput
    {
        /// <summary>
        /// 【非必填项】应用Id
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 【非必填项】业务对象Id
        /// </summary>
        public string BusinessObjectId { get; set; }

        /// <summary>
        /// 【非必填项】业务对象表名称
        /// </summary>
        public string BusinessObjectTableName { get; set; }

        /// <summary>
        /// 【非必填项】流程实例Id
        /// </summary>
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 【非必填项】创建时间From    
        /// </summary>
        public DateTime? CreationTimeFrom { get; set; }

        /// <summary>
        /// 【非必填项】创建时间To
        /// </summary>
        public DateTime? CreationTimeTo { get; set; }

    }
}
