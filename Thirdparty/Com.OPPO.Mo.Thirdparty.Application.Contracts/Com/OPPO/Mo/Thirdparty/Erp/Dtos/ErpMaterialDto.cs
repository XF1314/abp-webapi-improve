namespace Com.OPPO.Mo.Thirdparty.Erp.Dtos
{
    /// <summary>
    /// 物料信息
    /// </summary>
    public class ErpMaterialDto
    {
        /// <summary>
        /// 物料代码
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        /// 物料描述
        /// </summary>
        public string ItemDesc { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        public string Uom { get; set; }

        /// <summary>
        /// 物料大小类
        /// </summary>
        public string ItemMajCatogory { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        public string ItemMinCatogory { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        public string AssetMajCatogory { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        public string AssetMidCatogory { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        public string AssetMinCatogory { get; set; }

        /// <summary>
        /// 物料类型
        /// </summary>
        public int ItemType { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        public string HsCode { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        public int LieIdleQty { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string ItemUsDesc { get; set; }
    }
}
