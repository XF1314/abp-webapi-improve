using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Jms.Responses
{
    /// <summary>
    /// 跳板机业务主责人信息
    /// </summary>
    public class JmsBusinessOwnerInfo
    {
        /// <summary>
        /// 是否运维人员
        /// </summary>
        public bool IsOperator { get; set; }

        /// <summary>
        /// 运维主责人s
        /// </summary>
        [JsonProperty("operationOwner")]
        public List<JmsResponseUserInfo> OperationOwners { get; set; }

        /// <summary>
        /// 业务主责人s
        /// </summary>
        [JsonProperty("developOwner")]
        public List<JmsResponseUserInfo> DevelopOwners { get; set; }

        /// <summary>
        /// 测试主责人s
        /// </summary>
        [JsonProperty("testOwner")]
        public List<JmsResponseUserInfo> TestOwners { get; set; }
    }
}
