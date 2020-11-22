using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.HR.PsHr.Response
{
    public class DepartmentManningQuotas
    {
        /// <summary>
        /// 组织部门编号
        /// </summary>
        public string OrgDepartmentId { get; set; }

        /// <summary>
        /// 编制总数
        /// </summary>
        public string TotalCompilation { get; set; }

        /// <summary>
        /// 占编制总数
        /// </summary>
        public string InTotal { get; set; }

        /// <summary>
        /// 是否可以发起（Y/N）
        /// </summary>
        public string IsLaunch { get; set; }

        /// <summary>
        /// 组织编制数据
        /// </summary>
        public List<OrganizationCompilation> Datas { get; set; }
    }
}
