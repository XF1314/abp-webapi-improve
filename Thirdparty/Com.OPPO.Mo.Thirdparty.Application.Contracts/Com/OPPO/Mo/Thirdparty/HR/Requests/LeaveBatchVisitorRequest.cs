using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.Requests
{
    public class LeaveBatchVisitorRequest: BaseEsbRequest
    {
        /// <summary>
        /// 文件编号
        /// </summary>
        public string formInstance_code { get; set; }
        /// <summary>
        /// 请假信息 
        /// </summary>
        public string send_data { get; set; }
    }
}
