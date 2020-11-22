using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Requests
{
    /// <summary>
    /// 达观搜索提示词更新InputItem
    /// </summary>
    public class DataGrandSuggestionUpdateInputItem : BaseDataGrandSuggestionInputItem
    {
        /// <summary>
        /// <see cref="DataGrandSuggestionUpdateInputItem"/>
        /// </summary>
        /// <param name="itemId">提示词ItemId</param>
        public DataGrandSuggestionUpdateInputItem(string itemId)
        {
            ItemId = itemId;
            LastUpdateTime = DateTime.Now;
        }

        /// <summary>
        /// 【必填项】提示词
        /// </summary>
        [JsonProperty("keyword")]
        public string SuggestionWord { get; set; }

        /// <summary>
        /// 【必填项】提示词权重(0-10)
        /// </summary>
        [JsonProperty("weight")]
        public double Weight { get; set; }

        /// <summary>
        /// 【必填项】最后更新时间
        /// </summary>
        [JsonProperty("last_update_time")]
        [JsonConverter(typeof(DateTimeSecondConverter))]
        public DateTime LastUpdateTime { get; set; }
    }
}
