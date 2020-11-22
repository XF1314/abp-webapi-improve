using Com.OPPO.Mo.Thirdparty.Erp.Dtos;
using Com.OPPO.Mo.Thirdparty.Erp.Requests;
using Com.OPPO.Mo.Thirdparty.Erp.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Erp.Services
{
    /// <summary>
    /// 费用报销 webapi 接口
    /// </summary>
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.EsbHost)]
    public interface IErpExpenseReimbursementEsbService : IHttpApi
    {
        /// <summary>
        /// 查询核销预付款
        /// <param name="request"><see cref="ErpPrepayAmountRequest"/></param>
        /// </summary>
        /// <returns></returns>
        [HttpGet("/erp/expenses/get_prepay_amount_list")]
        Task<ErpResponse<List<ErpPrepayAmountInfo>>> GetPrepayAmountList([PathQuery] ErpPrepayAmountRequest request);

        /// <summary>
        /// 根据报销人工号查询银行账号信息
        /// <param name="request"><see cref="ErpBankAccountRequest"/></param>
        /// </summary>
        /// <returns></returns>
        [HttpGet("/erp/expenses/bank_account_get")]
        Task<ErpBankResponse<ErpBankAccountInfo>> GetBankAccount([PathQuery] ErpBankAccountRequest request);

        /// <summary>
        /// 获取历史借款信息
        /// <param name="request"><see cref="ErpPrepayRequest"/></param>
        /// </summary>
        /// <returns></returns>
        [HttpGet("/erp/expenses/prepay_list1")]
        Task<ErpResponse<List<ErpPrepayInfo>>> GetPrepayList([PathQuery] ErpPrepayRequest request);

        /// <summary>
        /// 费用报销数据推送
        /// <param name="request"><see cref="ErpExpensesPushRequest"/></param>
        /// </summary>
        /// <returns></returns>
        [HttpPost("/erp/expenses/expenses_push")]
        Task<ErpResultResponseResult<ErpResponseInfo>> ExpensesPush([FormContent] ErpExpensesPushRequest request);

        /// <summary>
        /// MO费用报销
        /// <param name="request"><see cref="ErpImportExpensesRequest"/></param>
        /// </summary>
        /// <returns></returns>
        [HttpPost("/erp/expenses/import_expenses")]
        Task<ErpResultResponseResult<ErpResponseInfo>> ImportExpenses([FormContent] ErpImportExpensesRequest request);

        /// <summary>
        /// MO费用报销驳回处理
        /// <param name="request"><see cref="ErpExpensesPushRequest"/></param>
        /// </summary>
        /// <returns></returns>
        [HttpPost("/erp/expenses/mo_process_reject")]
        Task<ErpResultResponseResult<ErpResponseInfo>> ProcessReject([FormContent] ErpProcessRejectRequest request);

        /// <summary>
        /// 报销单号获取接口
        /// <param name="request"><see cref="ErpExpensesSeqRequest"/></param>
        /// </summary>
        /// <returns></returns>
        [HttpGet("/erp/expenses/expenses_seq_get")]
        Task<ErpResultResponseResult<ErpExpensesSeqInfo>> GetExpensesSeq([PathQuery] ErpExpensesSeqRequest request);

    }
}
