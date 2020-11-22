using Com.OPPO.Mo.Bpm.BusinessObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Requests
{
    /// <summary>
    /// ActionSoft业务对象字段按流程实例更新Request
    /// </summary>
    public class ActionSoftBusinessObjectFieldUpdateByProcessRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftBusinessObjectFieldUpdateByProcessRequest"/>
        /// </summary>
        public ActionSoftBusinessObjectFieldUpdateByProcessRequest() : base(ActionSoftBusinessObjectCommands.BusinessObjectFieldUpdateByProcess)
        {
        }

        /// <summary>
        /// 【必填项】业务对象表名称
        /// </summary>
        [JsonRequired]
        [JsonProperty("boName")]
        public string BusinessObjectTableName { get; set; }

        /// <summary>
        /// 【必填项】绑定的流程实例Id
        /// </summary>
        [JsonRequired]
        [JsonProperty("bindId")]
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 【必填项】业务对象字段名称
        /// </summary>
        [JsonRequired]
        [JsonProperty("fieldName")]
        public string FieldName { get; set; }

        /// <summary>
        /// 【必填项】业务对象字段值
        /// </summary>
        [JsonRequired]
        [JsonProperty("value")]
        public string FieldValue { get; set; }
    }
}
