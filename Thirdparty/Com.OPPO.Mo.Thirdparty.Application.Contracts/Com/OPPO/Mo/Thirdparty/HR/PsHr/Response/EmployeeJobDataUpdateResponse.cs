using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Response
{
    public class EmployeeJobDataUpdateResponse
    {
        /// <summary>
        /// 员工ID
        /// </summary>
        public string EmployeeId { get; set; }
        
        /// <summary>
        /// 数据更新标识
        /// </summary>
        public bool DataFlag { get; set; }
        
        /// <summary>
        /// 错误原因
        /// </summary>
        public string ErrorMsg { get; set; }
    }
}
