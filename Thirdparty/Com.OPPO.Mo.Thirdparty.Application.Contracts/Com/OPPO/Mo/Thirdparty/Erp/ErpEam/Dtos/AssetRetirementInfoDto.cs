using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpEam.Dtos
{

    public class AssetRetirementInfoDto
    {
        /// <summary>
        /// 实例编号
        /// </summary>
        [JsonProperty("instance_number")]
        public string InstanceNumber { get; set; }
        /// <summary>
        /// 资产编号
        /// </summary>
        [JsonProperty("asset_number")]
        public string AssetNumber { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        [JsonProperty("description")] 
        public string Description { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        [JsonProperty("creation_date")] 
        public string CreationDate { get; set; }
        /// <summary>
        /// 原价
        /// </summary>
        [JsonProperty("original_cost")] 
        public double OriginalCost { get; set; }
        /// <summary>
        /// 预订/储备
        /// </summary>
        [JsonProperty("deprn_reserve")] 
        public double DeprnReserve { get; set; }
        /// <summary>
        /// 类别代码
        /// </summary>
        [JsonProperty("category_code")] 
        public string CategoryCode { get; set; }
        /// <summary>
        /// 书名
        /// </summary>
        [JsonProperty("book_name")] 
        public string BookName { get; set; }
        /// <summary>
        /// 剩余价值
        /// </summary>
        [JsonProperty("surplus_value")] 
        public double SurplusValue { get; set; }
        /// <summary>
        /// 付款公司OU
        /// </summary>
        [JsonProperty("ou_name")]
        public string OuName { get; set; }
        /// <summary>
        /// 组织代码
        /// </summary>
        [JsonProperty("org_code")]
        public string OrgCode { get; set; }
    }

}
