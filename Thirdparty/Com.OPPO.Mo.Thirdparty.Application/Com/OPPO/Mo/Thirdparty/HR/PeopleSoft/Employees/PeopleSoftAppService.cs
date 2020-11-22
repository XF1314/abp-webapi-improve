using Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Dtos;
using Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Requests;
using Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Service;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees
{
    /// <summary>
    /// 人事应用服务类
    /// </summary>
    [Authorize]
    public class PeopleSoftAppService : ThirdpartyAppServiceBase, IPeopleSoftAppService
    {
        private readonly IPeopleSoftEsbService _peopleSoftEsbService;
        public PeopleSoftAppService(IPeopleSoftEsbService peopleSoftEsbService)
        {
            _peopleSoftEsbService = peopleSoftEsbService;
        }

        /// <summary>
        /// 根据工号获取认证信息
        /// </summary>
        /// <param name="emplId">工号</param>
        /// <param name="type">返回格式，支持json/xml两种格式，默认为json格式</param>
        /// <returns></returns>
        public async Task<Result<PsAuthenticateDto>> GetAuthenticateListByEmplId(string emplId, string type = "")
        {
            if (string.IsNullOrWhiteSpace(emplId))
                return Result.FromError<PsAuthenticateDto>($"缺失参数{nameof(emplId)}。");

            var response = await _peopleSoftEsbService.GetAuthenticateListByEmplid(new PsAuthenticateRequest
            {
                EmplId = emplId,
                Type = type
            });

            var res = ObjectMapper.Map<PsAuthenticateInfo, PsAuthenticateDto>(response.Body);

            return Result.FromData(res);
        }

        /// <summary>
        /// 根据工号和年份查询个人绩效
        /// </summary>
        /// <param name="emplId">工号</param>
        /// <param name="year">年份</param>
        /// <param name="type">返回格式，支持json/xml两种格式，默认为json格式</param>
        /// <returns></returns>
        public async Task<Result<PsPerformanceDto>> GetPerformanceListByEmplIdAndYear(string emplId, string year, string type = "")
        {
            if (string.IsNullOrWhiteSpace(emplId))
                return Result.FromError<PsPerformanceDto>($"缺失参数{nameof(emplId)}。");

            if (string.IsNullOrWhiteSpace(emplId))
                return Result.FromError<PsPerformanceDto>($"缺失参数{nameof(year)}。");

            var response = await _peopleSoftEsbService.GetperformanceListByEmplidAndYear(new PsPerformanceRequest
            {
                EmplId = emplId,
                Type = type,
                Year = year
            });

            var res = ObjectMapper.Map<PsPerformanceInfo, PsPerformanceDto>(response.Body);

            return Result.FromData(res);
        }

        /// <summary>
        /// 查询所有通道信息
        /// </summary>
        /// <returns></returns>
        public async Task<Result<PsJobfunctionDto>> GetJobFunctionCode(string type = "")
        {
            var response = await _peopleSoftEsbService.GetJobFunctionList(new PsJobfunctionRequest
            {
                Type = type
            });

            var res = ObjectMapper.Map<PsJobfunctionInfo, PsJobfunctionDto>(response.Body);

            return Result.FromData(res);
        }

        /// <summary>
        /// 根据通道查询领域信息
        /// </summary>
        /// <param name="code">通道代码</param>
        /// <param name="type">返回格式，支持json/xml两种格式，默认为json格式</param>
        /// <returns></returns>
        public async Task<Result<PsSubfunctionDto>> GetFunctionCode(string code, string type = "")
        {
            if (string.IsNullOrWhiteSpace(code))
                return Result.FromError<PsSubfunctionDto>($"缺失参数{nameof(code)}。");

            var response = await _peopleSoftEsbService.GetSubfunctionList(new PsSubfunctionRequest
            {
                Code = code,
                Type = type
            });

            var res = ObjectMapper.Map<PsSubfunctionInfo, PsSubfunctionDto>(response.Body);

            return Result.FromData(res);
        }

        /// <summary>
        /// 任职资格信息推送
        /// </summary>
        /// <param name="input">任职资格信息</param>
        /// <returns></returns>
        public async Task<Result<PsQualificationDto>> QualificationPush(PsQualificationPushInput input)
        {
            var response = await _peopleSoftEsbService.QualificationPush(new PsQualificationPushRequest
            {
                DataJson = input.DataJson
            });

            var res = ObjectMapper.Map<PsQualificationInfo, PsQualificationDto>(response.Body);

            return Result.FromData(res);
        }

    }
}
