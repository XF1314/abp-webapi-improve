using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.Requests
{
    /// <summary>
    /// 根据部门编号查询部门信息实体类
    /// </summary>
    public class ErpDepartmentQueryRequest : BaseEsbRequest
    {
        /// <summary>
        /// 部门编码
        /// </summary>
        [JsonProperty("department_code")]
        public string DepartmentCode { get; set; }
    }
}
