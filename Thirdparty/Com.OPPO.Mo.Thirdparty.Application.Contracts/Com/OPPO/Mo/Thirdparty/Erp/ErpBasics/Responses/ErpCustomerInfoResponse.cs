using Com.OPPO.Mo.Thirdparty.Erp.ErpBasics.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpBasics.Responses
{

    public class CustomerInfo
    {
        /// <summary>
        /// 客户/代理代码
        /// </summary>
        public string AccountNumber { get; set; }
        /// <summary>
        /// 客户/代理姓名
        /// </summary>
        public string PartyName { get; set; }
        /// <summary>
        /// 地点
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// 站点使用代码
        /// </summary>
        public string SiteUseCode { get; set; }
        /// <summary>
        /// 组织id
        /// </summary>
        public string OrgId { get; set; }
        /// <summary>
        /// OUid
        /// </summary>
        public string OuId { get; set; }
        /// <summary>
        /// OU名称
        /// </summary>
        public string OuName { get; set; }
        /// <summary>
        /// 组织代码
        /// </summary>
        public string OrgCode { get; set; }
        /// <summary>
        /// 客户账号id
        /// </summary>
        public string CustAccountId { get; set; }
        /// <summary>
        /// 客户帐户站点标识
        /// </summary>
        public string CustAcctSiteId { get; set; }
        /// <summary>
        /// 上次更新日期
        /// </summary>
        public DateTime LastUpdateDate { get; set; }
        /// <summary>
        /// 价目表id
        /// </summary>
        public string PriceListId { get; set; }
        /// <summary>
        /// 主要客户
        /// </summary>
        public string PrimaryCustomer { get; set; }
        /// <summary>
        /// 订单类型id
        /// </summary>
        public string OrderTypeId { get; set; }
        /// <summary>
        /// ?
        /// </summary>
        public string Gstin { get; set; }
        /// <summary>
        /// 附录
        /// </summary>
        public string Addess { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 属性1
        /// </summary>
        public string Attr1 { get; set; }
        /// <summary>
        /// 属性2
        /// </summary>
        public string Attr2 { get; set; }
        /// <summary>
        /// 属性3
        /// </summary>
        public string Attr3 { get; set; }
        /// <summary>
        /// 属性4
        /// </summary>
        public string Attr4 { get; set; }
        /// <summary>
        /// 属性5
        /// </summary>
        public string Attr5 { get; set; }
        /// <summary>
        /// 区域名称
        /// </summary>
        public string TerritoryName { get; set; }
    }

    public class ErpCustomerInfoBody
    {
        /// <summary>
        /// 客户信息集合
        /// </summary>
        public List<CustomerInfoDto> results { get; set; }

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

    public class ErpCustomerInfoResponse
    {
        /// <summary>
        /// 返回数据
        /// </summary>
        [JsonProperty("response")] 
        public ErpCustomerInfoBody Response { get; set; }
    }

}
