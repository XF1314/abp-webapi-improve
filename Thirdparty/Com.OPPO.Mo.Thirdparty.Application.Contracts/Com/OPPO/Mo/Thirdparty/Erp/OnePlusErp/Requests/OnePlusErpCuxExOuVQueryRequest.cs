using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Requests
{
    /// <summary>
    /// 获取主体信息输入参数
    /// </summary>
    public class OnePlusErpCuxExOuVQueryRequest : BaseEsbRequest
    {
        /// <summary>
        /// 语言
        /// </summary>
        [JsonProperty("language")]
        public string Language { get; set; }

        /// <summary>
        /// 主体code
        /// </summary>
        [JsonProperty("org_code")]
        public string OrgCode { get; set; }

        /// <summary>
        /// 主体ID
        /// </summary>
        [JsonProperty("org_id")]
        public string OrgId { get; set; }

        /// <summary>
        /// 主体名称
        /// </summary>
        [JsonProperty("org_name")]
        public string OrgName { get; set; }

        /// <summary>
        /// 主体在PS系统中的ID
        /// </summary>
        [JsonProperty("ps_le_id")]
        public string PsLeId { get; set; }

        /// <summary>
        /// 主体本位币
        /// </summary>
        [JsonProperty("target_currency_code")]
        public string TargetCurrencyCode { get; set; }

        
    }
}
