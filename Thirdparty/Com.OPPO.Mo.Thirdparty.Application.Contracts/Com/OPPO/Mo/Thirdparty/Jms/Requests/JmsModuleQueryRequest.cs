using Com.OPPO.Mo.Thirdparty.Jms.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Jms.Requests
{
    /// <summary>
    /// 跳板机模块 Query request
    /// </summary>
    public class JmsModuleQueryRequest : BaseJmsRequest
    {
        /// <summary>
        /// 【必填项】产品
        /// </summary>
        public string Product { get; set; }

        /// <summary>
        /// 【必填项】服务
        /// </summary>
        public string Service { get; set; }

    }
}
