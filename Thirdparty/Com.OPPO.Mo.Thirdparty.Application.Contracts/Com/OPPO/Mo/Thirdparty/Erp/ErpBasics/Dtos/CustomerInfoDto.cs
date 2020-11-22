using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpBasics.Dtos
{

    public class CustomerInfoDto
    {
        /// <summary>
        /// 客户/代理代码
        /// </summary>
        [JsonProperty("account_number")] 
        public string AccountNumber { get; set; }
        /// <summary>
        /// 客户/代理姓名
        /// </summary>
        [JsonProperty("party_name")] 
        public string PartyName { get; set; }
        /// <summary>
        /// 地点
        /// </summary>
        [JsonProperty("location")] 
        public string Location { get; set; }
        /// <summary>
        /// 站点使用代码
        /// </summary>
        [JsonProperty("site_use_code")] 
        public string SiteUseCode { get; set; }
        /// <summary>
        /// 组织id
        /// </summary>
        [JsonProperty("org_id")] 
        public string OrgId { get; set; }
        /// <summary>
        /// OUid
        /// </summary>
        [JsonProperty("ou_id")] 
        public string OuId { get; set; }
        /// <summary>
        /// OU名称
        /// </summary>
        [JsonProperty("ou_name")] 
        public string OuName { get; set; }
        /// <summary>
        /// 组织代码
        /// </summary>
        [JsonProperty("org_code")] 
        public string OrgCode { get; set; }
        /// <summary>
        /// 客户账号id
        /// </summary>
        [JsonProperty("cust_account_id")] 
        public string CustAccountId { get; set; }
        /// <summary>
        /// 客户帐户站点标识
        /// </summary>
        [JsonProperty("cust_acct_site_id")] 
        public string CustAcctSiteId { get; set; }
        /// <summary>
        /// 上次更新日期
        /// </summary>
        [JsonProperty("last_update_date")] 
        public DateTime LastUpdateDate { get; set; }
        /// <summary>
        /// 价目表id
        /// </summary>
        [JsonProperty("price_list_id")] 
        public string PriceListId { get; set; }
        /// <summary>
        /// 主要客户
        /// </summary>
        [JsonProperty("primary_customer")] 
        public string PrimaryCustomer { get; set; }
        /// <summary>
        /// 订单类型id
        /// </summary>
        [JsonProperty("order_type_id")] 
        public string OrderTypeId { get; set; }
        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("gstin")]
        public string Gstin { get; set; }
        /// <summary>
        /// 附录
        /// </summary>
        [JsonProperty("addess1")] 
        public string Addess { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [JsonProperty("state")] 
        public string State { get; set; }
        /// <summary>
        /// 属性1
        /// </summary>
        [JsonProperty("attr1")] 
        public string Attr1 { get; set; }
        /// <summary>
        /// 属性2
        /// </summary>
        [JsonProperty("attr2")] 
        public string Attr2 { get; set; }
        /// <summary>
        /// 属性3
        /// </summary>
        [JsonProperty("attr3")] 
        public string Attr3 { get; set; }
        /// <summary>
        /// 属性4
        /// </summary>
        [JsonProperty("attr4")] 
        public string Attr4 { get; set; }
        /// <summary>
        /// 属性5
        /// </summary>
        [JsonProperty("attr5")]
        public string Attr5 { get; set; }
        /// <summary>
        /// 区域名称
        /// </summary>
        [JsonProperty("territory_name")] 
        public string TerritoryName { get; set; }
    }
}
