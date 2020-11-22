using Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Dtos;
using Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Requests;
using Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Responses;
using Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Service;
using Com.OPPO.Mo.Thirdparty.Hr.Public;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees
{
    /// <summary>
    /// ps 服务应用接口
    /// </summary>
    [Authorize]
    public class PeopleSoftSalayAppService : ThirdpartyAppServiceBase, IPeopleSoftSalayAppService
    {

        private readonly IPeopleSoftPublicEsbService _peopleSoftLeaveEsbService;

        public PeopleSoftSalayAppService(IPeopleSoftPublicEsbService peopleSoftLeaveEsbService)
        {
            _peopleSoftLeaveEsbService = peopleSoftLeaveEsbService;
        }

        /// <summary>
        /// 根据工号获取月薪信息
        /// </summary>
        /// <param name="emplid">工号</param>
        /// <returns></returns>
        public async Task<Result<List<PsMonthSalaryInfoDto>>> GetMonthSalaryByEmplId(string emplid)
        {
            if (string.IsNullOrWhiteSpace(emplid))
            {
                return Result.FromError<List<PsMonthSalaryInfoDto>>($"缺失参数{nameof(emplid)}。");
            }

            var response = await _peopleSoftLeaveEsbService.GetComprateByEmplid(new PsMonthSalaryRequest
            {
                EmplId = emplid
            });

            var info = ObjectMapper.Map<List<MonthSalaryInfo>, List<PsMonthSalaryInfoDto>>(response.Data.Data);

            return Result.FromData(info);
        }
    }

}
