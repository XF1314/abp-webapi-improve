using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Responses
{
    public class MonthSalaryInfo
    {
        /// <summary>
        /// 状态
        /// </summary>
        [JsonProperty("STATUS")]
        public string Status { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        [JsonProperty("COMPRATE")]
        public string Comprate { get; set; }
    } 
}
