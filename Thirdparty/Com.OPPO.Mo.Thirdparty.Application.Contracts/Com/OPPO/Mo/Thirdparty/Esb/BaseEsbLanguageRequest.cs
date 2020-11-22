using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty
{

    public class BaseEsbLanguageRequest : BaseEsbRequest
    {
        /// <summary>
        /// 语言
        /// </summary>
        [JsonProperty("language")]
        public string Language { get; set; }
    }
}
