using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Jms.Requests
{
    /// <summary>
    /// 跳板机业务Owner query request
    /// </summary>
     public class JmsBusinessOwnerQueryRequest: BaseJmsRequest
    {
        /// <summary>
        /// 【必填项】用户工号
        /// </summary>
        [JsonProperty("userJobNumber")]
        public string UserCode { get; set; }

        /// <summary>
        /// 【必填项】业务树,譬如:["/a/b","/a/b/c","/x/y"]
        /// </summary>
        public List<string > Business { get; set; }
    }
}
