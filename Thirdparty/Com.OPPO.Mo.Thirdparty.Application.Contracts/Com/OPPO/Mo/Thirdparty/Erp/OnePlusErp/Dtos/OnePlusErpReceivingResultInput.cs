using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Dtos
{
    /// <summary>
    /// 收货结果查询输入参数
    /// </summary>
    public class OnePlusErpReceivingResultInput : BaseEsbRequest
    {
        /// <summary>
        /// 语言
        /// </summary>
        public string Language { get; set; }
        /// <summary>
        /// 采购订单行号码
        /// </summary>
        public string Line_Num { get; set; }
        /// <summary>
        /// 收货库区
        /// </summary>
        public string Locato { get; set; }
        /// <summary>
        /// 订单数量
        /// </summary>
        public string Order_Qty { get; set; }
        /// <summary>
        /// 主体ID
        /// </summary>
        public string Org_Id { get; set; }
        /// <summary>
        /// 主体Code
        /// </summary>
        public string Ou_Name { get; set; }
        /// <summary>
        /// 采购订单ID
        /// </summary>
        public string Po_Header_Id { get; set; }
        /// <summary>
        /// 采购订单号码
        /// </summary>
        public string Po_Number { get; set; }
        /// <summary>
        /// SKU类别
        /// </summary>
        public string Sku_Cate { get; set; }
        /// <summary>
        /// SKU名称
        /// </summary>
        public string Sku_Desc { get; set; }
        /// <summary>
        /// 收货人
        /// </summary>
        public string Trans_By { get; set; }
        /// <summary>
        /// 交易日期
        /// </summary>
        public string Trans_Qty { get; set; }
        /// <summary>
        /// 交易类型
        /// </summary>
        public string Trans_Type { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string Uom { get; set; }
        /// <summary>
        /// 供应商送货单号
        /// </summary>
        public string Vendor_Loc { get; set; }
        /// <summary>
        /// 收货仓库
        /// </summary>
        public string WareHouse { get; set; }
    }
}
