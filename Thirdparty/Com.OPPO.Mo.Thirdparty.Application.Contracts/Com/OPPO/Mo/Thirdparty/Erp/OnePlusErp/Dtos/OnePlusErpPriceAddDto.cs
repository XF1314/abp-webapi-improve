using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Dtos
{
    /// <summary>
    /// 拟价单导入输出信息
    /// </summary>
    public class OnePlusErpPriceAddDto
    {
        /// <summary>
        /// 返回码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("retData")]
        public string Data { get; set; }


    }
}
