using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Upm.Responses
{

    public class UpmBaseResponse 
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        [JsonProperty("success")]
        public string success { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        [JsonProperty("message")] 
        public string message { get; set; }
        /// <summary>
        /// 原因
        /// </summary>
        [JsonProperty("cause")] 
        public string cause { get; set; }
        /// <summary>
        /// 返回编码
        /// </summary>
        [JsonProperty("resultCode")] 
        public string resultCode { get; set; }

    }

    public class UpmBaseResponse<TData> : UpmBaseResponse
    {
        /// <summary>
        /// <see cref="UpmBaseResponse{TData}"/>
        /// </summary>
        public UpmBaseResponse()
        {
            body = default;
        }

        /// <summary>
        /// 响应内容
        /// </summary>
        [JsonProperty("body")]
        public TData body { get; set; }
    }


}
