using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Dtos
{
    /// <summary>
    /// ActionSoft业务对象字段按流程获取Input
    /// </summary>
    public class ActionSoftBusinessObjectFieldGetInput
    {
        /// <summary>
        /// 【必填项】业务对象表名称
        /// </summary>
        [JsonRequired]
        public string BusinessObjectTableName { get; set; }

        /// <summary>
        /// 【必填项】业务对象IdId
        /// </summary>
        [JsonRequired]
        public string BusinessObjectId { get; set; }

        /// <summary>
        /// 【必填项】业务对象字段名称
        /// </summary>
        [JsonRequired]
        public string FieldName { get; set; }
    }
}
