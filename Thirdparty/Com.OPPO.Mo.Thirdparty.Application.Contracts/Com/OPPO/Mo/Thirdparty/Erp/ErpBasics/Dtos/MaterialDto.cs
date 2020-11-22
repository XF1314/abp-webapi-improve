using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpBasics.Dtos
{

    public class MaterialDto
    {
        /// <summary>
        /// 组织id
        /// </summary>
        [JsonProperty("organization_id")]
        public int OrgId { get; set; }
        /// <summary>
        /// 类别id
        /// </summary>
        [JsonProperty("category_id")]
        public int CategoryId { get; set; }
        /// <summary>
        /// 组织代码
        /// </summary>
        [JsonProperty("organization_code")] 
        public string OrgCode { get; set; }
        /// <summary>
        /// 物料代码
        /// </summary>
        [JsonProperty("item_code")] 
        public string ItemCode { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [JsonProperty("description")] 
        public string Description { get; set; }
        /// <summary>
        /// 专业类别
        /// </summary>
        [JsonProperty("major_category")] 
        public string MajorCategory { get; set; }
        /// <summary>
        /// 次要类别
        /// </summary>
        [JsonProperty("minor_category")] 
        public string MinorCategory { get; set; }
        /// <summary>
        /// 主要计量单位代码
        /// </summary>
        [JsonProperty("primary_uom_code")] 
        public string PrimaryUomCode { get; set; }
        /// <summary>
        /// 物料类别
        /// </summary>
        [JsonProperty("item_type")] 
        public string ItemType { get; set; }
        /// <summary>
        /// 固定倍数
        /// </summary>
        [JsonProperty("fixed_lot_multiplier")] 
        public int FixedLotMultiplier { get; set; }
        /// <summary>
        /// 状态码
        /// </summary>
        [JsonProperty("status_code")] 
        public string StatusCode { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        [JsonProperty("create_date")]
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 上次更新日期
        /// </summary>
        [JsonProperty("last_update_date")] 
        public DateTime LastUpdateDate { get; set; }
        /// <summary>
        /// 采购模型
        /// </summary>
        [JsonProperty("purchase_model")] 
        public string PurchaseModel { get; set; }
        /// <summary>
        /// 采购员
        /// </summary>
        [JsonProperty("buyer")] 
        public string Buyer { get; set; }
        /// <summary>
        /// 采购员？
        /// </summary>
        [JsonProperty("buy_zykf")] 
        public string BuyZykf { get; set; }
        /// <summary>
        /// 探员姓名
        /// </summary>
        [JsonProperty("agent_name")] 
        public string AgentName { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        [JsonProperty("vmi_inv")] 
        public string VmiInv { get; set; }
    }
}
