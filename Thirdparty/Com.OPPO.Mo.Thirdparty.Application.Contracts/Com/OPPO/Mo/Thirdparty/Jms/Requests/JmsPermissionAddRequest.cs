using Com.OPPO.Mo.Thirdparty.Jms.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Jms.Requests
{
    /// <summary>
    /// 跳板机权限新增 request
    /// </summary>
    public class JmsPermissionAddRequest: BaseJmsRequest
    {
        /// <summary>
        /// 【必填项】<see cref="JmsRequestUserInfo"/>
        /// </summary>
        public JmsRequestUserInfo User { get; set; }

        /// <summary>
        /// 【必填项】<see cref="JmsPermissionApplyInfo"/>
        /// </summary>
        [JsonProperty("apply_info")]
        public JmsPermissionApplyInfo ApplyInfo { get; set; }

    }
}
