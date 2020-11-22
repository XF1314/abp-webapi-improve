using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Responses
{
    public class PoLine: PoLineBase
    {
        ///// <summary>
        ///// 文件数量
        ///// </summary>
        //public int DocLineNum { get; set; }
        /// <summary>
        /// 本次请求Id（用于追踪问题）
        /// </summary>
        public string RequestId { get; set; }
        /// <summary>
        /// 接受编码
        /// </summary>
        public string ReceiveNum { get; set; }
        
    }

    public class PoLineRet : PoLineBase
    {
        /// <summary>
        /// 文件编号
        /// </summary>
        public string DocLineNum { get; set; }

    }

}
