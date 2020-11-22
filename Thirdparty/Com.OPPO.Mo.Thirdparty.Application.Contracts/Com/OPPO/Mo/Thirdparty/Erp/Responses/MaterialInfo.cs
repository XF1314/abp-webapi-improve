using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.Responses
{
    public class MaterialInfo
    {
        /// <summary>
        /// 组织id
        /// </summary>
        public string OrganizationId { get; set; }
        /// <summary>
        /// 类别id
        /// </summary>
        public string CategoryId { get; set; }
        /// <summary>
        /// 组织code
        /// </summary>
        public string OrganizationCode { get; set; }
        /// <summary>
        /// 物料代码
        /// </summary>
        public string MaterialCode { get; set; }
        /// <summary>
        /// 物料描述
        /// </summary>
        public string MaterialDesc { get; set; }
        //[JsonProperty("item_us_desc")]
        //public string MaterialUsDesc { get; set; }
        /// <summary>
        /// 物料小类
        /// </summary>
        public string MinorCategory { get; set; }
        /// <summary>
        /// 物料大类
        /// </summary>
        //[JsonProperty("major_category")]
        //public string MajorCategory { get; set; }
        public string PrimaryUomCode { get; set; }
        /// <summary>
        /// 物料类型
        /// </summary>
        public string Type { get; set; }
        public string FixedLotMultiplier { get; set; }
        public string StatusCode { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateDate { get; set; }
        /// <summary>
        /// 上次更新日期
        /// </summary>
        public string LastUpdateDate { get; set; }
        //[JsonProperty("stock_qty")]
        //public string StockQty { get; set; }


       
    }
}
