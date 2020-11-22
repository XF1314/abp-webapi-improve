using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.DiDi.Requests
{
    /// <summary>
    /// 用车制度查询输入参数
    /// </summary>
    public class DiDiRegulationTRequest : BaseDiDiRequest,ICompanyId
    {
        /// <summary>
        /// 授权后的access token
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// 员工id（员工新建接口中返回的企业版id）
        /// </summary>
        [JsonProperty("member_id")]
        public long MemberId { get; set; }

        /// <summary>
        /// 企业ID
        /// </summary>
        [JsonProperty("company_id")]
        public string CompanyId { get; set; }
    }
}
