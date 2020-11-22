using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Plm.Responses
{

    public class ComsubResponse
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
        public double itemQuantity { get; set; }
        /// <summary>
        /// 类型 1：新增，2：失效 3：主替代变更
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ProcessResult { get; set; }

        /// <summary>
        /// --2 为成功，3为失败，7为失效，1 为处理中
        /// </summary>
        public int ProcessFlag { get; set; }
        /// <summary>
        /// ERP默认sysdate
        /// </summary>
        public long CreationDate { get; set; }

    }
}
