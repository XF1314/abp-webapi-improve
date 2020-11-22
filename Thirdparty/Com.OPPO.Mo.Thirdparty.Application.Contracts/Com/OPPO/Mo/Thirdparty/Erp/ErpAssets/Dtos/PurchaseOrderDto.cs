using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Dtos
{

    public class PurchaseOrderDto
    {
        /// <summary>
        /// PO码
        /// </summary>
        [JsonProperty("PO_NUM")]
        public string PoNum { get; set; }

        /// <summary>
        /// 物料代码
        /// </summary>
        [JsonProperty("ITEM_CODE")]
        public string ItemCode { get; set; }
        /// <summary>
        /// 单据名称 
        /// </summary>
        [JsonProperty("DOC_NAME")]
        public string DocName { get; set; }
        /// <summary>
        /// 物料描述
        /// </summary>
        [JsonProperty("ITEM_DESC")]
        public string ItemDesc { get; set; }

        /// <summary>
        /// 本次请求Id（用于追踪问题）
        /// </summary>
        [JsonProperty("REQUEST_ID")]
        public string RequestId { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        [JsonProperty("ERR_MSG")]
        public string ErrMsg { get; set; }
        /// <summary>
        /// 文件编码
        /// </summary>
        [JsonProperty("DOC_LINE_NUM")]
        public string DocLineNum { get; set; }
        /// <summary>
        /// 序列号
        /// </summary>
        [JsonProperty("SEQ_ID")]
        public int SeqId { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        [JsonProperty("UNIT_PRICE")]
        public string UnitPrice { get; set; }
        /// <summary>
        /// 接受数量
        /// </summary>
        [JsonProperty("RECEIVE_QTY")]
        public int ReceiveQty { get; set; }

        /// <summary>
        /// 文件编号
        /// </summary>
        [JsonProperty("DOC_ID")]
        public string DocId { get; set; }
        /// <summary>
        /// 供应商代码
        /// </summary>
        [JsonProperty("VENDOR_CODE")]
        public string VendorCode { get; set; }
        /// <summary>
        /// 接受编码
        /// </summary>
        [JsonProperty("RECEIVE_NUM")]
        public string ReceiveNum { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [JsonProperty("STATE")]
        public int State { get; set; }
        /// <summary>
        /// 税
        /// </summary>
        [JsonProperty("PRICE_TAX")]
        public double PriceTax { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [JsonProperty("QUANTITY")]
        public string Quantity { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [JsonProperty("COMMENTS")]
        public string Comments { get; set; }
        /// <summary>
        /// 买方姓名
        /// </summary>
        [JsonProperty("BUYER_NAME")]
        public string BuyerName { get; set; }
        /// <summary>
        /// 买方电话
        /// </summary>
        [JsonProperty("BUYER_PHONE")]
        public string BuyerPhone { get; set; }
        /// <summary>
        /// 截止日期,返回的是时间戳
        /// </summary>
        [JsonProperty("NEED_BY_DATE")]
        public long NeedbyDate { get; set; }
        /// <summary>
        /// 申请者
        /// </summary>
        [JsonProperty("APPLY_BY")]
        public string ApplyBy { get; set; }
        /// <summary>
        /// 装运地址
        /// </summary>
        [JsonProperty("SHIP_ADDRESS")]
        public string ShipAddress { get; set; }
        /// <summary>
        /// 组织代码
        /// </summary>
        [JsonProperty("ORG_CODE")]
        public string OrgCode { get; set; }

        /// <summary>
        /// 采购单号
        /// </summary>
        [JsonProperty("PO_LINE_NUM")]
        public int? PoLineNum { get; set; }

        /// <summary>
        /// 付款公司OU
        /// </summary>
        [JsonProperty("OU_NAME")]
        public string OuName { get; set; }
    }


}
