using Com.OPPO.Mo.Bpm.BusinessObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Requests
{
    /// <summary>
    /// ActionSoft业务对象记录批量创建Request
    /// </summary>
    public class ActionSoftBusinessObjectBatchCreateRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftBusinessObjectBatchCreateRequest"/>
        /// </summary>
        public ActionSoftBusinessObjectBatchCreateRequest() : base(ActionSoftBusinessObjectCommands.BusinessObjectBatchCreateAndBindToProcess)
        { }

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
        public List<Dictionary<string, string>> BusinessObjectFields { get; set; }

        /// <summary>
        /// 【必填项】业务对象数据
        /// </summary>
        [JsonProperty("recordDatas")]
        public string BusinessObjectDatas => JsonConvert.SerializeObject(BusinessObjectFields);

        /// <summary>
        /// 【必填项】绑定的流程实例Id
        /// </summary>
        [JsonRequired]
        [JsonProperty("bindId")]
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 【选填项】拟制人工号，如果为空默认该记录以admin身份创建
        /// </summary>
        [JsonProperty("uid")]
        public string CreatorUserCode { get; set; }


    }
}
