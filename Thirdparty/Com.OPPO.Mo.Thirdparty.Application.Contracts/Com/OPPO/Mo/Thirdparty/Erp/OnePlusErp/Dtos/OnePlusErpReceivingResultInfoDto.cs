using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Dtos
{
    /// <summary>
    /// 收货结果信息
    /// </summary>
    public class OnePlusErpReceivingResultInfoDto
    {
        [JsonProperty("WAREHOUSE")]
        public string WareHouse { get; set; }
        [JsonProperty("ORG_ID")]
        public string Org_Id { get; set; }
        [JsonProperty("UOM")]
        public string Ou_Name { get; set; }
        [JsonProperty("TRANS_BY")]
        public string Trans_By { get; set; }
        [JsonProperty("VENDOR_LOC")]
        public string Vendor_Loc { get; set; }
        [JsonProperty("LINE_NUM")]
        public string Line_Num { get; set; }
        [JsonProperty("TRANS_QTY")]
        public string Trans_Qty { get; set; }
        [JsonProperty("PO_NUMBER")]
        public string Po_Number { get; set; }
        [JsonProperty("ORDER_QTY")]
        public string Order_Qty { get; set; }
        [JsonProperty("SKU_DESC")]
        public string Sku_Desc { get; set; }
        [JsonProperty("TRANS_TYPE")]
        public string Trans_Type { get; set; }
        [JsonProperty("PO_HEADER_ID")]
        public string Po_Header_Id { get; set; }
        [JsonProperty("LOCATO")]
        public string Locato { get; set; }
        [JsonProperty("TRANS_DATE")]
        public string Trans_Date { get; set; }
        [JsonProperty("SKU")]
        public string Sku { get; set; }
        [JsonProperty("SKU_CATE")]
        public string Sku_Cate { get; set; }
    }
}
