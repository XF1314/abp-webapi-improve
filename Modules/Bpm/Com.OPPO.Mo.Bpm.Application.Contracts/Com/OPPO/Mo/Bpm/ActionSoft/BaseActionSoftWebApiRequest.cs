using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;

namespace Com.OPPO.Mo.Bpm
{
    /// <summary>
    /// ActionSoft基础WebApiRequest
    /// </summary>
    public class BaseActionSoftWebApiRequest : ISignatureBasedActionSoftWebApiRequest, ActionSoftWebApiAccessKeyInfo
    {
        /// <summary>
        /// <see cref="BaseActionSoftWebApiRequest"/>
        /// </summary>
        public BaseActionSoftWebApiRequest(string command)
        {
            Check.NotNullOrWhiteSpace(command, nameof(command));

            Command = command;
            DateTime = DateTime.Now;
        }

        /// <summary>
        /// 命令
        /// </summary>
        [JsonProperty("cmd")]
        public string Command { get; private set; }

        /// <summary>
        /// 格式
        /// </summary>
        [JsonProperty("format")]
        public string Format { get; } = MoBpmConsts.ActionSoftParamsFormat;

        /// <summary>
        /// 签名方法
        /// </summary>
        [JsonProperty("sig_method")]
        public string SignAlgorithm { get; } = MoBpmConsts.ActionSoftSignAlgorithm;

        /// <summary>
        /// 时间
        /// </summary>
        [JsonProperty("timestamp")]
        [JsonConverter(typeof(DateTimeMillisecondConverter))]
        public DateTime DateTime { get; private set; }

        /// <summary>
        /// 访问Key
        /// </summary>
        [JsonProperty("access_key")]
        public string AccessKey { get; set; }

        /// <summary>
        /// 参数签名
        /// </summary>
        [JsonIgnore]
        public string Sign { get; }
    }
}
