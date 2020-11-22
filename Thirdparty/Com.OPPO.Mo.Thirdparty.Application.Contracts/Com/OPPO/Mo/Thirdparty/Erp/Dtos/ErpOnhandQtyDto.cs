namespace Com.OPPO.Mo.Thirdparty.Erp.Dtos
{
    /// <summary>
    /// 物料现有量实体类
    /// </summary>
    public class ErpOnhandQtyDto
    {
        /// <summary>
        /// 物料编码
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        /// 物料描述 
        /// </summary>
        public string ItemEesc { get; set; }

        /// <summary>
        /// 物料现有量
        /// </summary>
        public string ItemQuantity { get; set; }
    }
}
