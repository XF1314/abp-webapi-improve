using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Requests
{
    /// <summary>
    /// 采购单拟价导入输入参数
    /// </summary>
    public class OnePlusErpPriceAddRequest : BaseEsbRequest
    {
        /// <summary>
        /// onePlus_ERP供应商
        /// </summary>
        [JsonProperty("lines")]
        public string Lines { get; set; }
    }


}
