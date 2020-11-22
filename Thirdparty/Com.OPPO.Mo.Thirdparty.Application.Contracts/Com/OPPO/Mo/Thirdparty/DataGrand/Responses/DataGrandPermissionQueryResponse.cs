using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Responses
{
    /// <summary>
    /// 达观搜索权限查询响应模型
    /// </summary>
    public class DataGrandPermissionQueryResponse : IDataGrandBaseResponse
    {
        /// <summary>
        /// <see cref="DataGrandPermissionQueryResponse"/>
        /// </summary>
        public DataGrandPermissionQueryResponse()
        {
            Roles = default(List<string>);
        }

        /// <summary>
        /// 响应状态
        /// </summary>
        [JsonProperty("status")]
        public DataGrandResponseStatus Status { get; set; }

        /// <summary>
        /// 用户所拥有的角色s
        /// </summary>
        [JsonProperty("roles", Required = Required.Default)]
        public List<string> Roles { get; set; }

        /// <summary>
        /// 本次请求Id（用于追踪问题）
        /// </summary>
        [JsonProperty("request_id")]
        public string RequestId { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        [JsonProperty("errors")]
        public string Errors { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        [JsonIgnore]
        public bool IsOk
        {
            get
            {
                return DataGrandResponseStatus.OK == Status;
            }
        }


    }
}
