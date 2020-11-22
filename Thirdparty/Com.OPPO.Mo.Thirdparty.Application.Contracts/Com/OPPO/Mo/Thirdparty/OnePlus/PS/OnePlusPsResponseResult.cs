using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.OnePlus.PS
{
    public class OnePlusPsResponseResult : IResponseResult
    {
        [JsonProperty("code")]
        public string ResultCode { get; set; }

        [JsonProperty("msg")]
        public string Message { get; set; }

        public bool IsOk => ResultCode == "success";
    }

    public class OnePlusPsBodyResponseResult<TData> : OnePlusPsResponseResult
    {
        [JsonProperty("response")]
        public TData Body { get; set; }
    } 
}
