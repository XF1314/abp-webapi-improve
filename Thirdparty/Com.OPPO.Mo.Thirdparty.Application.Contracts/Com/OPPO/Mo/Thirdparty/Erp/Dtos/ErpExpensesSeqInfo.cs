using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.Dtos
{
    /// <summary>
    /// 报销单号获取接口
    /// </summary>
    public class ErpExpensesSeqInfo
    {
        /// <summary>
        /// 报销单号
        /// </summary>
        [JsonProperty("seq")]
        public string Seq { get; set; }

    }
}
