using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.Dtos
{
    public class MaterialInfosDto
    {
        [JsonProperty("total_results")]
        public int TotalCount { get; set; }

        [JsonProperty("materialcodes")]
        public List<MaterialInfoDto> MaterialCodes { get; set; }
    }
}
