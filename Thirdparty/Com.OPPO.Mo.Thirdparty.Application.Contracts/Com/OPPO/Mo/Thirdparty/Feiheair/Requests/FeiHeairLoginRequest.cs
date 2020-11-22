using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Feiheair.Requests
{
    /// <summary>
    /// 获取飞鹤自动登录URL输入参数
    /// </summary>
    public class FeiHeairLoginRequest : FeiHeairBaseRequest
    {
        public FeiHeairLoginRequest()
        {
            Id = "1";
        }

        /// <summary>
        /// 用户名
        /// </summary>
        [JsonProperty("username")]
        public string UserName { get; set; }

        /// <summary>
        /// 跳转页面ID
        /// </summary>
        [JsonProperty("ID")]
        public string Id { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        [JsonProperty("data")]
        public string OrderNumber { get; set; }

    }
}
