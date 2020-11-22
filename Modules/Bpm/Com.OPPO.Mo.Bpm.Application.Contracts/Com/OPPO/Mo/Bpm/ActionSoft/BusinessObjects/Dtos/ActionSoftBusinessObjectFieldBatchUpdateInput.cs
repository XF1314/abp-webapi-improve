using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Dtos
{
    /// <summary>
    /// ActionSoft业务对象字段批量更新
    /// </summary>
    public class ActionSoftBusinessObjectFieldBatchUpdateInput
    {
        /// <summary>
        /// 【必填项】业务对象表名称
        /// </summary>
        [JsonRequired]
        public string BusinessObjectTableName { get; set; }

        /// <summary>
        /// 【必填项】业务对象Id
        /// </summary>
        [JsonRequired]
        public string BusinessObjectId { get; set; }

        /// <summary>
        ///【必填项】业务对象字段s
        /// </summary>
        [JsonRequired]
        public Dictionary<string, string> BusinessObjectFields { get; set; }
    }
}
