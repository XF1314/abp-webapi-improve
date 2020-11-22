using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.Dtos
{
    public class ErpLocatorListInfoDto
    {
        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// 库存信息
        /// </summary>
        [JsonProperty("data")]
        public string Data { get; set; }
    }

}
