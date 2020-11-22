using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Dtos
{

    public class CreatePoInfoBaseDto
    {
        /// <summary>
        /// OU名称
        /// </summary>
        public string OuName { get; set; }
        /// <summary>
        /// 组织代码
        /// </summary>
        public string OrgCode { get; set; }
        /// <summary>
        /// 供应商代码
        /// </summary>
        public string VendorCode { get; set; }
        /// <summary>
        /// 物料代码
        /// </summary>
        public string ItemCode { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public double Quantity { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public double UnitPrice { get; set; }
        /// <summary>
        /// 税
        /// </summary>
        public double PriceTax { get; set; }
        /// <summary>
        /// 截止日期
        /// </summary>
        public DateTime NeedbyDate { get; set; }
        /// <summary>
        /// 申请者
        /// </summary>
        public string ApplyBy { get; set; }
        /// <summary>
        /// 解释
        /// </summary>
        public string Comments { get; set; }
        /// <summary>
        /// 文件编号
        /// </summary>
        public string DocId { get; set; }
        /// <summary>
        /// 单据名称 
        /// </summary>
        public string DocName { get; set; }
        /// <summary>
        /// 买方姓名
        /// </summary>
        public string BuyerName { get; set; }
        /// <summary>
        /// 买方电话
        /// </summary>
        public string BuyerPhone { get; set; }
        /// <summary>
        /// 装运地址
        /// </summary>
        public string ShipAddress { get; set; }
       
    }

    public class CreatePoDto : CreatePoInfoBaseDto 
    {
        /// <summary>
        /// 文件编码
        /// </summary>
        public string DocLineNum { get; set; }
    }

}
