using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Dtos
{
    /// <summary>
    /// ActionSoft业务对象创建Input
    /// </summary>
    public class ActionSoftBusinessObjectCreateInput
    {
        /// <summary>
        /// <see cref="ActionSoftBusinessObjectCreateInput"/>
        /// </summary>
        public ActionSoftBusinessObjectCreateInput()
        {
            BusinessObjectFields = new Dictionary<string, string>();
        }

        /// <summary>
        /// 【必填项】业务对象表名称
        /// </summary>
        [JsonRequired]
        public string BusinessObjectTableName { get; set; }

        /// <summary>
        /// 【必填项】业务对象字段s
        /// </summary>
        public Dictionary<string, string> BusinessObjectFields { get; set; }

        /// <summary>
        /// 【必填项】绑定的流程实例Id
        /// </summary>
        [JsonRequired]
        public string ProcessInstanceId { get; set; }

        /// <summary>
        /// 【选填项】拟制人工号，如果为空默认该记录以admin身份创建
        /// </summary>
        public string CreatorUserCode { get; set; }
    }
}
