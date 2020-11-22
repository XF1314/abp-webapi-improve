using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Extensions.Requests
{
    /// <summary>
    /// ActionSoft会话Id获取Request
    /// </summary>
    public class ActionSoftSessionIdGetRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftSessionIdGetRequest"/>
        /// </summary>
        public ActionSoftSessionIdGetRequest() : base(ActionSoftExtensionCommands.SessionIdGet)
        {

        }

        /// <summary>
        /// 【必填项】用户编码
        /// </summary>
        [JsonProperty("uid")]
        public string UserCode { get; set; }

        /// <summary>
        ///【必填项】 Ip地址
        /// </summary>
        [JsonProperty("ip")]
        public string Ip { get; set; }

        /// <summary>
        /// 【必填项】<see cref="ActionSoftLanguageType"/>
        /// </summary>
        [JsonProperty("lang")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ActionSoftLanguageType Language { get; set; } = ActionSoftLanguageType.cn;

        /// <summary>
        /// 【必填项】<see cref="ActionSoftDeviceType"/>
        /// </summary>
        [JsonProperty("deviceType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ActionSoftDeviceType DeviceType { get; set; } = ActionSoftDeviceType.pc;


    }
}
