using Newtonsoft.Json;

namespace Com.OPPO.Mo.Thirdparty.Erp.Requests
{
    /// <summary>
    ///  费用报销数据推送输入参数
    /// </summary>
    public class ErpExpensesPushRequest : BaseEsbRequest
    {
        /// <summary>
        /// JSON格式费用报销数据：[{"formInstance_code":"191224170002517828","report_header_id":165228,"employee_num":"80084521","ou_id":133,"dept_num":"210600","expense_report_id":10182,"total_amount":12222.00,"purpose":"111","prepay_flag":1,"created_by":"80262836","creation_date":"2020-09-03","expense_lines":[{"report_header_id":165228,"begin_date":"2019-12-17","end_date":"2019-12-18","period_date":2,"amount":12222.00,"amount_descript":"554","parameter_id":13342,"created_by":"80262836"}]}]]}
        /// </summary>
        [JsonProperty("expenses")]
        public string Expenses { get; set; }

        /// <summary>
        /// 返回格式，支持json/xml两种格式，默认为json格式
        /// </summary>
        [JsonProperty("resp_type")]
        public string RespType { get; set; }
    }
}
