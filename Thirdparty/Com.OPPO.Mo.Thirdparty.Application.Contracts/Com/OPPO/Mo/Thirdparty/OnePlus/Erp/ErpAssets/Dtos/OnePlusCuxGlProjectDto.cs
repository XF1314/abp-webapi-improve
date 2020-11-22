using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.OnePlus.Erp.ErpAssets.Dtos
{
    public class OnePlusMarketingBudgetProjectProjectDto
    {
        /// <summary>
        /// 营销预算Code
        /// </summary>
        [JsonProperty("PROJE_SEG1")]
        public string PROJE_SEG1 { get; set; }
        /// <summary>
        /// 中文名
        /// </summary>
        [JsonProperty("PROJE_SEG1_CN")]
        public string PROJE_SEG1_CN { get; set; }
        /// <summary>
        /// 英文名
        /// </summary>
        [JsonProperty("PROJE_SEG1_EN")]
        public string PROJE_SEG1_EN { get; set; }
    }
}
