using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Com.OPPO.Mo.Thirdparty.Erp.Requests
{
    /// <summary>
    /// MO费用报销输入参数
    /// </summary>
    public class ErpImportExpensesPushInput
    {
        /// <summary>
        /// JSON格式费用报销数据：[{"mo_number":"178188","voucher":"","cz_date":"2020-08-25","amount":"10","file_num":"flag","Y":"","attribute1":"","attribute2":"","attribute3":"","attribute4":""}]
        /// </summary>
        [Required]
        public string Expenses { get; set; }
    }
}
