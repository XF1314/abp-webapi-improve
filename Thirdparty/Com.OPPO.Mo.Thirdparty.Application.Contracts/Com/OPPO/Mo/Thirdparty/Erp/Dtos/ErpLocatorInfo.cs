using Newtonsoft.Json;
using System;

namespace Com.OPPO.Mo.Thirdparty.Erp.Dtos
{
    /// <summary>
    /// 获取ERP样品库同步处理结果信息
    /// </summary>
    public class ErpLocatorInfo
    {
        /// <summary>
        /// 批次
        /// </summary>
        [JsonProperty("batchId")]
        public string BatchId { get; set; }

        /// <summary>
        /// 组织编码
        /// </summary>
        [JsonProperty("originOrgCode")]
        public string OriginOrgCode { get; set; }

        /// <summary>
        /// 物料编号
        /// </summary>
        [JsonProperty("itemNumber")]
        public string ItemNumber { get; set; }

        /// <summary>
        /// 供应商代码
        /// </summary>
        [JsonProperty("vendorCode")]
        public string VendorCode { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("mpn")]
        public string Mpn { get; set; }

        /// <summary>
        /// mpn描述
        /// </summary>
        [JsonProperty("mpnDes")]
        public string MpnDes { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [JsonProperty("status")]
        public int Status { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonProperty("creationDate")]
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        [JsonProperty("lastUpdateDate")]
        public DateTime LastUpdateDate { get; set; }

        /// <summary>
        /// 信息
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
