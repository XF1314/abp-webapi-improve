using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Dtos
{

    public class PoWarehousingDto
    {
        /// <summary>
        /// 文件编号
        /// </summary>
        public string DocId { get; set; }
        /// <summary>
        /// PO码
        /// </summary>
        public string PoNum { get; set; }
        /// <summary>
        /// 提单
        /// </summary>
        public string BillLading { get; set; }
        /// <summary>
        /// 物料编码
        /// </summary>
        public string ItemCode { get; set; }
        /// <summary>
        /// 调整价格
        /// </summary>
        public double AdjustPrice { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// 次级投资
        /// </summary>
        public string Subinv { get; set; }
        /// <summary>
        /// 定位
        /// </summary>
        public string Locator { get; set; }
        /// <summary>
        /// 资产数量
        /// </summary>
        public string AssetNumF { get; set; }
        /// <summary>
        /// 资产数量
        /// </summary>
        public string AssetNumT { get; set; }
        /// <summary>
        /// 资产类型
        /// </summary>
        public string AssetType { get; set; }
        /// <summary>
        /// 部门代码
        /// </summary>
        public string DeptCode { get; set; }
        /// <summary>
        /// 接管人
        /// </summary>
        public string Receiver { get; set; }
    }

}
