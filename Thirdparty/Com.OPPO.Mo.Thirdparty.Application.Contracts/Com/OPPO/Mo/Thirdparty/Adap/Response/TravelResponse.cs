using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Adap.Response
{
    public class TravelResponse
    {
        /// <summary>
        /// 返回编码
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        [JsonProperty("msg")]
        public string Message { get; set; }

        /// <summary>
        /// 响应体
        /// </summary>
        public TravelResopnseBody Body { get; set; }
    }


    public class TravelResopnseBody
    {
        /// <summary>
        /// 返回编码
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        [JsonProperty("msg")]
        public string Message { get; set; }

    }

}
