using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.Requests
{
    /// <summary>
    /// EAM-检查部门代码是否有对应的字库信息实体类
    /// </summary>
    public class ErpDepartmentRequest : BaseEsbRequest
    {
        /// <summary>
        /// 组织编码
        /// </summary>
        [JsonProperty("org_code")]
        public string OrgCode { get; set; }

        /// <summary>
        /// 部门编码
        /// </summary>
        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }
    }
}
