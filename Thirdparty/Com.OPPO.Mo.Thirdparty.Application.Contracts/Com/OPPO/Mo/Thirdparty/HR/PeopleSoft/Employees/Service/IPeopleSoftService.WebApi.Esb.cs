using Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Dtos;
using Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Requests;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Service
{
    /// <summary>
    /// PeopleSoft 内部调动Esb服务接口
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.EsbHost)]
    public interface IPeopleSoftEsbService : IHttpApi
    {
        /// <summary>
        /// 根据工号查询认证信息
        /// </summary>
        /// <param name="request"><see cref="PsAuthenticateRequest"/></param>
        /// <returns></returns>
        [HttpGet("/oppo/ps/authenticate_list")]
        Task<HrResponseResult<PsAuthenticateInfo>> GetAuthenticateListByEmplid([PathQuery] PsAuthenticateRequest request);

        /// <summary>
        /// 根据工号和年份查询个人绩效
        /// </summary>
        /// <param name="request"><see cref="PsPerformanceRequest"/></param>
        /// <returns></returns>
        [HttpGet("/oppo/ps/performance_list")]
        Task<HrResponseResult<PsPerformanceInfo>> GetperformanceListByEmplidAndYear([PathQuery] PsPerformanceRequest request);

        /// <summary>
        /// 查询所有通道信息
        /// </summary>
        /// <param name="request"><see cref="PsSubfunctionRequest"/></param>
        /// <returns></returns>
        [HttpGet("/oppo/ps/jobfunction_list")]
        Task<HrResponseResult<PsJobfunctionInfo>> GetJobFunctionList([PathQuery] PsJobfunctionRequest request);

        /// <summary>
        /// 根据通道查询领域信息
        /// </summary>
        /// <param name="request"><see cref="PsSubfunctionRequest"/></param>
        /// <returns></returns>
        [HttpGet("/oppo/ps/subfunction_list")]
        Task<HrResponseResult<PsSubfunctionInfo>> GetSubfunctionList([PathQuery] PsSubfunctionRequest request);

       
        /// <summary>
        /// 任职资格信息推送-例行认证
        /// </summary>
        /// <param name="request"><see cref="PsQualificationPushRequest"/></param>
        /// <returns></returns>
        [HttpPost("/oppo/ps/qualification_push")]
        Task<HrResponseResult<PsQualificationInfo>> QualificationPush([FormContent] PsQualificationPushRequest request);
    }
}
