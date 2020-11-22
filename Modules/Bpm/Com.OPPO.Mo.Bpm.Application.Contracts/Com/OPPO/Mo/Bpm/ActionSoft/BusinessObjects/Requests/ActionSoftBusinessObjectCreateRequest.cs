using Com.OPPO.Mo.Bpm.BusinessObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Requests
{
    /// <summary>
    /// ActionSoft业务对象创建Request
    /// </summary>
    public class ActionSoftBusinessObjectCreateRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftBusinessObjectCreateRequest"/>
        /// </summary>
        public ActionSoftBusinessObjectCreateRequest() : base(ActionSoftBusinessObjectCommands.BusinessObjectCreateAndBindToProcess)
        {
        }

        /// <summary>
        /// 【必填项】业务对象表名称
        /// </summary>
        [JsonRequired]
        [JsonProperty("boName")]
        public string BusinessObjectTableName { get; set; }

        /// <summary>
        /// 【必填项】业务对象字段s
        /// </summary>
        [JsonIgnore]
        public Dictionary<string, string> BusinessObjectFields { get; set; }

        /// <summary>
        ///【必填项】业务对象数据
        /// </summary>
        [JsonProperty("recordData")]
        public string BusinessObjectData => JsonConvert.SerializeObject(BusinessObjectFields);

        /// <summary>
        /// 【必填项】绑定的流程实例Id
        /// </summary>
        [JsonRequired]
        [JsonProperty("bindId")]
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 【选填项】拟制人帐号，如果为空默认该记录以admin身份创建
        /// </summary>
        [JsonProperty("uid")]
        public string CreatorUserCode { get; set; }
    }
}
