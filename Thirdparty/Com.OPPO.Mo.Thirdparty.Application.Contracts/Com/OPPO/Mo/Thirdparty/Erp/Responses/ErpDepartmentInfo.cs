using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.Responses
{
    /// <summary>
    /// 部门信息
    /// </summary>
    public class ErpDepartmentInfo
    {
        /// <summary>
        /// 部门编码
        /// </summary>
        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }

        /// <summary>
        /// 部门描述
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
