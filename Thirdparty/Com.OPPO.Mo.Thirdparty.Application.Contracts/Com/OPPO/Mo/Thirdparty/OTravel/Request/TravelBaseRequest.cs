using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.OTravel.Request
{

    public class TravelBaseRequest : IUserName
    {
        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("currentTime")]
        public string currentTime { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        //[JsonProperty("password")]
        //public string password { get; set; }

        public string format { get; set; } = "json";

        [JsonProperty("data")]
        public string Data { get; set; }
    }
}
