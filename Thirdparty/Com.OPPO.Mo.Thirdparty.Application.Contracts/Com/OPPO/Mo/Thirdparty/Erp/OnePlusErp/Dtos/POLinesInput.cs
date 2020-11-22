using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Dtos
{
    /// <summary>
    /// 采购单导入主体部分
    /// </summary>
    public class PoLinesInput
    {
        /// <summary>
        /// 格式如下： [{ "header_id":"1", "item_code":"1", "item_description":"1", "quantity":"1", "unit_of_measure":"1", "unit_price":"1", "unit_price_tax":"1", "promised_date":"2016-01-22 00:00:00", "need_by_date":"2016-01-22 00:00:00", "receiving_routing":"1", "attribute1":"line1", "attribute2":"1", "attribute3":"1", "attribute4":"1", "attribute5":"1", "attribute6":"1", "attribute7":"1", "attribute8":"1", "attribute9":"1", "attribute10":"1", "attribute11":"1", "attribute12":"1", "attribute13":"1", "attribute14":"1", "attribute15":"1", "creation_date":"2016-01-22 00:00:00", "created_by":"1", "last_update_date":"2016-01-22 00:00:00", "last_updated_by":"1", "last_update_login":"1" }]
        /// </summary>
        public string Lines { get; set; }

        /// <summary>
        /// 返回格式，支持json/xml两种格式，默认为json格式
        /// </summary>
        [JsonIgnore]
        public string RespType { get; set; }

        ///// <summary>
        ///// 头部Id
        ///// </summary>
        //[Required]
        //public string Header_id { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Item_code { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Item_description { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Quantity { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Unit_of_measure { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Unit_price { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Unit_price_tax { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //[DataType(DataType.Date)]
        //public DateTime Promised_date { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //[DataType(DataType.Date)]
        //public DateTime Need_by_date { get; set; }


        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Receiving_routing { get; set; }


        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Attribute1 { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Attribute2 { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Attribute3 { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Attribute4 { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Attribute5 { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Attribute6 { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Attribute7 { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Attribute8 { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Attribute9 { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Attribute10 { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Attribute11 { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Attribute12 { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Attribute13 { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Attribute14 { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Attribute15 { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //[DataType(DataType.Date)]
        //public DateTime Creation_date { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Created_by { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //[DataType(DataType.Date)]
        //public DateTime Last_update_date { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Last_updated_by { get; set; }


        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Last_update_login { get; set; }
    }
}
