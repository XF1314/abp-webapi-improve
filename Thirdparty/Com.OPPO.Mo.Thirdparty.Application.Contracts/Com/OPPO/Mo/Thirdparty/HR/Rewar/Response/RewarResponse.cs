using Newtonsoft.Json;
using System.Collections.Generic;

namespace Com.OPPO.Mo.Thirdparty.Hr.Rewar.Response
{
    public class RewarResponse<T>
    {
        public RewarResponse()
        {
            Data = new List<T>();
        }

        [JsonProperty("code")]
        public string Status { get; set; }

       
        [JsonProperty("msg")]
        public string Descr { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        [JsonProperty("data")]
        public List<T> Data { get; set; }
    }
}
