using Newtonsoft.Json;
using System.Collections.Generic;

namespace Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Dtos
{
    /// <summary>
    /// 领域信息
    /// </summary>
    public class PsSubfunctionInfo
    {
        public PsSubfunctionInfo()
        {
            Functions = new List<FunctionInfo>();
        }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalResults { get; set; }

        /// <summary>
        /// 领域信息
        /// </summary>
        public List<FunctionInfo> Functions { get; set; }     
    }

    public class FunctionInfo
    {
        /// <summary>
        /// 通道编码
        /// </summary>
        [JsonProperty("job_function")]
        public string JobFunction { get; set; }

        /// <summary>
        /// 领域编码
        /// </summary>
        [JsonProperty("job_sub_func")]
        public string JobSubFunc { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [JsonProperty("sub_desc")]
        public string Desc { get; set; }
    }
}
