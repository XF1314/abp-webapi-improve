using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Plm.Dtos
{

    public class ItemMakeDto
    {
        /// <summary>
        /// 物料号
        /// </summary>
        [JsonProperty("ITEMCODE")] 
        public string ItemCode { get; set; }
        /// <summary>
        /// 组织代码
        /// </summary>
        [JsonProperty("ORIGINORGCODE")] 
        public string OrgCode { get; set; }
        /// <summary>
        /// 是否是制造件
        /// </summary>
        [JsonProperty("MAKEORBUY")]
        public string IsMakeOrBuy { get; set; }
    }

}
