using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Dtos
{
    /// <summary>
    /// 达观搜索高亮OutputItem
    /// </summary>
    public class DataGrandHighlightOutputItem
    {
        /// <summary>
        /// 目标字段名称
        /// </summary>
        [JsonProperty("target")]
        public string TargetFieldName { get; set; }

        /// <summary>
        /// 开始位置
        /// </summary>
        [JsonProperty("position")]
        public int Position { get; set; }

        /// <summary>
        /// 高亮长度
        /// </summary>
        [JsonProperty("length")]
        public int Length { get; set; }

    }
}
