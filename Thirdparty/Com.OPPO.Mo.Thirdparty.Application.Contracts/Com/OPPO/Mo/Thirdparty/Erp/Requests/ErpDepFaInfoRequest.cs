using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.Requests
{
    /// <summary>
    /// EAM-设备调拨_部门账户信息
    /// </summary>
    public class ErpDepFaInfoRequest : BaseEsbLanguageRequest
    {
        /// <summary>
        /// 转入部门
        /// </summary>
        [JsonProperty("dept_in")]
        public string DeptIn { get; set; }

        ///// <summary>
        ///// 语言
        ///// </summary>
        //[JsonProperty("language")]
        //public string Language { get; set; }

        /// <summary>
        /// 组织编码
        /// </summary>
        [JsonProperty("org_code")]
        public string OrgCode { get; set; }


    }
}
