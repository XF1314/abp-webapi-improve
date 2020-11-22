using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpBasics.Responses
{
    public class ErpCheckIsGroupResponse
    {
        /// <summary>
        /// <see cref="EsbResponseBody"/>
        /// </summary>
        public CheckIsGroupBody response { get; set; }
    }

    public class CheckIsGroupBody
    {
        /// <summary>
        /// 业务码
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// 响应消息
        /// </summary>
        public string msg { get; set; }

        public string count { get; set; }
    }
}
