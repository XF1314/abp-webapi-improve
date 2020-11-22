using Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Dtos;
using Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Thirdparty.Hr
{
    /// <summary>
    /// 薪资
    /// </summary>
    [Area("salary")]
    [Route("api/mo/thirdparty/ps/salary")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class PeopleSoftSalaryController : AbpController, IPeopleSoftSalayAppService
    {
        private readonly IPeopleSoftSalayAppService _peopleSoftSalayAppService;

        public PeopleSoftSalaryController(IPeopleSoftSalayAppService peopleSoftSalayAppService)
        {
            _peopleSoftSalayAppService = peopleSoftSalayAppService;
        }

        /// <summary>
        /// 根据工号获取月薪信息 【第三方接口：/oppo/ps/get_comprate_by_emplid】
        /// </summary>
        /// <param name="emplid">工号</param>
        /// <returns></returns>
        [HttpGet("get-month-salary-by-emplid")]
        public async Task<Result<List<PsMonthSalaryInfoDto>>> GetMonthSalaryByEmplId(string emplid)
        {
            return await _peopleSoftSalayAppService.GetMonthSalaryByEmplId(emplid);
        }
    }
}
