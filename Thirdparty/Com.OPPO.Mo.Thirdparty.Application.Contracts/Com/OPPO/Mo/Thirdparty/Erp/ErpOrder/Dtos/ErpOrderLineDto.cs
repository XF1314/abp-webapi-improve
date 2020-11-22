using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpOrder.Dtos
{
    public class ErpOrderLineDto
    {
        /// <summary>
        /// 文件编号
        /// </summary>
        public string DocId { get; set; }

        /// <summary>
        /// 源代码
        /// </summary>
        public string SourceCode { get; set; }
        /// <summary>
        /// 国家
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// 客户编码
        /// </summary>
        public string CustomerCode { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int LineNum { get; set; }

        /// <summary>
        /// 物料编码
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public string Quantity { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// 组织代码
        /// </summary>
        public string OrgCode { get; set; }

        /// <summary>
        /// 子库
        /// </summary>
        public string Subinventory { get; set; }

        /// <summary>
        /// 定位
        /// </summary>
        public string Locator { get; set; }
        /// <summary>
        /// 货币代码
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// 解释
        /// </summary>
        public string Comments { get; set; }
    }
}
