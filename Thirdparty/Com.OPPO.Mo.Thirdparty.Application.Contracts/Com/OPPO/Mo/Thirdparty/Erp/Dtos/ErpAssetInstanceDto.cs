namespace Com.OPPO.Mo.Thirdparty.Erp.Dtos
{
    /// <summary>
    /// 设备调拨_固定资产和设备信息
    /// </summary>
    public class ErpAssetInstanceDto
    {
        /// <summary>
        /// 资产编号
        /// </summary>
        public string AssetNum { get; set; }

        /// <summary>
        /// 实例编码
        /// </summary>
        public string InstancCode { get; set; }

        /// <summary>
        /// 物料代码
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        /// 部门编码
        /// </summary>
        public string FaDeptCode { get; set; }

        /// <summary>
        /// 资产描述
        /// </summary>
        public string AssetDesc { get; set; }

        /// <summary>
        /// 子库编码
        /// </summary>
        public string SubinvCode { get; set; }

        /// <summary>
        /// ？
        /// </summary>
        public string LocatorCode { get; set; }

        /// <summary>
        /// ？
        /// </summary>
        public string Uom { get; set; }

        /// <summary>
        /// 物料类型
        /// </summary>
        public string ItemType { get; set; }

        /// <summary>
        /// 物料分类
        /// </summary>
        public string ItemCategory { get; set; }
    }
}
