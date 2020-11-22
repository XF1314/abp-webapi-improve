using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.Dtos
{
    /// <summary>
    /// 业务对象归属授权Input
    /// </summary>
    public class BusinessObjectBelongGrantInput
    {
        /// <summary>
        /// 【必填项】业务对象Id
        /// </summary>
        [JsonRequired]
        public string BusinessObjectId { get; set; }

        /// <summary>
        /// 【必填项】应用Id
        /// </summary>
        [JsonRequired]
        public string AppId { get; set; }


    }
}
