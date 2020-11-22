using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpBasics.Dtos
{

    /// <summary>
    /// 虚拟组件
    /// </summary>
    public class VirtualComponentDto
    {
        /// <summary>
        /// 组件编码
        /// </summary>
        [JsonProperty("ph_item_num")]
        public string ItemNumber { get; set; }
        /// <summary>
        /// 组件描述
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
