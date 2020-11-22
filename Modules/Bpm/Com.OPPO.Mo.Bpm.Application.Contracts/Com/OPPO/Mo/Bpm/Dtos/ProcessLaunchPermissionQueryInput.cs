using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.Dtos
{
    /// <summary>
    /// 流程发起权限查询Input
    /// </summary>
    public class ProcessLaunchPermissionQueryInput
    {
        /// <summary>
        /// 【选填项】应用Id
        /// </summary>
        public string AppId { get; set; }


        /// <summary>
        /// 【选填项】流程定义Id
        /// </summary>
        public string ProcessDefinitionId { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool? IsValid { get; set; }

    }
}
