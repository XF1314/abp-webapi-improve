using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Mes.Requests
{

    public class MarketingPrototypeInfo
    {
        /// <summary>
        /// 文件编号
        /// </summary>
        [JsonProperty("document_no")] 
        public string DocumentNo { get; set; }
        /// <summary>
        /// 物品编号
        /// </summary>
        [JsonProperty("mat_id")] 
        public string MatId { get; set; }
        /// <summary>
        /// 物品数量
        /// </summary>
        [JsonProperty("mat_qty")]
        public int MatQty { get; set; }
        /// <summary>
        /// 物品描述
        /// </summary>
        [JsonProperty("mat_desc")] 
        public string MatDesc { get; set; }
        /// <summary>
        /// 部门编码
        /// </summary>
        [JsonProperty("department_code")] 
        public string DepartmentCode { get; set; }
        /// <summary>
        /// 物品描述
        /// </summary>
        [JsonProperty("department_desc")] 
        public string DepartmentDesc { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [JsonProperty("qty")] 
        public int Qty { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonProperty("create_time")] 
        public string CreateTime { get; set; }
        /// <summary>
        /// 创建人员id
        /// </summary>
        [JsonProperty("create_user_id")] 
        public string CreateUserId { get; set; }
        /// <summary>
        /// 借用部门
        /// </summary>
        [JsonProperty("borrow_department")] 
        public string BorrowDepartment { get; set; }
        /// <summary>
        /// 借用人员
        /// </summary>
        [JsonProperty("borrow_user_name")] 
        public string BorrowUserName { get; set; }
        /// <summary>
        /// 借用人员id
        /// </summary>
        [JsonProperty("borrow_user_id")] 
        public string BorrowUserId { get; set; }
    }

}
