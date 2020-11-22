using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Responses
{
    public class PoLineBase
    {
        /// <summary>
        /// 文件编号
        /// </summary>
        public string DocId { get; set; }
        /// <summary>
        /// 单据名称 
        /// </summary>
        public string DocName { get; set; }
      
        /// <summary>
        /// 供应商代码
        /// </summary>
        public string VendorCode { get; set; }

        /// <summary>
        /// 物料编码
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public string Quantity { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// PO码
        /// </summary>
        public string PoNum { get; set; }
        /// <summary>
        /// ?
        /// </summary>
        public int? PoLineNum { get; set; }
        /// <summary>
        /// 接受数量
        /// </summary>
        public int? ReceiveQty { get; set; }
    }
}
