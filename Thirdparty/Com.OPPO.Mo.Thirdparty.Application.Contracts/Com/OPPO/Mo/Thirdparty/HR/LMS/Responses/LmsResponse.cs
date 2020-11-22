using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Hr.LMS.Responses
{
    public class LmsResponse<TData>
    {
        /// <summary>
        /// <see cref="LmsResponse{TData}"/>
        /// </summary>
        public LmsResponse()
        {
            Data = default;
        }

        /// <summary>
        /// 响应内容
        /// </summary>
        [JsonProperty("response")]
        public TData Data { get; set; }
    }
}
