using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Feiheair.Requests
{
    /// <summary>
    /// 创建出差申请单输入参数
    /// </summary>
    public class FeiHeairApplyDataRequest: FeiHeairBaseRequest
    {
        /// <summary>
        /// Key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// json格式数据
        /// </summary>
        [JsonProperty("jsonData")]
        public string Data { get; set; }
    }
}
