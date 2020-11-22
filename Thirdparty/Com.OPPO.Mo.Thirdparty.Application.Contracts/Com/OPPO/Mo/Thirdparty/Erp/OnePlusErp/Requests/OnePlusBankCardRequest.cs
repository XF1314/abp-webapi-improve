using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Requests
{
    /// <summary>
    /// 查询个人银行信息输入参数
    /// </summary>
    public class OnePlusBankCardRequest : BaseEsbRequest
    {     
        /// <summary>
        /// 员工工号
        /// </summary>
        [JsonProperty("empid")]
        public string Empid { get; set; }
    }
}
