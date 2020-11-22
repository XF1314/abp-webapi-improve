using Newtonsoft.Json;
using System.Collections.Generic;

namespace Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Dtos
{
    /// <summary>
    /// 通道信息
    /// </summary>
    public class PsJobfunctionDto
    {
        public PsJobfunctionDto()
        {
            JobFunctions = new List<JobFunctionDto>();
        }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalResults { get; set; }

        /// <summary>
        /// 通道信息
        /// </summary>
        public List<JobFunctionDto> JobFunctions { get; set; }

    }

    public class JobFunctionDto
    {
        /// <summary>
        /// 通道代码
        /// </summary>
        public string JobFunction { get; set; }

        /// <summary>
        /// 通道描述
        /// </summary>
        public string Desc { get; set; }
    }

}
