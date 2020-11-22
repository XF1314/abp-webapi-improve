using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Com.OPPO.Mo.Thirdparty.Erp.OnePlusErp.Dtos
{
    /// <summary>
    /// 采购单导入信息
    /// </summary>
    public class PoHeadersInterfaceInfoInput
    {
        /// <summary>
        /// 格式：[{ "oa_number":"54207", "oa_approved_date":"2016-01-22 00:00:00", "erp_po_number":"54207", "erp_creation_date":"2016-01-22 00:00:00", "comments":"54207", "interface_source_code":"54207", "ou_name":"54207", "document_type_code":"54207", "approval_status":"54207", "agent_id":"54207", "vendor_id":"54207", "vendor_num":"54207", "vendor_name":"54207", "vendor_site_id":"54207", "currency_code":"54207", "sync_flag":"1", "erp_process_code":"54207", "message":"54207", "attribute1":"header1", "attribute2":"", "attribute3":"", "attribute4":"", "attribute5":"", "attribute6":"", "attribute7":"", "attribute8":"", "attribute9":"", "attribute10":"", "attribute11":"", "attribute12":"", "attribute13":"", "attribute14":"", "attribute15":"", "creation_date":"2016-01-22 00:00:00", "created_by":"54207", "last_update_date":"2016-01-22 00:00:00", "last_updated_by":"54207", "last_update_login":"54207", "demand_department":"depart" }]
        /// </summary>
        public string Lines { get; set; }

        /// <summary>
        /// 返回格式，支持json/xml两种格式，默认为json格式
        /// </summary>
        [JsonIgnore]
        public string RespType { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Oa_number { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //[DataType(DataType.Date)]
        //public DateTime Oa_approved_date { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Erp_po_number { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //[DataType(DataType.Date)]
        //public DateTime Erp_creation_date { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Comments { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Interface_source_code { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Ou_name { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Document_type_code { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Approval_status { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Agent_id { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>

        //public string Vendor_id { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Vendor_num { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Vendor_name { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Vendor_site_id { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Currency_code { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Sync_flag { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Erp_process_code { get; set; }

        ///// <summary>
        ///// ?
        ///// </summary>
        //public string Message { get; set; }

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
