using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpBasics.Responses
{
    /// <summary>
    /// 虚拟组件
    /// </summary>
    public class VirtualComponent
    {
        /// <summary>
        /// 组件编码
        /// </summary>
        public string ItemNumber { get; set; }
        /// <summary>
        /// 组件描述
        /// </summary>
        public string Description { get; set; }
    }
}
