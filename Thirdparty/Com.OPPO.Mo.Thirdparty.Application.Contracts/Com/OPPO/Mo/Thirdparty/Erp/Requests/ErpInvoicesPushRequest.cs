using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.Requests
{
    /// <summary>
    /// 付款通知单传ERP
    /// </summary>
    public class ErpInvoicesPushRequest : BaseEsbRequest
    {
        /// <summary>
        /// 付款通知单传ERP对应参数json
        /// </summary>
        [JsonProperty("invoices")]
        public string Invoices { get; set; }
    }
}
