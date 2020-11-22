using Com.OPPO.Mo.Bpm.BusinessObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Requests
{
    /// <summary>
    /// ActionSoft业务对象字段批量更新Request
    /// </summary>
    public class ActionSoftBusinessObjectFieldBatchUpdateRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftBusinessObjectFieldBatchUpdateRequest"/>
        /// </summary>
        public ActionSoftBusinessObjectFieldBatchUpdateRequest() : base(ActionSoftBusinessObjectCommands.BusinessObjectFieldBatchUpdateByBoId)
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
        [JsonIgnore]
        public string BusinessObjectId { get; set; }

        /// <summary>
        ///【必填项】需更新的业务对象字段s
        /// </summary>
        [JsonIgnore]
        public Dictionary<string, string> BusinessObjectFields { get; set; }

        /// <summary>
        /// Bo数据
        /// </summary>
        [JsonProperty("recordData")]
        public string BusinessObjectData
        {
            get
            {
                if (BusinessObjectFields.ContainsKey("ID"))
                    BusinessObjectFields["ID"] = BusinessObjectId;
                else
                    BusinessObjectFields["ID"] = BusinessObjectId;

                return JsonConvert.SerializeObject(BusinessObjectFields);
            }
        }
    }
}
