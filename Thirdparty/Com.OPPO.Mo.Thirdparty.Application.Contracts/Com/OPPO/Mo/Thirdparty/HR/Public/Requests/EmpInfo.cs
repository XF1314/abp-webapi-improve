using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.HR.Public.Requests
{
    public class EmpInfo
    {
        /// <summary>
        /// 人员工号
        /// </summary>
        public string EmployId { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public string Birthdate { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        public string Nationalid { get; set; }
    }
}
