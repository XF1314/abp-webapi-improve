using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Dtos
{
    /// <summary>
    /// 导入输出信息
    /// </summary>
    public class OnePlusErpHeadersIfaceDto
    {
        /// <summary>
        /// 返回码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 头部Id
        /// </summary>
        [JsonProperty("header_id")]
        public string HeaderId { get; set; }
    }
}
