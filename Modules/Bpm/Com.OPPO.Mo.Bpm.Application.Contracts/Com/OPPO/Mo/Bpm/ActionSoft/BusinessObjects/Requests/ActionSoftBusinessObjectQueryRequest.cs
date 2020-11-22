using Com.OPPO.Mo.Sql;
using Com.OPPO.Mo.Bpm.BusinessObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime;

namespace Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Requests
{
    /// <summary>
    /// ActionSoft业务对象查询Request
    /// </summary>
    public class ActionSoftBusinessObjectQueryRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftBusinessObjectQueryRequest"/>
        /// </summary>
        public ActionSoftBusinessObjectQueryRequest() : base(ActionSoftBusinessObjectCommands.BusinessObjectQuery)
        {

        }

        /// <summary>
        /// 【必填项】业务对象表名称
        /// </summary>
        [JsonRequired]
        [JsonProperty("boName")]
        public string BusinessObjectTableName { get; set; }

        /// <summary>
        /// 【选填项】查询条件<see cref="List{ActionSoftQueryCondition}"/>
        /// </summary>
        [JsonIgnore]
        public List<ActionSoftQueryCondition> QueryConditions { get; set; }

        /// <summary>
        /// 【选填项】排序条件<see cref="SortedList{TKey, ActionSoftOrderCondition}"/>
        /// </summary>
        [JsonIgnore]
        public SortedList<int, ActionSoftOrderCondition> OrderConditions { get; set; }

        /// <summary>
        /// 【选填项】查询条件
        /// </summary>
        [JsonProperty("querys")]
        public string QueryBy
        {
            get
            {
                if (QueryConditions == null || !QueryConditions.Any())
                    return string.Empty;
                else
                {
                    var queries = QueryConditions
                         .Select(x => new List<string> { $"{x.FieldName} {x.ComparisonOperator.Description()}", x.FieldValue });

                    return JsonConvert.SerializeObject(queries);
                }
            }
        }

        /// <summary>
        /// 【选填项】排序条件
        /// </summary>
        public string OrderBy
        {
            get
            {
                var orderBy = string.Empty;
                if (OrderConditions != null && OrderConditions.Any())
                    OrderConditions.Aggregate(orderBy, (x, y) => $"{x}{y.Value.FieldName} {y.Value.SortType},");

                return orderBy.TrimEnd(',');
            }
        }

        /// <summary>
        /// 【选填项】首记录
        /// </summary>
        [JsonProperty("firstRow")]
        public int Offset { get; set; } = 0;

        /// <summary>
        /// 【选填项】记录条数
        /// </summary>
        [JsonProperty("rowCount")]
        public int Count { get; set; } = 20;

    }


}
