using Com.OPPO.Mo.Thirdparty.DataGrand.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Responses
{
    /// <summary>
    /// 达观搜索提示词OutputItem
    /// </summary>
    public class DataGrandSuggestionOutputItem
    {
        /// <summary>
        /// 提示词
        /// </summary>
        [JsonProperty("suggest")]
        public string SuggestionWord { get; set; }

        /// <summary>
        /// 高亮s
        /// </summary>
        [JsonProperty("highlight")]
        public List<DataGrandHighlightOutputItem> Highlights { get; set; }

        /// <summary>
        /// 权重
        /// </summary>
        [JsonProperty("weight")]
        public double Weight { get; set; }

    }
}
