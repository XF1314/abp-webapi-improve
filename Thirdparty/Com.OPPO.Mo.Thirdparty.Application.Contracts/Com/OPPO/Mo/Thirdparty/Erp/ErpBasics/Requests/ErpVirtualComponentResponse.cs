using Com.OPPO.Mo.Thirdparty.Erp.ErpBasics.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpBasics.Requests
{

    public class ErpVirtualComponentBody
    {
        /// <summary>
        /// 组件信息
        /// </summary>
        public List<VirtualComponentDto> results { get; set; }

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

    public class ErpVirtualComponentResponse
    {
        /// <summary>
        /// 返回信息
        /// </summary>
        [JsonProperty("response")]
        public ErpVirtualComponentBody Response { get; set; }
    }
}
