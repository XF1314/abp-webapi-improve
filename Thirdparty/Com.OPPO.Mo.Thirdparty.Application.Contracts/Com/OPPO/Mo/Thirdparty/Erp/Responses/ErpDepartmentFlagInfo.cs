using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.Responses
{
    /// <summary>
    /// 部门信息
    /// </summary>
    public class ErpDepartmentFlagInfo
    {
        /// <summary>
        /// 是否存在：Y：存在；N：不存在
        /// </summary>
        [JsonProperty("dept_exists_flag")]
        public string DeptExistsFlag { get; set; }
    }
}
