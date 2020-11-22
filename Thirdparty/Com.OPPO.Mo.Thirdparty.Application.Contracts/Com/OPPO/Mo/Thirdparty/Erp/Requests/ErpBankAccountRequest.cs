using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.Requests
{
    /// <summary>
    /// 银行账号查询输入参数
    /// </summary>
    public class ErpBankAccountRequest : BaseEsbRequest
    {
        /// <summary>
        /// 报销人工号
        /// </summary>
        [JsonProperty("emplid")]
        public string EmplId { get; set; }
    }
}
