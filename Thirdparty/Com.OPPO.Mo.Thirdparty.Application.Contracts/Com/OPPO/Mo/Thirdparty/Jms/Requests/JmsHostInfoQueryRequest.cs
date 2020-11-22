using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Jms.Requests
{
    /// <summary>
    /// 跳板机服务器信息 Query request
    /// </summary>
    public class JmsHostInfoQueryRequest : BaseJmsRequest
    {
        /// <summary>
        /// 【Ip地址和服务器名称二填一即可】Ip地址
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// 【Ip地址和服务器名称二填一即可】服务器名称
        /// </summary>
        public string HostName { get; set; }

    }
}
