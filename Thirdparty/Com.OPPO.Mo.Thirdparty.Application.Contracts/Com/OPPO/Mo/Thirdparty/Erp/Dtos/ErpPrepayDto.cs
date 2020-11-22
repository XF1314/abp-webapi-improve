using System;
using System.Collections.Generic;

namespace Com.OPPO.Mo.Thirdparty.Erp.Dtos
{
    /// <summary>
    /// 个人借款信息
    /// </summary>
    public class ErpPrepayDto
    {
        /// <summary>
        /// 供应商编号
        /// </summary>
        public string VendorNum { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        public string VendorName { get; set; }

        /// <summary>
        /// 纳税单位ID
        /// </summary>
        public int? OuId { get; set; }

        /// <summary>
        /// 纳税单名称
        /// </summary>
        public string OuName { get; set; }

        /// <summary>
        /// 预付款编号
        /// </summary>
        public int? PrepayId { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        public int? DocSequenceValue { get; set; }

        /// <summary>
        /// 贷款日期
        /// </summary>
        public DateTime? PrepayGlDate { get; set; }

        /// <summary>
        /// 预付款金
        /// </summary>
        public int? PrepayAmount { get; set; }

        /// <summary>
        /// 可用余额
        /// </summary>
        public double PrepayAmountRemaining { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        public double AmountRemaining { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 预计还款时间
        /// </summary>
        public DateTime? ExpectedTime { get; set; }

        /// <summary>
        /// 币种编码
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }
    }
}
