using Com.OPPO.Mo.Thirdparty.Hr.Dtos;
using System.Collections.Generic;

namespace Com.OPPO.Mo.Thirdparty.Hr.Requests
{
    public class LeaveBatchRequest: BaseEsbRequest
    {
        /// <summary>
        /// 文件编号
        /// </summary>
        public string formInstance_code { get; set; }

        /// <summary>
        /// 请假信息
        /// </summary>
        public string leave_data { get; set; }
    }
}
