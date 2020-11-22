using Com.OPPO.Mo.Thirdparty.Erp.ErpSrm.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.Responses
{

    public class ErpSrmStockBody
    {
        /// <summary>
        /// 数据条数
        /// </summary>
        public int RowCount { get; set; }
        /// <summary>
        /// 数据集合
        /// </summary>
        public List<MtrlItem> DataList { get; set; }

    }

    public class ErpSrmMtrlnoStockResponse
    {

        /// <summary>
        /// 返回数据
        /// </summary>
        [JsonProperty("response")]
        public ErpSrmMtrlnoStockBodyDto Response { get; set; }
    }


}
