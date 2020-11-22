using Com.OPPO.Mo.Thirdparty.Fdc.Dto;
using Com.OPPO.Mo.Thirdparty.Fdc.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Thirdparty.Fdc
{

    /// <summary>
    /// FDC通用接口
    /// </summary>
    [Area("fdc")]
    [Route("api/mo/thirdparty/fdc")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class FDCFinanceExpenseController : AbpController, IFinanceExpenseAppService
    {
        private readonly IFinanceExpenseAppService _FinanceExpenseAppService;

        public FDCFinanceExpenseController(IFinanceExpenseAppService FinanceExpenseAppService)
        {
            _FinanceExpenseAppService = FinanceExpenseAppService;
        }

        /// <summary>
        /// 费用报销获取基础数据【第三方接口：/data/basic/kv/api】
        /// </summary>
        /// <param name="queryDto"></param>
        /// <returns></returns>
        [HttpPost("query-finance-expense-data")]
        public async Task<Result<FinanceDataResponse>> GetFinanceExpenseMsg([FromBody]FinanceQueryDto queryDto)
        {
            return await _FinanceExpenseAppService.GetFinanceExpenseMsg(queryDto);
        }

    }

}
