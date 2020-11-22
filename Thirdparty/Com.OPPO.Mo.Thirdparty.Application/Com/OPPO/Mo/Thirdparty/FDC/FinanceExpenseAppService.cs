using Com.OPPO.Mo.Thirdparty.Fdc;
using Com.OPPO.Mo.Thirdparty.Fdc.Dto;
using Com.OPPO.Mo.Thirdparty.Fdc.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.Fdc
{

    [Authorize]
    public class FinanceExpenseAppService : ThirdpartyAppServiceBase, IFinanceExpenseAppService
    {
        private readonly IConfiguration _configuration;
        private readonly IFinanceExpenseWebApiService _EsbService;

        public FinanceExpenseAppService(
            IConfiguration configuration,
            IFinanceExpenseWebApiService peopleSoftLeaveEsbService)
        {
            _configuration = configuration;
            _EsbService = peopleSoftLeaveEsbService;
        }

        /// <summary>
        /// 费用报销获取基础数据【第三方接口：/data/basic/kv/api】
        /// </summary>
        /// <param name="queryDto"></param>
        /// <returns></returns>
        public async Task<Result<FinanceDataResponse>> GetFinanceExpenseMsg(FinanceQueryDto queryDto)
        {
            var response = await _EsbService.GetFinanceExpenseMsg(queryDto);
            if (response.ReturnCode == "0000")
            {
                return Result.FromData(response);
            }
            else
            {
                var message = $"【{response.ReturnCode}】{response.ReturnMsg}";
                Logger.LogWarning(message);
                return Result.FromError<FinanceDataResponse>(message);
            }
        }


    }

}
