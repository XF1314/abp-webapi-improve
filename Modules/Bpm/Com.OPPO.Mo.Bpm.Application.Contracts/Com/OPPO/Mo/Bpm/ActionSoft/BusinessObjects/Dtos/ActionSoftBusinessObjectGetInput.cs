using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Dtos
{
    /// <summary>
    /// ActionSoft 业务对象获取Input
    /// </summary>
    public class ActionSoftBusinessObjectGetInput
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
    }
}
