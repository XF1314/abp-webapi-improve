using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Dtos
{
    /// <summary>
    /// ActionSoft业务对象字段按流程更新Input
    /// </summary>
    public class ActionSoftBusinessObjectFieldUpdateByProcessInput
    {
        /// <summary>
        /// 【必填项】业务对象表名称
        /// </summary>
        [JsonRequired]
        public string BusinessObjectTableName { get; set; }

        /// <summary>
        /// 【必填项】绑定的流程实例Id
        /// </summary>
        [JsonRequired]
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 【必填项】Bo字段名称
        /// </summary>
        [JsonRequired]
        public string FieldName { get; set; }

        /// <summary>
        /// 【必填项】Bo字段值
        /// </summary>
        [JsonRequired]
        public string FieldValue { get; set; }
    }
}
