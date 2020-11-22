using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.HR.PsHr.Response
{

    public class OrganizationCompilation
    {
        /// <summary>
        /// 组织编号
        /// </summary>
        public string DepartmentId { get; set; }

        /// <summary>
        /// 组织编制总数
        /// </summary>
        public string DepartmentCount { get; set; }

        /// <summary>
        /// 组织占编制总数
        /// </summary>
        public string DepartmenInTotal { get; set; }

        /// <summary>
        /// 组织审批编制总数(外聘)
        /// </summary>
        public string DepartmenApprovalTotalOut { get; set; }

        /// <summary>
        /// 组织审批编制总数(内聘)
        /// </summary>
        public string DepartmenApprovalTotalIn { get; set; }
    }
}
