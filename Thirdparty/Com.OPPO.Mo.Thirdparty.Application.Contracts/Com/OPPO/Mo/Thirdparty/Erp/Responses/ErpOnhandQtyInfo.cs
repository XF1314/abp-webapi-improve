using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.Responses
{
    /// <summary>
    ///物料现有量信息
    /// </summary>
    public class ErpOnhandQtyInfo
    {
        /// <summary>
        /// 物料编码
        /// </summary>
        [JsonProperty("item_code")]
        public string ItemCode { get; set; }

        /// <summary>
        /// 物料描述
        /// </summary>
        [JsonProperty("item_desc")]
        public string ItemDesc { get; set; }

        /// <summary>
        /// 物料数量
        /// </summary>
        [JsonProperty("item_quantity")]
        public int ItemQuantity { get; set; }

    }
}
