using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Mes.Responses
{
    /// <summary>
    /// 允许机型
    /// </summary>
    public class ProductModelInfo
    {
        /// <summary>
        /// 机型
        /// </summary>
       [JsonProperty("product_model")]
        public string ProductModel { get; set; }

        /// <summary>
        /// 销售国家
        /// </summary>
        [JsonProperty("sale_country")]
        public string SaleCountry { get; set; }


        /// <summary>
        /// 销售国家名称
        /// </summary>
        [JsonProperty("sale_country_name")]
        public string SaleCountryName { get; set; }   
    }
}
