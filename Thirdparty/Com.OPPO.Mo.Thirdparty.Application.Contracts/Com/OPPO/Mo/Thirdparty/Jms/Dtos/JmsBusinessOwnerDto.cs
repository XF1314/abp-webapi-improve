using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Jms.Dtos
{
    /// <summary>
    /// 跳板机业务主责人Dto
    /// </summary>
    public class JmsBusinessOwnerDto
    {
        /// <summary>
        /// 是否运维人员
        /// </summary>
        public bool IsOperator { get; set; }

        /// <summary>
        /// 运维主责人s
        /// </summary>
        public List<JmsUserDto> OperationOwners { get; set; }

        /// <summary>
        /// 业务主责人s
        /// </summary>
        public List<JmsUserDto> DevelopOwners { get; set; }

        /// <summary>
        /// 测试主责人s
        /// </summary>
        public List<JmsUserDto> TestOwners { get; set; }
    }
}
