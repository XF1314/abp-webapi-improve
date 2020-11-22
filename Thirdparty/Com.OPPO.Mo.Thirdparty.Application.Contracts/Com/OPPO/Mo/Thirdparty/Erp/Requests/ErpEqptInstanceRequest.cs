using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.Requests
{
    /// <summary>
    /// 生产设备调拨
    /// </summary>
    public class ErpEqptInstanceRequest: BaseEsbRequest
    {
        /// <summary>
        /// 转入部门           
        /// </summary>
        [JsonProperty("dept_in")]
        public string DeptIn { get; set; }
        /// <summary>
        /// 转出部门    
        /// </summary>
        [JsonProperty("dept_out")]
        public string DeptOut { get; set; }

        /// <summary>
        ///  文件编号    
        /// </summary>
        [JsonProperty("doc_id")]
        public string DocId { get; set; }

        /// <summary>
        /// 单据名称 
        /// </summary>
        [JsonProperty("doc_name")]
        public string DocName { get; set; }

        /// <summary>
        ///固定资产代码    
        /// </summary>

        [JsonProperty("fa_asset_num")]
        public string FaAssetNum { get; set; }

        /// <summary>
        /// 设备编码
        /// </summary>
        [JsonProperty("instance_code")]
        public string InstanceCode { get; set; }

        /// <summary>
        /// 物料编码
        /// </summary>
        [JsonProperty("item_code")]
        public string ItemCode { get; set; }

        /// <summary>
        /// 转出货位 
        /// </summary>
        [JsonProperty("locator_code")]
        public string LocatorCode { get; set; }

        /// <summary>
        /// 组织代码
        /// </summary>
        [JsonProperty("org_code")]
        public string OrgCode { get; set; }

        ///// <summary>
        ///// 语言
        ///// </summary>
        //[JsonProperty("language")]
        //public string Language { get; set; }

        /// <summary>
        /// 数量      
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// 拟制人工号  
        /// </summary>
        [JsonProperty("user_name")]
        public string UserName { get; set; }

        /// <summary>
        /// 备注    
        /// </summary>
        [JsonProperty("remark")]
        public string Remark { get; set; }

    }
}
