using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpSrm.Dtos
{
    public class PurchaseReportDto
    {
        /// <summary>
        /// 文件编号
        /// </summary>
        public string DocId { get; set; }
        /// <summary>
        /// 组织code
        /// </summary>
        public string OrganizationCode { get; set; }
        /// <summary>
        /// 物料编号
        /// </summary>
        public string MaterialCode { get; set; }
        /// <summary>
        /// 收据编号
        /// </summary>
        public string ReceiptNumber { get; set; }
        /// <summary>
        /// "检验员"+拟制人名字+送审时间戳
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 文件编号
        /// </summary>
        public string DocNo { get; set; }
        /// <summary>
        /// 供应商批次
        /// </summary>
        public string SupplierBatch { get; set; }
    }
}
