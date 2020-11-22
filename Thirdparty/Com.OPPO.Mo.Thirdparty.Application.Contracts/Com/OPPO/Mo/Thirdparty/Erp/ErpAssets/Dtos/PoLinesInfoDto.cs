using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Dtos
{

    public class PoLinesInfoDto: PoLineBaseDto
    {
        /// <summary>
        /// 文件数量
        /// </summary>
        [JsonProperty("doc_line_num")]
        public string DocLineNum { get; set; }
        /// <summary>
        /// 本次请求Id（用于追踪问题）
        /// </summary>
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
        /// <summary>
        /// 接受编码
        /// </summary>
        [JsonProperty("receive_num")]
        public string ReceiveNum { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        [JsonProperty("unit_price")]
        public double UnitPrice { get; set; }
        /// <summary>
        /// 税
        /// </summary>
        [JsonProperty("price_tax")]
        public double PriceTax { get; set; }
    }
}
