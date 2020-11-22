using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Dtos
{
    /// <summary>
    /// 银行信息
    /// </summary>
    public class OnePlusBankCardDto
    {
        /// <summary>
        /// ?
        /// </summary>
       [JsonProperty("BANK_CD")]
        public string BankCd { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("DESCR")]
        public string Descr { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("BRANCH_EC_CD")]
        public string BranchEcCd { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("DESCR1")]
        public string Descr1 { get; set; }

        /// <summary>
        /// 员工工号
        /// </summary>
        [JsonProperty("EMPLID")]
        public string EmplId { get; set; }

        /// <summary>
        /// 银行名称
        /// </summary>
        [JsonProperty("BANK_NM")]
        public string BankName { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("ACCOUNT_EC_ID")]
        public string AccountEcId { get; set; }

        /// <summary>
        /// 员工姓名
        /// </summary>
        [JsonProperty("NAME")]
        public string Name { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        [JsonProperty("COMPANY")]
        public string Company { get; set; }
    }
}
