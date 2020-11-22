using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.Requests
{
    /// <summary>
    /// MO费用报销输入参数
    /// </summary>
    public class ErpImportExpensesRequest : BaseEsbRequest
    {
        /// <summary>
        /// JSON格式费用报销数据：
        /// </summary>
        [JsonProperty("p_json")]
        public string Expenses { get; set; }
    }
}
