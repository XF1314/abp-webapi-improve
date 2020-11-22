using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Plm.Dtos
{

    public class SubstitutesResponseDto
    {
        /// <summary>
        /// 厂别
        /// </summary>
        [JsonProperty("ORIGIN_ORG_CODE")]
        public string originOrgCode { get; set; }
        /// <summary>
        /// 文件ID
        /// </summary>
        [JsonProperty("DOC_ID")]
        public string docId { get; set; }
        /// <summary>
        /// 文件编号
        /// </summary>
        [JsonProperty("DOC_NUMBER")] 
        public string docNumber { get; set; }
        /// <summary>
        /// 行来源ID
        /// </summary>
        [JsonProperty("SOURCE_LINE_ID")] 
        public string sourceLineId { get; set; }
        /// <summary>
        /// BOM父项代码
        /// </summary>
        [JsonProperty("ORIGIN_ASSEMBLY_ITEM")] 
        public string originAssemblyItem { get; set; }
        /// <summary>
        /// 子项代码
        /// </summary>
        [JsonProperty("ORIGIN_COMPON_ITEM")] 
        public string originComponItem { get; set; }
        /// <summary>
        /// 主料比例，如果是主替代变更，必须传 0
        /// </summary>
        [JsonProperty("ORIGIN_COMPON_ITEM_SCALE")] 
        public string originComponItemScale { get; set; }
        /// <summary>
        /// 替代料代码
        /// </summary>
        [JsonProperty("ORIGIN_SUBST_ITEM")] 
        public string originSubstItem { get; set; }
        /// <summary>
        /// 主料比例，如果是主替代变更，必须传 100
        /// </summary>
        [JsonProperty("ORIGIN_SUBST_ITEM_SCALE")] 
        public string originSubstItemScale { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [JsonProperty("ITEM_QUANTITY")] 
        public double itemQuantity { get; set; }
        /// <summary>
        /// 类型 1：新增，2：失效 3：主替代变更
        /// </summary>
        [JsonProperty("TYPE")] 
        public string type { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        [JsonProperty("PROCESS_RESULT")] 
        public string ProcessResult { get; set; }

        /// <summary>
        /// --2 为成功，3为失败，7为失效，1 为处理中
        /// </summary>
        [JsonProperty("PROCESS_FLAG")] 
        public int ProcessFlag { get; set; }
        /// <summary>
        /// ERP默认sysdate
        /// </summary>
        [JsonProperty("CREATION_DATE")] 
        public long CreationDate { get; set; }
 
    }

}
