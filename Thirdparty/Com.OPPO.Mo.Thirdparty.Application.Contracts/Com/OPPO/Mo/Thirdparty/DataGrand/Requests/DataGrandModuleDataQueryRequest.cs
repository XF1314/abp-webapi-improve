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
    /// 达观搜索模块数据查询请求模型
    /// </summary>
    public class DataGrandModuleDataQueryRequest : BaseDataGrandDataRequest
    {
        /// <summary>
        /// <see cref="DataGrandModuleDataQueryRequest"/>
        /// </summary>
        /// <param name="languageType"><see cref="MO2DataGrandLanguageType"/></param>
        public DataGrandModuleDataQueryRequest(MO2DataGrandLanguageType languageType = MO2DataGrandLanguageType.Default)
        {
            ExactFilterItems = new Dictionary<string, string>();
            FuzzyFilterItems = new Dictionary<string, string>();
            DatetimeFilterItems = new List<DataGrandDatetimeComparision>();
            DataCategory = MO2DataGrandDataCategory.module;
            LanguageType = languageType;

            Count = ThirdpartyConsts.DefaultDataGrandPageSize;
            Position = 0;
        }

        /// <summary>
        /// <see cref="MO2DataGrandLanguageType"/>
        /// </summary>
        [JsonIgnore]
        public MO2DataGrandLanguageType LanguageType { get; private set; }

        /// <summary>
        /// 【必填项】 业务系统中数据场景<see cref="MO2DataGrandDataCategory"/>
        /// </summary>
        [JsonProperty("scene")]
        [JsonConverter(typeof(StringEnumConverter))]
        public MO2DataGrandDataCategory DataCategory { get; private set; }

        /// <summary>
        /// 【必填项】用户编码
        /// </summary>
        [JsonProperty("userid")]
        public string UserCode { get; set; }

        /// <summary>
        /// 多字段精确匹配查询
        /// </summary>
        [JsonIgnore]
        public Dictionary<string, string> ExactFilterItems { get; set; }

        /// <summary>
        /// 多字段精确匹配查询，filter=status:1+stage_statue:2，
        /// 查询发文状态为1，环节状态为2的发文，详见通用接口描述中关于filter的用法
        /// </summary>
        [JsonProperty("filter")]
        public string Filter
        {
            get
            {
                var languageFilter = string.Format("{0},{1}", (int)LanguageType, (int)MO2DataGrandLanguageType.Default);
                if (ExactFilterItems.ContainsKey(DataGrandModuleDataAddInputItem.LANGUAGE_TYPE))
                    ExactFilterItems[DataGrandModuleDataAddInputItem.LANGUAGE_TYPE] = languageFilter;
                else
                {
                    ExactFilterItems.Add(DataGrandModuleDataAddInputItem.LANGUAGE_TYPE, languageFilter);
                }

                var filters = ExactFilterItems.Select(x => string.Format("{0}:{1}",
                    x.Key.Replace("+", "").Replace(":", ""), x.Value.Replace("+", "").Replace(":", "")));
                var bytes = Encoding.UTF8.GetBytes(string.Join("+", filters));
                return Encoding.UTF8.GetString(bytes);
            }
        }

        /// <summary>
        /// 多字段模糊匹配
        /// </summary>
        [JsonIgnore]
        public Dictionary<string, string> FuzzyFilterItems { get; set; }

        /// <summary>
        /// 多字段模糊匹配，fuzzy=title:请假+content:请假天数，
        /// 查询title中包含“请假”及content中包含“请假天数”的发文。le:请假+abstract:印度请假
        /// </summary>
        [JsonProperty("fuzzy")]
        public string Fuzzy
        {
            get
            {
                var fuzzys = FuzzyFilterItems.Select(x => string.Format("{0}:{1}",
                    x.Key.Replace("+", "").Replace(":", ""), x.Value.Replace("+", "").Replace(":", "")));
                var bytes = Encoding.UTF8.GetBytes(string.Join("+", fuzzys));
                return Encoding.UTF8.GetString(bytes);
            }
        }

        /// <summary>
        /// 时间过滤查询
        /// </summary>
        [JsonIgnore]
        public List<DataGrandDatetimeComparision> DatetimeFilterItems { get; set; }

        /// <summary>
        /// 区间筛选，如range=publish_time>=1561778412，查询发文时间大于“1561778412”的发文
        /// </summary>
        [JsonProperty("range")]
        public string Range
        {
            get
            {
                if (!DatetimeFilterItems.Any())
                    return string.Empty;
                else
                {
                    var filters = DatetimeFilterItems.Select(x =>
                    {
                        if (x.comparisonOperator == DataGrandDatetimeComparisonOperator.GreaterOrEqual)
                            return string.Format("{0}>={1}", x.DateTimeFieldName, x.DateTimeStamp);
                        else if (x.comparisonOperator == DataGrandDatetimeComparisonOperator.LessOrEqual)
                            return string.Format("{0}<={1}", x.DateTimeFieldName, x.DateTimeStamp);
                        else
                        {
                            throw new Exception(string.Format("不支持的时间比较符类型:{0}。", x.comparisonOperator.ToString()));
                        }
                    });

                    var bytes = Encoding.UTF8.GetBytes(string.Join("+", filters));
                    return Encoding.UTF8.GetString(bytes);
                }
            }
        }

        /// <summary>
        /// 【必填项】搜索查询词，utf-8 编码,允许在某些情况下留空
        /// </summary>
        [JsonProperty("query")]
        public string Query { get; set; }

        /// <summary>
        /// 分页返回结果的开始项，默认为0。
        /// 注意Position不是起始页数，而是当前页的起始条数。
        /// 比如每页返回条数cnt=10, 则第1页的pos=0, 第2页的pos=10,以此类推。
        /// </summary>
        [JsonProperty("pos")]
        public int Position { get; set; }

        /// <summary>
        /// 每页返回的结果条数，默认为20，最大为50，
        /// 例如当pos为10，cnt为20时，返回搜索结果的第10-30条结果。
        /// </summary>
        [JsonProperty("cnt")]
        public int Count { get; set; }


    }
}
