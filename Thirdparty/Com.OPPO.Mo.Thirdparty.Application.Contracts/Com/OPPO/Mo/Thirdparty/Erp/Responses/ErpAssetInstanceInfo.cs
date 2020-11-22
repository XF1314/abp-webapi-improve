using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.Responses
{
    /// <summary>
    /// 固定资产和设备信息
    /// </summary>
    public class ErpAssetInstanceInfo
    {
        /// <summary>
        /// 资产编号
        /// </summary>
        [JsonProperty("asset_num")]
        public string AssetNum { get; set; }

        /// <summary>
        /// 实例编码
        /// </summary>
        [JsonProperty("instance_code")]
        public string InstancCode { get; set; }

        /// <summary>
        /// 项目代码
        /// </summary>
        [JsonProperty("item_code")]
        public string ItemCode { get; set; }


        /// <summary>
        /// 部门编码
        /// </summary>
        [JsonProperty("fa_dept_code")]
        public string FaDeptCode { get; set; }

        /// <summary>
        /// 资产描述
        /// </summary>
        [JsonProperty("asset_desc")]
        public string AssetDesc { get; set; }

        /// <summary>
        /// 子库编码
        /// </summary>
        [JsonProperty("subinv_code")]
        public string SubinvCode { get; set; }

        /// <summary>
        /// ？
        /// </summary>
        [JsonProperty("locator_code")]
        public string LocatorCode { get; set; }

        /// <summary>
        /// ？
        /// </summary>
        [JsonProperty("uom")]
        public string Uom { get; set; }

        /// <summary>
        /// 项目类型
        /// </summary>
        [JsonProperty("item_type")]
        public string ItemType { get; set; }

        /// <summary>
        /// 项目分类
        /// </summary>
        [JsonProperty("item_category")]
        public string ItemCategory { get; set; }
    }
}
