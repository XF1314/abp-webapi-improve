using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Mes.Dtos
{
    public class MarketingPrototypeInfoDto
    {
        /// <summary>
        /// 文件编号
        /// </summary>
        public string DocumentNo { get; set; }
        /// <summary>
        /// 物品编号
        /// </summary>
        public string MatId { get; set; }
        /// <summary>
        /// 物品数量
        /// </summary>
        public int MatQty { get; set; }
        /// <summary>
        /// 物品描述
        /// </summary>
        public string MatDesc { get; set; }
        /// <summary>
        /// 部门编码
        /// </summary>
        public string DepartmentCode { get; set; }
        /// <summary>
        /// 物品描述
        /// </summary>
        public string DepartmentDesc { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Qty { get; set; }
        /// <summary>
        /// 创建时间(格式："yyyyMMddhhmmss")
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        /// 创建人员id
        /// </summary>
        public string CreateUserId { get; set; }
        /// <summary>
        /// 借用部门
        /// </summary>
        public string BorrowDepartment { get; set; }
        /// <summary>
        /// 借用人员
        /// </summary>
        public string BorrowUserName { get; set; }
        /// <summary>
        /// 借用人员id
        /// </summary>
        public string BorrowUserId { get; set; }
    }
}
