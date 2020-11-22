using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.Dtos
{
    public class ErpPurchaseOrderDto
    {
        /// <summary>
        /// 文件编码
        /// </summary>
        public string DocId { get; set; }
        /// <summary>
        /// 不合格类别
        /// </summary>
        public string DisqualificationType { get; set; }
        /// <summary>
        /// 不合格内容
        /// </summary>
        public string DisqualificationContent { get; set; }
        /// <summary>
        /// 缺陷数量
        /// </summary>
        public string DefectNumber { get; set; }
        /// <summary>
        /// 样本数量
        /// </summary>
        public string ExampleNumber { get; set; }
        /// <summary>
        /// 比例(%)
        /// </summary>
        public string Proportion { get; set; }
    }
}
