using System;

namespace Com.OPPO.Mo.Thirdparty.Erp.Dtos
{
    /// <summary>
    /// 获取ERP样品库同步处理结果信息
    /// </summary>
    public class ErpLocatorDto
    {
        /// <summary>
        /// 批次
        /// </summary> 
        public string BatchId { get; set; }

        /// <summary>
        /// 组织编码
        /// </summary>
        public string OriginOrgCode { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public string ItemNumber { get; set; }

        /// <summary>
        /// 供应商代码
        /// </summary>
        public string VendorCode { get; set; }

        /// <summary>
        /// ？
        /// </summary>
        public string Mpn { get; set; }

        /// <summary>
        /// Mpn描述
        /// </summary>
        public string MpnDes { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime LastUpdateDate { get; set; }

        /// <summary>
        /// 信息
        /// </summary>
        public string Message { get; set; }
    }
}
