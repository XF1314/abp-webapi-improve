using Com.OPPO.Mo.Thirdparty.DataGrand.Dtos;
using Com.OPPO.Mo.Thirdparty.DataGrand.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand
{
    /// <summary>
    /// 达观搜索模块数据查询OutputItem
    /// </summary>
    public class DataGrandModuleDataQueryOutputItem
    {
        /// <summary>
        /// <see cref="DataGrandModuleDataQueryOutputItem"/>
        /// </summary>
        public DataGrandModuleDataQueryOutputItem()
        {
            Highlights = new List<DataGrandHighlightOutputItem>();
        }

        /// <summary>
        /// 数据记录Id
        /// </summary>
        [JsonProperty("itemid")]
        public string ItemId { get;  set; }

        /// <summary>
        /// <see cref="MO2DataGrandDataCategory"/>
        /// </summary>
        [JsonProperty("cateid")]
        //[JsonConverter(typeof(StringEnumConverter))]
        public MO2DataGrandDataCategory DataCategory { get;  set; }

        /// <summary>
        /// 模块Id
        /// </summary>
        [JsonProperty("moduleid")]
        public string ModuleId { get; set; }


        /// <summary>
        /// 功能或流程模块名称
        /// </summary>
        [JsonProperty("modulename")]
        public string ModuleName { get; set; }

        /// <summary>
        /// <see cref="MO2DataGrandModuleType"/>
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public MO2DataGrandModuleType ModuleType { get; set; }

        /// <summary>
        /// 模块描述
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// 流程/功能控件参数名拼接，以,分割
        /// </summary>
        [JsonProperty("keywords")]
        [JsonConverter(typeof(MO2DataGrandStringListConverter))]
        public List<string> Keywords { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [JsonProperty("lastmodifytime")]
        [JsonConverter(typeof(DateTimeSecondConverter))]
        public DateTime LastModifyTime { get; set; }

        /// <summary>
        /// 匹配度
        /// </summary>
        [JsonProperty("sim_score")]
        public double Score { get; set; }

        /// <summary>
        /// 高亮s
        /// </summary>
        [JsonProperty("highlight")]
        public List<DataGrandHighlightOutputItem> Highlights { get; set; }
    }
}
