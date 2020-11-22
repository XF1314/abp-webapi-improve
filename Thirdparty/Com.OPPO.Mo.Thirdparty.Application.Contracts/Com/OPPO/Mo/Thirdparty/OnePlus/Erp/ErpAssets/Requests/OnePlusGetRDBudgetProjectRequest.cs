using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.OnePlus.Erp.ErpAssets.Requests
{
    public class OnePlusGetRDBudgetProjectRequest  : BaseEsbRequest
    {
        [JsonProperty("language")]
        public string Language { get; set; }

        /// <summary>
        /// 研发预算项目
        /// </summary>
        [JsonProperty("proje_seg1")]
        public string Proje_Seg1 { get; set; }
    }
}
