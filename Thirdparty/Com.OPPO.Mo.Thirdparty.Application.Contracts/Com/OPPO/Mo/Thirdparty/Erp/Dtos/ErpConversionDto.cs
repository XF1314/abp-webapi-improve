using System;

namespace Com.OPPO.Mo.Thirdparty.Erp.Dtos
{
    /// <summary>
    /// 汇率换算输出类
    /// </summary>
    public class ErpConversionDto
    {
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime ConversionDate { get; set; }

        /// <summary>
        /// 汇率
        /// </summary>
        public decimal ConversionRate { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string ConversionType { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// from
        /// </summary>
        public string FromCurrency { get; set; }

        /// <summary>
        /// 反向转换率
        /// </summary>
        public string InverseConversionRate { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime LastUpdateDate { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string StatusCode { get; set; }

        /// <summary>
        /// to
        /// </summary>
        public string ToCurrency { get; set; }

    }
}
