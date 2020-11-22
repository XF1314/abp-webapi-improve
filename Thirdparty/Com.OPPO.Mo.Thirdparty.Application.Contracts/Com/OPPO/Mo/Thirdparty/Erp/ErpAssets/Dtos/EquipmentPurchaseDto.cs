using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Dtos
{
 
    public class EquipmentPurchaseDto
    {
        /// <summary>
        /// 文件编号
        /// </summary>
        public string DocId { get; set; }
        /// <summary>
        /// 部门编码
        /// </summary>
        public string DeptNumber { get; set; }
        /// <summary>
        /// 请求人
        /// </summary>
        public string Requester { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }
    }

}
