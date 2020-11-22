using Com.OPPO.Mo.Thirdparty.Erp.Dtos;
using Com.OPPO.Mo.Thirdparty.Erp.Requests;
using Com.OPPO.Mo.Thirdparty.Erp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.Erp
{
    /// <summary>
    /// Erp 费用报销 应用服务
    /// </summary>
    //[Authorize]
    public class ErpExpennseRemburementAppService : ThirdpartyAppServiceBase, IErpExpennseRemburementAppService
    {
        private readonly IErpExpenseReimbursementEsbService _erpExpenseReimbursementEsbService;
        public ErpExpennseRemburementAppService(IErpExpenseReimbursementEsbService erpExpenseReimbursementEsbService)
        {
            _erpExpenseReimbursementEsbService = erpExpenseReimbursementEsbService;
        }

        /// <summary>
        /// 查询核销预付款 
        /// </summary>
        /// <param name="invoiceNum">报销单号</param>
        /// <param name="respType">返回格式，支持json/xml两种格式，默认为json格</param>
        /// <returns></returns>
        public async Task<Result<List<ErpPrepayAmountDto>>> GetPrepayAmountList(string invoiceNum, string respType)
        {
            if (string.IsNullOrWhiteSpace(invoiceNum))
                return Result.FromError<List<ErpPrepayAmountDto>>($"缺失参数{nameof(invoiceNum)}。");

            var response = await _erpExpenseReimbursementEsbService.GetPrepayAmountList(new ErpPrepayAmountRequest
            {
                InvoiceNum = invoiceNum,
                RespType = respType
            });

            var res = ObjectMapper.Map<List<ErpPrepayAmountInfo>, List<ErpPrepayAmountDto>>(response.Body.Data);

            return Result.FromData(res);
        }

        /// <summary>
        /// 据报销人工号查询银行账号信息
        /// </summary>
        /// <param name="emplId">销人工号</param>
        /// <returns></returns>
        public async Task<Result<ErpBankAccountDto>> GetBankAccountByEmpId(string emplId)
        {
            if (string.IsNullOrWhiteSpace(emplId))
                return Result.FromError<ErpBankAccountDto>($"缺失参数{nameof(emplId)}。");

            var response = await _erpExpenseReimbursementEsbService.GetBankAccount(new ErpBankAccountRequest
            {
                EmplId = emplId
            });

            var res = ObjectMapper.Map<ErpBankAccountInfo, ErpBankAccountDto>(response.Body.Data);

            return Result.FromData(res);
        }

        /// <summary>
        /// 个人借款信息查询
        /// </summary>
        /// <param name="emplId">员工工号</param>
        /// <param name="ouId">纳税单位ID</param>
        /// <param name="respType">返回格式，支持json/xml两种格式，默认为json格式</param>
        /// <returns></returns>
        public async Task<Result<List<ErpPrepayDto>>> GetPrepayList(string emplId, string ouId, string respType)
        {
            if (string.IsNullOrWhiteSpace(emplId))
                return Result.FromError<List<ErpPrepayDto>>($"缺失参数{nameof(emplId)}。");

            var response = await _erpExpenseReimbursementEsbService.GetPrepayList(new ErpPrepayRequest
            {
                EmplId = emplId,
                OuId = ouId,
                RespType = respType
            });

            var res = ObjectMapper.Map<List<ErpPrepayInfo>, List<ErpPrepayDto>>(response.Body.Data);

            return Result.FromData(res);
        }

        /// <summary>
        /// 费用报销数据推送
        /// </summary>
        /// <param name="input">费用报销数据推送输入参数</param>
        /// <returns></returns>
        public async Task<Result> ExpensesPush(ErpExpensesPushInput input)
        {
            var response = await _erpExpenseReimbursementEsbService.ExpensesPush(new ErpExpensesPushRequest
            {
                Expenses = input.Expenses,
                RespType = input.RespType
            });

            if (response.Body.Code >= 0)
                return Result.Ok();
            else
            {
                var message = $"【{response.ResultCode}】{response.Body.Message}";

                Logger.LogWarning(message);

                return Result.FromError(message);
            }
        }

        /// <summary>
        /// MO费用报销
        /// </summary>
        /// <param name="input">费用报销数据输入参数</param>
        /// <returns></returns>
        public async Task<Result> ImportExpenses(ErpImportExpensesPushInput input)
        {
            var response = await _erpExpenseReimbursementEsbService.ImportExpenses(new  ErpImportExpensesRequest
            {
                Expenses = input.Expenses
            });

            if (response.Body.Code >= 0)
                return Result.Ok();
            else
            {
                var message = $"【{response.ResultCode}】{response.Body.Message}";

                Logger.LogWarning(message);

                return Result.FromError(message);
            }
        }

        /// <summary>
        /// MO费用报销驳回处理
        /// </summary>
        /// <param name="input">MO费用报销驳回处理输入参数</param>
        /// <returns></returns>
        public async Task<Result> ProcessReject(ErpProcessRejectInput input)
        {
            var response = await _erpExpenseReimbursementEsbService.ProcessReject(new ErpProcessRejectRequest
            {
                DocId = input.DocId,
                Language = input.Language,
                SouceType = input.SouceType
            });

            if (response.Body.Code >= 0)
                return Result.Ok();
            else
            {
                var message = $"【{response.ResultCode}】{response.Body.Message}";

                Logger.LogWarning(message);

                return Result.FromError(message);
            }

        }

        /// <summary>
        /// 报销单号获取接口
        /// </summary>
        /// <returns></returns>
        public async Task<Result<ErpExpensesSeqDto>> GetExpensesSeq()
        {
          
            var response = await _erpExpenseReimbursementEsbService.GetExpensesSeq(new  ErpExpensesSeqRequest 
            {
               
            });

            var res = ObjectMapper.Map<ErpExpensesSeqInfo, ErpExpensesSeqDto>(response.Body);

            return Result.FromData(res);
        }

    }
}
