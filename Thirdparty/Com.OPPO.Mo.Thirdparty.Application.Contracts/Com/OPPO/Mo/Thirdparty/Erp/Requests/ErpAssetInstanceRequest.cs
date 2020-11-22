using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.Requests
{
    /// <summary>
    /// 设备调拨_固定资产和设备信息查询 实体信息
    /// </summary>
    public class ErpAssetInstanceRequest : BaseEsbLanguageRequest
    {
        /// <summary>
        /// 资产编号
        /// </summary>
        [JsonProperty("asset_num")]
        public string AssetNum { get; set; }


        /// <summary>
        /// 组织代码
        /// </summary>
        [JsonProperty("org_code")]
        public string OrgCode { get; set; }
    }
}
