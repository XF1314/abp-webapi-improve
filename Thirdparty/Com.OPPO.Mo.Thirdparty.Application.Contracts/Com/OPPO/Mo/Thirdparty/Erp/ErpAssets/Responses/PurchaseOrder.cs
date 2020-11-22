using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Responses
{

    public class PurchaseOrder
    {
        /// <summary>
        /// PO码
        /// </summary>
        public string PoNum { get; set; }

        /// <summary>
        /// 物料代码
        /// </summary>
        public string ItemCode { get; set; }
        /// <summary>
        /// 单据名称 
        /// </summary>
        public string DocName { get; set; }
        /// <summary>
        /// 物料描述
        /// </summary>
        public string ItemDesc { get; set; }

        /// <summary>
        /// 本次请求Id（用于追踪问题）
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public string ErrMsg { get; set; }
        /// <summary>
        /// 文件编码
        /// </summary>
        public string DocLineNum { get; set; }
        /// <summary>
        /// 序列号
        /// </summary>
        public int SeqId { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public string UnitPrice { get; set; }
        /// <summary>
        /// 接受数量
        /// </summary>
        public int ReceiveQty { get; set; }

        /// <summary>
        /// 文件编号
        /// </summary>
        public string DocId { get; set; }
        /// <summary>
        /// 供应商代码
        /// </summary>
        public string VendorCode { get; set; }
        /// <summary>
        /// 接受编码
        /// </summary>
        public string ReceiveNum { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 税
        /// </summary>
        public double PriceTax { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public string Quantity { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Comments { get; set; }
        /// <summary>
        /// 买方姓名
        /// </summary>
        public string BuyerName { get; set; }
        /// <summary>
        /// 买方电话
        /// </summary>
        public string BuyerPhone { get; set; }
        /// <summary>
        /// 截止日期，返回的是时间戳
        /// </summary>
        public long NeedbyDate { get; set; }
        /// <summary>
        /// 申请者
        /// </summary>
        public string ApplyBy { get; set; }
        /// <summary>
        /// 装运地址
        /// </summary>
        public string ShipAddress { get; set; }
        /// <summary>
        /// 组织代码
        /// </summary>
        public string OrgCode { get; set; }

        /// <summary>
        /// 采购单号
        /// </summary>
        public int PoLineNum { get; set; }

        /// <summary>
        /// 付款公司OU
        /// </summary>
        public string OuName { get; set; }
    }
}
