using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Requests
{
    /// <summary>
    /// 达观搜索用户搜索行为新增InputItem
    /// </summary>
    public class DataGrandUserSearchBehaviorAddInputItem : BaseDataGrandUserBehaviorInputItem
    {
        /// <summary>
        /// <see cref="DataGrandUserSearchBehaviorAddInputItem"/>
        /// </summary>
        /// <param name="userCode">用户编码</param>
        /// <param name="dataCategory"><see cref="MO2DataGrandDataCategory"/></param>
        /// <param name="query">关键字</param>
        public DataGrandUserSearchBehaviorAddInputItem(string userCode, MO2DataGrandDataCategory dataCategory,string query) : base(userCode, dataCategory, MO2DataGrandBehaviorType.search, "2")
        {
            SortField = "default";
            Query = query;
        }

        /// <summary>
        /// 【搜索行为】用户搜索词
        /// </summary>
        [JsonProperty("query")]
        public string Query { get; private set; }

        /// <summary>
        /// 【搜索行为】用户搜索分页起始位置
        /// </summary>
        [JsonProperty("from")]
        public long Position { get; set; }

        /// <summary>
        /// 【搜索行为】用户搜索分页大小
        /// </summary>
        [JsonProperty("size")]
        public long Count { get; set; }

        /// <summary>
        /// 【搜索行为】搜索时使用的排序字段，未提供则使用“default”。可以为：“time”，“score”，“weighted”
        /// </summary>
        [JsonProperty("sort")]
        public string SortField { get; set; }

        /// <summary>
        /// 【搜索行为】搜索召回的条目个数
        /// </summary>
        [JsonProperty("result_count")]
        public long ResultTotalCount { get; set; }

        /// <summary>
        /// 【搜索行为】搜索接口调用所耗费的时间（单位：毫秒）
        /// </summary>
        [JsonProperty("resp_time")]
        public long QueryElapseMilliseconds { get; set; }
    }
}
