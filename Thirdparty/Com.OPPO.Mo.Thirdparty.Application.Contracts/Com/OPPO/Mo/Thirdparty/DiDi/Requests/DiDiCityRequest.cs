using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.DiDi.Requests
{
    /// <summary>
    /// 城市查询输入参数
    /// </summary>
    public class DiDiCityRequest : BaseDiDiRequest,ICompanyId
    {
        /// <summary>
        /// 授权后的access token
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// 企业ID
        /// </summary>
        [JsonProperty("company_id")]
        public string CompanyId { get; set; }
    }
}
