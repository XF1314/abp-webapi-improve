using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Dtos
{
    /// <summary>
    /// 核算主体输出信息
    /// </summary>
    public class OnePlusErpBodyDto
    {
        /// <summary>
        /// 组织id
        /// </summary>
        [JsonProperty("ORG_ID")]
        public string OrgId { get; set; }

        /// <summary>
        /// 组织编号
        /// </summary>
        [JsonProperty("ORG_CODE")]
        public string OrgCode { get; set; }

        /// <summary>
        /// 组织名称
        /// </summary>
        [JsonProperty("ORG_NAME")]
        public string OrgName { get; set; }

        /// <summary>
        /// 币种代码
        /// </summary>
        [JsonProperty("TARGET_CURRENCY_CODE")]
        public string TargetCurrencyCode { get; set; }

        /// <summary>
        /// 主体在PS系统中的ID
        /// </summary>
        [JsonProperty("PS_LE_ID")]
        public string PsLeId { get; set; }

        /// <summary>
        /// 主体在PS系统中名称
        /// </summary>
        [JsonProperty("PS_LE_NAME")]
        public string PsLeName { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("COMPANY_SEG")]
        public string CompanySeg { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        public int? TOTAL { get; set; }
    }
}
