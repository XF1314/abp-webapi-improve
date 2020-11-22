using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Responses
{
    public class PoLinesInfo: PoLineBase
    {
        /// <summary>
        /// 文件编码
        /// </summary>
        public string DocLineNum { get; set; }
        /// <summary>
        /// 本次请求Id（用于追踪问题）
        /// </summary>
        public string RequestId { get; set; }
        /// <summary>
        /// 接受编码
        /// </summary>
        public string ReceiveNum { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public double UnitPrice { get; set; }
        /// <summary>
        /// 税
        /// </summary>
        public double PriceTax { get; set; }
    }
}
