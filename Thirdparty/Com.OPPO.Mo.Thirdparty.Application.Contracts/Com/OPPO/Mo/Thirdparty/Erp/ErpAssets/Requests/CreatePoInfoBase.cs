using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Requests
{

    public class  CreatePoInfoBase
    {
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
        /// 供应商代码
        /// </summary>
        [JsonProperty("vendor_code")]
        public string VendorCode { get; set; }
        /// <summary>
        /// 物料代码
        /// </summary>
        [JsonProperty("item_code")]
        public string ItemCode { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [JsonProperty("quantity")]
        public double Quantity { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        [JsonProperty("unit_price")]
        public double UnitPrice { get; set; }
        /// <summary>
        /// 税
        /// </summary>
        [JsonProperty("price_tax")]
        public double PriceTax { get; set; }
        /// <summary>
        /// 截止日期
        /// </summary>
        [JsonProperty("need_by_date")]
        [JsonConverter(typeof(DateStringConverter))]
        public DateTime NeedbyDate { get; set; }
        /// <summary>
        /// 申请者
        /// </summary>
        [JsonProperty("apply_by")]
        public string ApplyBy { get; set; }
        /// <summary>
        /// 解释
        /// </summary>
        [JsonProperty("comments")]
        public string Comments { get; set; }
        /// <summary>
        /// 文件编号
        /// </summary>
        [JsonProperty("doc_id")]
        public string DocId { get; set; }
        /// <summary>
        /// 单据名称 
        /// </summary>
        [JsonProperty("doc_name")]
        public string DocName { get; set; }
        /// <summary>
        /// 买方姓名
        /// </summary>
        [JsonProperty("buyer_name")]
        public string BuyerName { get; set; }
        /// <summary>
        /// 买方电话
        /// </summary>
        [JsonProperty("buyer_phone")]
        public string BuyerPhone { get; set; }
        /// <summary>
        /// 装运地址
        /// </summary>
        [JsonProperty("ship_address")]
        public string ShipAddress { get; set; }

    }


    public class CreatePo : CreatePoInfoBase
    {
        /// <summary>
        /// 文件编码
        /// </summary>
        [JsonProperty("doc_line_num")]
        public string DocLineNum { get; set; }
    }

}
