using Com.OPPO.Mo.Thirdparty.Erp.Dtos;
using Com.OPPO.Mo.Thirdparty.Erp.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.Erp.Services
{
    /// <summary>
    /// Erp 费用报销 应用服务接口
    /// </summary>
    public interface IErpExpennseRemburementAppService : IApplicationService
    {
        /// <summary>
        /// 查询核销预付款
        /// </summary>
        /// <param name="invoiceNum">报销单号</param>
        /// <param name="respType">返回格式，支持json/xml两种格式，默认为json格</param>
        /// <returns></returns>
        Task<Result<List<ErpPrepayAmountDto>>> GetPrepayAmountList(string invoiceNum, string respType);

        /// <summary>
        /// 据报销人工号查询银行账号信息
        /// </summary>
        /// <param name="emplId">员工工号</param>
        /// <returns></returns>
        Task<Result<ErpBankAccountDto>> GetBankAccountByEmpId(string emplId);

        /// <summary>
        /// 个人借款信息查询
        /// </summary>
        /// <param name="emplId">员工工号</param>
        /// <param name="ouId">纳税单位ID</param>
        /// <param name="respType">返回格式，支持json/xml两种格式，默认为json格式</param>
        /// <returns></returns>
        Task<Result<List<ErpPrepayDto>>> GetPrepayList(string emplId, string ouId, string respType);

        /// <summary>
        /// 费用报销数据推送
        /// </summary>
        /// <param name="input">费用报销数据推送输入参数</param>
        /// <returns></returns>
        Task<Result> ExpensesPush(ErpExpensesPushInput input);

        /// <summary>
        /// MO费用报销
        /// </summary>
        /// <param name="input">费用报销数据输入参数</param>
        /// <returns></returns>
        Task<Result> ImportExpenses(ErpImportExpensesPushInput input);

        /// <summary>
        /// MO费用报销驳回处理
        /// </summary>
        /// <param name="input">MO费用报销驳回处理输入参数</param>
        /// <returns></returns>
        Task<Result> ProcessReject(ErpProcessRejectInput input);

        /// <summary>
        /// 报销单号获取接口
        /// </summary>
        /// <returns></returns>
        Task<Result<ErpExpensesSeqDto>> GetExpensesSeq();
    }
}
