using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp
{
    public class ErpResponseResult : IResponseResult
    {
        [JsonProperty("code")]
        public string ResultCode { get; set; }

        [JsonProperty("msg")]
        public string Message { get; set; }

        public bool IsOk => ResultCode == "success";
    }

    public class ErpResultResponseResult<TData> : ErpResponseResult
    {
        [JsonProperty("response")]
        public TData Body { get; set; }
    }
}
