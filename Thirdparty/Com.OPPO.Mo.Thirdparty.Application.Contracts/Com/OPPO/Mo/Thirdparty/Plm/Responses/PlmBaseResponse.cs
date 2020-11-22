using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Plm.Responses
{

    public class PlmBaseBody<TData>
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

        /// <summary>
        /// 返回数据
        /// </summary>
        [JsonProperty("data")] 
        public TData Data { get; set; }
    }

    public class PlmBaseResponse<TData>
    {
        /// <summary>
        /// 返回信息
        /// </summary>
        [JsonProperty("response")]
        public PlmBaseBody<TData> Response { get; set; }
    }


}
