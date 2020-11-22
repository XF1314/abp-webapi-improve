using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Requests
{
    /// <summary>
    /// 获取拟价单信息输入参数
    /// </summary>
    public class OnePlusErpPriceRequest : BaseEsbRequest
    {
        /// <summary>
        /// 语言
        /// </summary>
        [JsonProperty("language")]
        public string Language { get; set; }

        /// <summary>
        /// MO文件编号
        /// </summary>
        [JsonProperty("oa_num")]
        public string OaNum { get; set; }
    }
}
