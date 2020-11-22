using Com.OPPO.Mo.Thirdparty.Jms.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Jms.Requests
{
    /// <summary>
    /// 跳板机服务 Query request
    /// </summary>
    public class JmsServiceQueryRequest : BaseJmsRequest
    {
        /// <summary>
        /// 【必填项】产品
        /// </summary>
        public string Product { get; set; }
    }
}
