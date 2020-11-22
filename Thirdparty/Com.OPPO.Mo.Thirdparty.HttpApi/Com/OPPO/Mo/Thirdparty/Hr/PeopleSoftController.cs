using Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Dtos;
using Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Thirdparty.Hr
{
    /// <summary>
    /// ps 资源
    /// </summary>
    [Area("ps")]
    [Route("api/mo/thirdparty/ps/")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class PeopleSoftController : AbpController, IPeopleSoftAppService
    {
        private readonly IPeopleSoftAppService _peopleSoftAppService;

        public PeopleSoftController(IPeopleSoftAppService peopleSoftAppService)
        {
            _peopleSoftAppService = peopleSoftAppService;
        }

        /// <summary>
        /// 根据工号获取认证信息 【第三方接口：/oppo/ps/authenticate_list】
        /// </summary>
        /// <param name="emplId">工号</param>
        /// <param name="type">返回格式，支持json/xml两种格式，默认为json格式</param>
        /// <returns></returns>
        [HttpGet("get-authenticate-list-by-emplid")]
        public async Task<Result<PsAuthenticateDto>> GetAuthenticateListByEmplId(string emplId, string type = "")
        {
            return await _peopleSoftAppService.GetAuthenticateListByEmplId(emplId, type);
        }

        /// <summary>
        /// 查询所有通道信息 【第三方接口：/oppo/ps/jobfunction_list】
        /// </summary>
        /// <param name="type">返回格式，支持json/xml两种格式，默认为json格式</param>
        /// <returns></returns>
        [HttpGet("get-jobfunction-list")]
        public async Task<Result<PsJobfunctionDto>> GetJobFunctionCode(string type = "")
        {
            return await _peopleSoftAppService.GetJobFunctionCode(type);
        }

        /// <summary>
        /// 根据通道查询领域信息 【第三方接口：/oppo/ps/subfunction_list】
        /// </summary>
        /// <param name="code">通道代码</param>
        /// <param name="type">返回格式，支持json/xml两种格式，默认为json格式</param>
        /// <returns></returns>
        [HttpGet("get-subfunction-list-by-code")]
        public async Task<Result<PsSubfunctionDto>> GetFunctionCode(string code, string type = "")
        {
            return await _peopleSoftAppService.GetFunctionCode(code, type);
        }

        /// <summary>
        /// 任职资格信息推送 【第三方接口：/oppo/ps/qualification_push】
        /// </summary>
        /// <param name="input">任职资格信息</param>
        /// <returns></returns>
        [HttpPost("qualification-push")]
        public async Task<Result<PsQualificationDto>> QualificationPush(PsQualificationPushInput input)
        {
            return await _peopleSoftAppService.QualificationPush(input);
        }

        /// <summary>
        /// 根据工号和年份查询个人绩效 【第三方接口：/oppo/ps/performance_list】
        /// </summary>
        /// <param name="emplId">工号</param>
        /// <param name="year">年份</param>
        /// <param name="type">返回格式，支持json/xml两种格式，默认为json格式</param>
        /// <returns></returns>
        [HttpGet("get-performance-list-by-emplid-and-year")]
        public async Task<Result<PsPerformanceDto>> GetPerformanceListByEmplIdAndYear(string emplId, string year, string type = "")
        {
            return await _peopleSoftAppService.GetPerformanceListByEmplIdAndYear(emplId,year, type);
        }
    }
}
