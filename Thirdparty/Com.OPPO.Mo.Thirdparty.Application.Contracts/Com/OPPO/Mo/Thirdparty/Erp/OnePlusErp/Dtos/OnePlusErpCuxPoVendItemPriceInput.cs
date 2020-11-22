using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Dtos
{
    /// <summary>
    /// 获取财务系统价格输入参数
    /// </summary>
    public class OnePlusErpCuxPoVendItemPriceInput
    {
        /// <summary>
        /// 币种
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// 付款条件ID
        /// </summary>
        public string ItemId { get; set; }

        /// <summary>
        /// 付款条件(SKU编码)
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 语言
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// 主体ID
        /// </summary>
        public string OuId { get; set; }

        /// <summary>
        /// 主体code
        /// </summary>
        public string OuName { get; set; }

        /// <summary>
        /// SKU主单位
        /// </summary>
        public string PrimaryUomCode { get; set; }

        /// <summary>
        /// 供应商ID
        /// </summary>
        public string VendorId { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        public string VendorName { get; set; }

    }
}
