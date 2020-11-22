using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Responses
{

    public class VenderTax
    {
        /// <summary>
        /// 组织代码
        /// </summary>
        public string OrgCode { get; set; }

        /// <summary>
        /// 供应商id
        /// </summary>
        public int VendorId { get; set; }
        /// <summary>
        /// 供应商代码
        /// </summary>
        public string VendorCode { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string VendorName { get; set; }
        /// <summary>
        /// 供应商类型
        /// </summary>
        public string VendorType { get; set; }
        /// <summary>
        /// 税率
        /// </summary>
        public double TaxRate { get; set; }
        /// <summary>
        /// 付款货币代码
        /// </summary>
        public string PaymentCurrencyCode { get; set; }
    }
}
