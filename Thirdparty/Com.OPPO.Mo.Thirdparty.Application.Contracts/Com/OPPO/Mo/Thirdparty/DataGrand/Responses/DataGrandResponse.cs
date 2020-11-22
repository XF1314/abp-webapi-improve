using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Responses
{
    /// <summary>
    /// 达观搜索响应模型
    /// </summary>
    public class DataGrandResponse<TError> : IDataGrandBaseResponse
    {
        /// <summary>
        /// 响应状态
        /// </summary>
        [JsonProperty("status")]
        public DataGrandResponseStatus Status { get; set; }

        /// <summary>
        /// 本次请求Id（用于追踪问题）
        /// </summary>
        [JsonProperty("request_id")]
        public string RequestId { get; set; }

        /// <summary>
        /// 网关消息
        /// </summary>
        [JsonProperty("message")]
        public string GatewayMessage { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        [JsonProperty("errors")]
        public TError Errors { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        [JsonIgnore]
        public bool IsOk
        {
            get
            {
                return Status == DataGrandResponseStatus.OK;
            }
        }
    }

    /// <summary>
    /// 达观搜索响应模型
    /// </summary>
    public class DataGrandResponse<TData, TError> : DataGrandResponse<TError>
    {
        /// <summary>
        /// <see cref="DataGrandResponse{TData, TError}"/>
        /// </summary>
        public DataGrandResponse()
        {
            ResultData = default(TData);
        }

        /// <summary>
        /// 响应数据
        /// </summary>
        [JsonProperty("result_data", Required = Required.Default)]
        public TData ResultData { get; set; }
    }
}
