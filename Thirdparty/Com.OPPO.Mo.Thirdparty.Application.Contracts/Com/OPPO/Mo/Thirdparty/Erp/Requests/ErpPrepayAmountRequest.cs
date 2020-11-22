using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.Requests
{
    /// <summary>
    /// 查询核销预付款入参实体信息
    /// </summary>
    public class ErpPrepayAmountRequest : BaseEsbRequest
    {
        /// <summary>
        /// 报销单号
        /// </summary>
        [JsonProperty("invoice_num")]
        public string InvoiceNum { get; set; }

        /// <summary>
        /// 返回格式，支持json/xml两种格式，默认为json格式
        /// </summary>
        [JsonProperty("resp_type")]
        public string RespType { get; set; }
    }
}
