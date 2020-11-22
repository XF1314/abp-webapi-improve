using Newtonsoft.Json;
using System.Collections.Generic;

namespace Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Dtos
{
    /// <summary>
    /// 通道信息
    /// </summary>
    public class PsJobfunctionInfo
    {
        public PsJobfunctionInfo()
        {
            JobFunctions = new List<JobFunctionInfo>();
        }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalResults { get; set; }

        /// <summary>
        /// 通道信息
        /// </summary>
       [JsonProperty("functions")]
        public List<JobFunctionInfo> JobFunctions { get; set; }
        
    }

    public class JobFunctionInfo
    {
        /// <summary>
        /// 通道
        /// </summary>
        [JsonProperty("job_function")]
        public string JobFunction { get; set; }

        /// <summary>
        /// 通道描述
        /// </summary>
        [JsonProperty("function_desc")]
        public string Desc { get; set; }
    }
}
