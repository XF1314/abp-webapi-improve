using Com.OPPO.Mo.Thirdparty.Fdc.Dto;
using Com.OPPO.Mo.Thirdparty.Fdc.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.Fdc
{

    /// <summary>
    /// FDC-财务通用接口
    /// </summary>
    public interface IFinanceExpenseAppService : IApplicationService
    {

        /// <summary>
        /// 费用报销获取基础数据
        /// </summary>
        /// <param name="queryDto"></param>
        /// <returns></returns>
        Task<Result<FinanceDataResponse>> GetFinanceExpenseMsg(FinanceQueryDto queryDto);

    }

}
