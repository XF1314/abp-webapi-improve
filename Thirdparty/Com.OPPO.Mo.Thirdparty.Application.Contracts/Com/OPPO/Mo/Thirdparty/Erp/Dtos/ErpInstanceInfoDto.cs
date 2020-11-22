namespace Com.OPPO.Mo.Thirdparty.Erp.Dtos
{
    /// <summary>
    /// 设备台账信息输出类
    /// </summary>
    public class ErpInstanceInfoDto
    {
        /// <summary>
        /// 实例编码
        /// </summary>
        public string InstanceCode { get; set; }

        /// <summary>
        /// 资产编号
        /// </summary>
        public string AssetNumber { get; set; }

        /// <summary>
        /// 物料代码
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        /// 实例描述
        /// </summary>
        public string InstanceDesc { get; set; }

        /// <summary>
        /// 字库编码
        /// </summary>
        public string SubinvCode { get; set; }

        /// <summary>
        ///  ？
        /// </summary>
        public string LocatorCode { get; set; }

        /// <summary>
        ///  ？
        /// </summary>
        public string InvCategoryCode { get; set; }

        /// <summary>
        /// 物料类型
        /// </summary>
        public string ItemType { get; set; }

        /// <summary>
        /// 物料分类
        /// </summary>
        public string ItemCategory { get; set; }

        /// <summary>
        /// ？
        /// </summary>
        public string Uom { get; set; }

        /// <summary>
        /// 供应商代码
        /// </summary>
        public string VendorCode { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        public string VendorName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string ItemDesc { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public string UnitPrice { get; set; }
    }
}
