using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr
{
    public class PsHrBaseRequest:ISecret,IAppIdInfo
    {
        /// <summary>
        /// 接口授权用户,必填
        /// </summary>
        [JsonProperty("appid")]
        public string AppId { get; set; }

        /// <summary>
        ///加密串,必填
        /// </summary>
        [JsonProperty("secret")]
        public string Secret { get; set; }
    }
}
