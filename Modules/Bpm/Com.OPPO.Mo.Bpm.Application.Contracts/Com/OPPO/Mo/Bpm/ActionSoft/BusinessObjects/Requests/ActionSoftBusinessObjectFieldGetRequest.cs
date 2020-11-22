using Com.OPPO.Mo.Bpm.BusinessObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Requests
{
    /// <summary>
    /// ActionSoft业务对象字段获取Request
    /// </summary>
    public class ActionSoftBusinessObjectFieldGetRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftBusinessObjectFieldGetRequest"/>
        /// </summary>
        public ActionSoftBusinessObjectFieldGetRequest() : base(ActionSoftBusinessObjectCommands.BusinessObjectFieldGetById)
        {

        }

        /// <summary>
        /// 【必填项】业务对象表名称
        /// </summary>
        [JsonRequired]
        [JsonProperty("boName")]
        public string BusinessObjectTableName { get; set; }

        /// <summary>
        /// 【必填项】业务对象Id
        /// </summary>
        [JsonRequired]
        [JsonProperty("boId")]
        public string BusinessObjectId { get; set; }

        /// <summary>
        /// 【必填项】业务对象字段名称
        /// </summary>
        [JsonRequired]
        [JsonProperty("fieldName")]
        public string FieldName { get; set; }
    }
}
