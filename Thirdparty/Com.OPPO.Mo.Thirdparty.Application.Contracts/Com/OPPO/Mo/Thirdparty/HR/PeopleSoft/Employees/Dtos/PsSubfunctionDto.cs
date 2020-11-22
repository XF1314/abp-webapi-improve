using System.Collections.Generic;

namespace Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Dtos
{
    /// <summary>
    /// 领域信息
    /// </summary>
    public class PsSubfunctionDto
    {
        public PsSubfunctionDto()
        {
            Functions = new List<FunctionDto>();
        }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalResults { get; set; }

        /// <summary>
        /// 领域信息
        /// </summary>
        public List<FunctionDto> Functions { get; set; }
    }

    public class FunctionDto
    {
        /// <summary>
        /// 通道编码
        /// </summary>
        public string JobFunction { get; set; }

        /// <summary>
        /// 领域编码
        /// </summary>
        public string JobSubFunc { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Desc { get; set; }
    }
}
