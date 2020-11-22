using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft
{
    public class PsResponseResult : IResponseResult
    {
        [JsonProperty("code")]
        public string ResultCode { get; set; }

        [JsonProperty("msg")]
        public string Message { get; set; }

        public bool IsOk => ResultCode == "success";
    }

    public class HrResponseResult<TData> : PsResponseResult
    {
        [JsonProperty("response")]
        public TData Body { get; set; }
    }
}
