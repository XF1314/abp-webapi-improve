using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Request
{
    public class QueryPreparationRequest: PsHrBaseRequest
    {
        /// <summary>
        /// 需要查询的组织编号
        /// </summary>
       [JsonProperty("chkid")] 
        public string OrgCode { get; set; }

        /// <summary>
        /// 申请人数
        /// </summary>
        [JsonProperty("chknm")] 
        public string ApplierNum { get; set; }

    }




}
