using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.DiDi.Dtos
{
    /// <summary>
    /// 滴滴授权认证返回结果实体
    /// </summary>
    public class OnePlusDiDiAuthorizeInfo
    {
        /// <summary>
        /// 接口获取授权后的access token
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// access_token的生命周期，单位是秒数
        /// </summary>
        [JsonProperty("expires_in")]
        public string ExpiresIn { get; set; }

        /// <summary>
        /// access_token类型
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// 权限范围
        /// </summary>
        [JsonProperty("scope")]
        public string Scope { get; set; }
    }
}
