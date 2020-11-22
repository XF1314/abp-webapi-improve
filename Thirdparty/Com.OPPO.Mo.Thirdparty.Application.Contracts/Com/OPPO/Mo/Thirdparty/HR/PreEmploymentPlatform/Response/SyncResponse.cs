using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PreEmploymentPlatform.Response
{
    public class SyncResponse
    {
        /// <summary>
        /// 返回码
        /// </summary>
        public string code { get; set; }
        public string data { get; set; }
        public string datetime { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        public string message { get; set; }
        public string status { get; set; }
    }
}
