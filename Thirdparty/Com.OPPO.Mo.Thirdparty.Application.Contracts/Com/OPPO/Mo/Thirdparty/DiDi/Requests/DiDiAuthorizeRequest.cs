using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.DiDi.Requests
{
    /// <summary>
    /// 获取授权access_token 输入参数
    /// </summary>
    public class DiDiAuthorizeRequest : BaseDiDiRequest, IAppSecret
    {
        public DiDiAuthorizeRequest()
        {
            GrantType = "client_credentials";
        }

        /// <summary>
        /// 管理员手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 请求的类型，填写client_credentials
        /// </summary>
        [JsonProperty("grant_type")]
        public string GrantType { get; private set; }

        /// <summary>
        /// 申请应用时分配的AppKey
        /// </summary>
        [JsonProperty("client_secret")]
        public string AppSecret { get; set; }
       
    }
}
