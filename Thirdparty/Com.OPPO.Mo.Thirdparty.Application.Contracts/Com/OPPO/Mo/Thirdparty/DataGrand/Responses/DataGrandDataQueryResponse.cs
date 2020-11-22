using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Responses
{
    /// <summary>
    /// 达观搜索查询响应模型
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public class DataGrandDataQueryResponse<TData> : DataGrandResponse<string>
    {
        /// <summary>
        /// <see cref="DataGrandDataQueryResponse{TData}"/>
        /// </summary>
        public DataGrandDataQueryResponse()
        {
            ResultData = default(List<TData>);
        }

        /// <summary>
        /// 查询结果总数，如搜索失败，则resultcount值为-1
        /// </summary>
        [JsonProperty("result_count", Required = Required.Default)]
        public long TotalCount { get; set; }

        /// <summary>
        /// 查询结果
        /// </summary>
        [JsonProperty("result_data", Required = Required.Default)]
        public List<TData> ResultData { get; set; }
    }

    /// <summary>
    /// 达观搜索查询响应模型
    /// </summary>
    /// <typeparam name="TData">返回数据</typeparam>
    ///     /// <typeparam name="TError">返回错误</typeparam>
    public class DataGrandDataQueryResponse<TData, TError> : DataGrandResponse<TError>
    {
        /// <summary>
        /// <see cref="DataGrandDataQueryResponse{TData, TError}"/>
        /// </summary>
        public DataGrandDataQueryResponse()
        {
            TotalCount = -1;
            ResultData = default(List<TData>);
        }

        /// <summary>
        /// 查询结果总数，如搜索失败，则resultcount值为-1
        /// </summary>
        [JsonProperty("result_count",Required = Required.Default )]
        public long TotalCount { get; set; }

        /// <summary>
        /// 查询结果
        /// </summary>
        [JsonProperty("result_data", Required = Required.Default)]
        public List<TData> ResultData { get; set; }
    }
}
