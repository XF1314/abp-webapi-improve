using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Requests
{
    /// <summary>
    /// 达观搜索提示词QueryRequest
    /// </summary>
    public class DataGrandSuggestionDataQueryRequest : BaseDataGrandSuggestionRequest
    {
        /// <summary>
        /// <see cref="DataGrandSuggestionDataQueryRequest"/>
        /// </summary>
        public DataGrandSuggestionDataQueryRequest()
        {
            Count = ThirdpartyConsts.DefaultDataGrandPageSize;
            Position = 0;
        }

        /// <summary>
        /// 【可空】用户输入的待自动补全的搜索关键词，例如“变”字，utf-8 编码，不可为空
        /// </summary>
        [JsonProperty("query")]
        public string Query { get; set; }

        /// <summary>
        /// 【必填项】分页返回结果的开始项，默认为0。
        /// 注意Position不是起始页数，而是当前页的起始条数。
        /// 比如每页返回条数cnt=10, 则第1页的pos=0, 第2页的pos=10,以此类推。
        /// </summary>
        [JsonProperty("pos")]
        public int Position { get; set; }


        /// <summary>
        /// 要返回的结果条数，最大支持20，默认返回10条suggest结果
        /// </summary>
        [JsonProperty("cnt")]
        public int Count { get; set; }
    }
}
