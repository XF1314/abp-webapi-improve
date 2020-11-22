using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Plm.Dtos
{
    public class SubstitutesDto
    {
        /// <summary>
        /// 厂别
        /// </summary>
        public string originOrgCode { get; set; }
        /// <summary>
        /// 文件ID
        /// </summary>
        public string docId { get; set; }
        /// <summary>
        /// 文件编号
        /// </summary>
        public string docNumber { get; set; }
        /// <summary>
        /// 行来源ID
        /// </summary>
        public string sourceLineId { get; set; }
        /// <summary>
        /// BOM父项代码
        /// </summary>
        public string originAssemblyItem { get; set; }  
        /// <summary>
        /// 子项代码
        /// </summary>
        public string originComponItem { get; set; }     
        /// <summary>
        /// 主料比例，如果是主替代变更，必须传 0
        /// </summary>
        public string originComponItemScale { get; set; }   
        /// <summary>
        /// 替代料代码
        /// </summary>
        public string originSubstItem { get; set; }     
        /// <summary>
        /// 主料比例，如果是主替代变更，必须传 100
        /// </summary>
        public string originSubstItemScale { get; set; }   
        /// <summary>
        /// 数量
        /// </summary>
        public string itemQuantity { get; set; }
        /// <summary>
        /// 类型 1：新增，2：失效 3：主替代变更
        /// </summary>
        public string type { get; set; }               
    }
}
