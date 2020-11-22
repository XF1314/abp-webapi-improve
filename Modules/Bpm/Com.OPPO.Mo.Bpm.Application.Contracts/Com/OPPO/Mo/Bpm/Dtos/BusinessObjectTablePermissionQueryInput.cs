using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.Dtos
{
    /// <summary>
    /// 业务对象表权限查询Input
    /// </summary>
    public  class BusinessObjectTablePermissionQueryInput
    {
        /// <summary>
        /// 【选填项】应用Id
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 【选填项】业务对象表名称
        /// </summary>
        public string BusinessObjectTableName { get; set; }

        /// <summary>
        /// 【选填项】是否有效
        /// </summary>
        public bool? IsValid { get; set; }

    }
}
