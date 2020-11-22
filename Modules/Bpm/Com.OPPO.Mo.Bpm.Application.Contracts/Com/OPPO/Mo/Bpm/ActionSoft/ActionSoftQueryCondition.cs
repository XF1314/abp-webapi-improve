using Com.OPPO.Mo.Sql;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft
{
    /// <summary>
    /// ActionSoft查询条件
    /// </summary>
    public class ActionSoftQueryCondition
    {
        /// <summary>
        /// 字段名称，支持公共字段和自定义的业务字段,其中公共字段：
        /// （ID-业务对象Id；ORGID-组织编码；BINDID-流程实例Id；CREATEDATE-创建时间；
        /// CREATEUSER-创建人工号；UPDATEDATE-更新时间；UPDATEUSER-更新人工号；PROCESSDEFID-流程定义Id；）
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// <see cref="SqlComparisonOperator"/>
        /// </summary>
        public SqlComparisonOperator ComparisonOperator { get; set; }

        /// <summary>
        /// 字段值
        /// </summary>
        [JsonProperty("value")]
        public string FieldValue { get; set; }
    }
}
