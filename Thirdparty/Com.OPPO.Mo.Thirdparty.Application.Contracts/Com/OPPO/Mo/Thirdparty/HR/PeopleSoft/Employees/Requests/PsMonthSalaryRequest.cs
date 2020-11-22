using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Requests
{
    /// <summary>
    /// 月薪信息
    /// </summary>
    public class PsMonthSalaryRequest : BaseEsbRequest
    {
        /// <summary>
        /// 工号
        /// </summary>
        [JsonProperty("emplid")]
        public string EmplId { get; set; }
    }
}
