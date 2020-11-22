using Com.OPPO.Mo.Thirdparty.Erp.ErpBasics.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpBasics.Responses
{

    public class OrgInfo
    {
        /// <summary>
        /// 组织id
        /// </summary>
        public int OrgId { get; set; }
        /// <summary>
        /// 组织代码
        /// </summary>
        public string OrgCode { get; set; }
        /// <summary>
        /// 组织类型
        /// </summary>
        public string OrgType { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 上次更新日期
        /// </summary>
        public DateTime LastUpdateDate { get; set; }
    }

    public class ErpOrgInfoBody
    {
        /// <summary>
        /// 组织信息条数
        /// </summary>
        public int RowCount { get; set; }
        /// <summary>
        /// 组织信息
        /// </summary>
        public List<OrgInfo> Datas { get; set; }

    }

    public class ErpOrgInfoResponse
    {
        /// <summary>
        /// 返回信息
        /// </summary>
        [JsonProperty("response")] 
        public ErpOrgInfoBodyDto Response { get; set; }
    }

}
