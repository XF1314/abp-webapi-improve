using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Dtos
{
    /// <summary>
    /// ActionSoft业务对象查询Input
    /// </summary>
    public class ActionSoftBusinessObjectQueryInput
    {
        /// <summary>
        /// 【必填项】业务对象表名称
        /// </summary>
        [JsonRequired]
        public string BusinessObjectTableName { get; set; }

        /// <summary>
        /// 【选填项】查询条件<see cref="List{ActionSoftQueryCondition}"/>
        /// </summary>
        [JsonRequired]
        public List<ActionSoftQueryCondition> QueryConditions { get; set; }

        /// <summary>
        /// 【选填项】排序条件<see cref="SortedList{TKey, ActionSoftOrderCondition}"/>
        /// </summary>
        [JsonRequired]
        public SortedList<int, ActionSoftOrderCondition> OrderConditions { get; set; }

        /// <summary>
        /// 【选填项】首记录
        /// </summary>
        public int Offset { get; set; } = 0;

        /// <summary>
        /// 【选填项】记录条数
        /// </summary>
        public int Count { get; set; } = 20;
    }
}
