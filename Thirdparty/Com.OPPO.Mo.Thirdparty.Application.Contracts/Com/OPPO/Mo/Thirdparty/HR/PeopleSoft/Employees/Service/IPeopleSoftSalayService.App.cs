using Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Service
{
    /// <summary>
    /// 人员薪资接口
    /// </summary>
    public interface IPeopleSoftSalayAppService : IApplicationService
    {
        /// <summary>
        /// 根据工号获取月薪信息
        /// </summary>
        /// <param name="emplid">工号</param>
        /// <returns></returns>
        Task<Result<List<PsMonthSalaryInfoDto>>>GetMonthSalaryByEmplId(string emplid);
    }
}
