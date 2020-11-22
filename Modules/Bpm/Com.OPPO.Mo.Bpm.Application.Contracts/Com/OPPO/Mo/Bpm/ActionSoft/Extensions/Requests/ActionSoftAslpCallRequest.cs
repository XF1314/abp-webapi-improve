using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Extensions.Requests
{
    /// <summary>
    /// ActionSoft Aslp调用Request
    /// </summary>
    public class ActionSoftAslpCallRequest<TParams> : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftAslpCallRequest{TParams}"/>
        /// </summary>
        public ActionSoftAslpCallRequest(string aslpServiceAddress) : base(ActionSoftExtensionCommands.AslpCall)
        {
            Params = default;
            AslpServiceAddress = aslpServiceAddress;
        }

        /// <summary>
        /// 【必填项】Aslp服务地址
        /// </summary>
        [JsonProperty("aslp")]
        public string AslpServiceAddress { get; private set; }

        /// <summary>
        /// 【必填项】参数s
        /// </summary>
        [JsonIgnore]
        public TParams Params { get; set; }

        /// <summary>
        /// 参数s
        /// </summary>
        [JsonProperty("params")]
        private string @params => JsonConvert.SerializeObject(Params);

    }
}
