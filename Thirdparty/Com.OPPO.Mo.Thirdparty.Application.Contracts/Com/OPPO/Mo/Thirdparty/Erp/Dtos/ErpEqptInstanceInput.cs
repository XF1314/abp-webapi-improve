using System.ComponentModel.DataAnnotations;

namespace Com.OPPO.Mo.Thirdparty.Erp.Dtos
{
    /// <summary>
    /// 设备调拨_调拨信息（添加）
    /// </summary>
    public class ErpEqptInstanceInput
    {
        /// <summary>
        /// 转入部门           
        /// </summary>
        [Required]
        public string DeptIn { get; set; }
        /// <summary>
        /// 转出部门    
        /// </summary>
        [Required]
        public string DeptOut { get; set; }

        /// <summary>
        ///  文件编号    
        /// </summary>
        [Required]
        public string DocId { get; set; }

        /// <summary>
        /// 单据名称 
        /// </summary>
        public string DocName { get; set; }

        /// <summary>
        ///固定资产代码    
        /// </summary>
        public string FaAssetNum { get; set; }

        /// <summary>
        /// 设备编码
        /// </summary>
        public string InstanceCode { get; set; }

        /// <summary>
        /// 物料编码
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        /// 转出货位 
        /// </summary>
        public string LocatorCode { get; set; }

        /// <summary>
        /// 组织代码
        /// </summary>
        [Required]
        public string OrgCode { get; set; }

        ///// <summary>
        ///// 语言
        ///// </summary>
        //public string Language { get; set; }

        /// <summary>
        /// 数量      
        /// </summary>
        [Required]
        public int Quantity { get; set; }

        /// <summary>
        /// 拟制人工号  
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 备注    
        /// </summary>
        public string Remark { get; set; }
    }
}
