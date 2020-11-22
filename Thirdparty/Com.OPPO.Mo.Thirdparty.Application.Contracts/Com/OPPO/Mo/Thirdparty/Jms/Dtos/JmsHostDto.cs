using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Jms.Dtos
{
    /// <summary>
    /// 跳板机服务器Dto
    /// </summary>
    public class JmsHostDto
    {
        /// <summary>
        /// Ip地址
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        ///  服务器名称
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// 业务s
        /// </summary>
        public List<string> Businesses { get; set; }
    }
}
