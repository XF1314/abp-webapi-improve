using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Request
{
    public class PsBadyRequest: PsHrBaseRequest
    {
        /// <summary>
        /// 接口代码,必填
        /// </summary>
        [JsonProperty("hhrIfcCode")]
        public string InterfaceCode { get; set; }

        /// <summary>
        /// 系统ID,必填
        /// </summary>
        [JsonProperty("hhrSysCode")]
        public string SystemCode { get; set; } = "MO";

        /// <summary>
        /// 语言代码,必填
        /// </summary>
        [JsonProperty("language")]
        public string Language { get; set; } = "ZHS";

    }

    public class PsBadyRequest<TData> : PsBadyRequest
    {
        /// <summary>
        /// 请求数据
        /// </summary>
        public TData datas { get; set; }
    }

}
