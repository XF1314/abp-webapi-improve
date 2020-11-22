using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Responses
{
    /// <summary>
    /// 达观搜索提示词分页获取OutputItem
    /// </summary>
    public class DataGrandSuggestionQueryOutputItem
    {
        /// <summary>
        /// item的唯一id
        /// </summary>
        [JsonProperty("itemid")]
        public string ItemId { get; set; }

        /// <summary>
        /// 提示词
        /// </summary>
        [JsonProperty("keyword")]
        public string SuggestionWord { get; set; }

        /// <summary>
        /// 提示词权重（0~10）
        /// </summary>
        [JsonProperty("weight")]
        public double Weight { get; set; }

        /// <summary>
        /// <see cref="DataGrandSuggestionPermissionType"/>
        /// </summary>
        [JsonProperty("permission")]
        public DataGrandSuggestionPermissionType PermissionType { get; set; }

        /// <summary>
        /// 用户id，仅当permission为”private”时有值
        /// </summary>
        [JsonProperty("userid")]
        public string UserCode { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonProperty("create_time")]
        [JsonConverter(typeof(DateTimeSecondConverter))]
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        [JsonProperty("last_update_time")]
        [JsonConverter(typeof(DateTimeSecondConverter))]
        public DateTime LastUpdateTime { get; set; }

    }
}
