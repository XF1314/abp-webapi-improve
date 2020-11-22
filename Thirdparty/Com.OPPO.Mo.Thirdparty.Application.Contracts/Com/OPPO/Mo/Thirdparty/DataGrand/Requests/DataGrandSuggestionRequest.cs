using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Requests
{
    /// <summary>
    /// 达观搜索提示词请求模型
    /// </summary>
    public class DataGrandSuggestionRequest : BaseDataGrandDataRequest
    {
        /// <summary>
        /// 【必填项】用户输入的待自动补全的搜索关键词，例如“变”字，utf-8 编码，不可为空
        /// </summary>
        [JsonProperty("query")]
        public string Query { get; set; }

        /// <summary>
        /// 用户编码
        /// </summary>
        [JsonProperty("userid")]
        public string UserCode { get; set; }

        /// <summary>
        /// 要返回的结果条数，最大支持20，默认返回10条suggest结果
        /// </summary>
        [JsonProperty("cnt")]
        public int Count { get; set; }


    }
}
