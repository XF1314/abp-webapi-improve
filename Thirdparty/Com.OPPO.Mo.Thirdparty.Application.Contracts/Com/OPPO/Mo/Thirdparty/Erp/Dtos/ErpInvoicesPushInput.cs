namespace Com.OPPO.Mo.Thirdparty.Erp.Dtos
{
    /// <summary>
    /// 付款通知单传ERP
    /// </summary>
    public class ErpInvoicesPushInput
    {
        /// <summary>
        /// 付款通知单传ERP对应参数json
        /// 格式如下： { "invoice_num": "报销单号(1024)", "invoice_date": "同意时系统时间(2016-03-27 17:43:45)", "invoice_type_lookup_code": "传固定值： EXPENSE REPORT ", "vendor_code": "员工编号", "vendor_site_code": "默认传空 ("")", "invoice_amount": 汇总所有行的收据金额, "requested_amount": 汇总所有行的收据金额 , "invoice_currency_code": "币种", "created_by_name": "1024", "org_code": "1024", "description": "1024", "attribute1":"1024", "attribute2":"1024", "attribute3":"1024", "attribute4":"1024", "attribute5":"1024", "source":"MYSOFT", "prepay_flag":1, "line": [ { "accounting_date": "2016-03-27 17:43:45", "amount": 1024, "dist_code_concatenated": "公司.产品.区域.销售渠道.产品线.部门.主科目.子科目.预算科目.交易方.保留", "attribute1":"1024", "attribute2":"1024", "attribute3":"1024", "attribute4":"1024", "attribute5":"1024" }, { "accounting_date": "2016-03-27 17:43:45", "amount": 1024, "dist_code_concatenated": "公司.产品.区域.销售渠道.产品线.部门.主科目.子科目.预算科目.交易方.保留", "attribute1":"1024", "attribute2":"1024", "attribute3":"1024", "attribute4":"1024", "attribute5":"1024" } ] }
        /// </summary>
        public string Invoices { get; set; }
    }
}
