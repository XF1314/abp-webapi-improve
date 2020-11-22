using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Dtos
{
    /// <summary>
    /// 获取主体信息
    /// </summary>
    public class OnePlusErpCuxExOuVQueryDto
    {
        /// <summary>
        /// 组织Id
        /// </summary>
        [JsonProperty("ORG_ID")]
        public string OrgId { get; set; }

        /// <summary>
        /// 组织编码
        /// </summary>
        [JsonProperty("ORG_CODE")]
        public string OrgCode { get; set; }

        /// <summary>
        /// 组织名称
        /// </summary>
        [JsonProperty("ORG_NAME")]
        public string OrgName { get; set; }

        /// <summary>
        /// 主体本位币
        /// </summary>
        [JsonProperty("TARGET_CURRENCY_CODE")]
        public string TargetCurrencyCode { get; set; }

        /// <summary>
        /// 主体在PS系统中的ID
        /// </summary>
        [JsonProperty("PS_LE_ID")]
        public string PsLeId { get; set; }

        /// <summary>
        /// 主体在PS系统中的名称
        /// </summary>
        [JsonProperty("PS_LE_NAME")]
        public string PsLeName { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("COMPANY_SEG")]
        public string CompanySeg { get; set; }
    }
}
