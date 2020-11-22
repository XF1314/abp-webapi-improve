using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Dtos
{
    /// <summary>
    /// SKU基础数据查询输出信息
    /// </summary>
    public class OneplusErpCuxOaItemDto
    {
        /// <summary>
        /// SKU编号
        /// </summary>
        [JsonProperty("SKU_ID")]
        public int SkuId { get; set; }

        /// <summary>
        /// SKU编码
        /// </summary>
        [JsonProperty("SKU_CODE")]
        public string SkuCode { get; set; }

        /// <summary>
        /// SKU单位
        /// </summary>
        [JsonProperty("UOM")]
        public string Uom { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [JsonProperty("SKU_DESC")]
        public string SkuDesc { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("SKU_DESC_US")]
        public string SkuDescUs { get; set; }

        /// <summary>
        /// 组织编号
        /// </summary>
        [JsonProperty("ORGANIZATION_ID")]
        public int OrganizationId { get; set; }
    }
}
