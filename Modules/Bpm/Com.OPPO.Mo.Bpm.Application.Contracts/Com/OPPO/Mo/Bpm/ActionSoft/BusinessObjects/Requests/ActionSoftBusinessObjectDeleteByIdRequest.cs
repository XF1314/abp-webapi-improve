using Com.OPPO.Mo.Bpm.BusinessObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Requests
{
    /// <summary>
    /// ActionSoft业务对象按记录Id删除Request
    /// </summary>
    public class ActionSoftBusinessObjectDeleteByIdRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftBusinessObjectDeleteByIdRequest"/>
        /// </summary>
        public ActionSoftBusinessObjectDeleteByIdRequest() : base(ActionSoftBusinessObjectCommands.BusinessObjectDeleteById)
        { 
        
        }

        /// <summary>
        /// 【必填项】业务对象表名称
        /// </summary>
        [JsonRequired]
        [JsonProperty("boName")]
        public string BusinessObjectTableName { get; set; }

        /// <summary>
        /// 【必填项】业务对象记录Id
        /// </summary>
        [JsonRequired]
        [JsonProperty("boId")]
        public string BusinessObjectId { get; set; }
    }
}
