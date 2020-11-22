using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpSrm.Dtos
{
    public class ErpSrmMtrlnoStockBodyDto
    {
        /// <summary>
        /// 数据条数
        /// </summary>
        public int total_results { get; set; }
        /// <summary>
        /// 数据集合
        /// </summary>
        public List<MtrlItemDto> mtrl { get; set; }

        /// <summary>
        /// 返回编码
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        [JsonProperty("msg")]
        public string Message { get; set; }

    }
}
