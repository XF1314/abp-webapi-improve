using Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Dtos;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.Employees.Service
{
    /// <summary>
    /// 人事应用服务接口
    /// </summary>
    public interface IPeopleSoftAppService : IApplicationService
    {
        /// <summary>
        /// 根据工号获取认证信息
        /// </summary>
        /// <param name="emplId">工号</param>
        /// <param name="type">返回格式，支持json/xml两种格式，默认为json格式</param>
        /// <returns></returns>
        Task<Result<PsAuthenticateDto>> GetAuthenticateListByEmplId(string emplId, string type = "");

        /// <summary>
        /// 根据工号和年份查询个人绩效
        /// </summary>
        /// <param name="emplId">工号</param>
        /// <param name="year">年份</param>
        /// <param name="type">返回格式，支持json/xml两种格式，默认为json格式</param>
        /// <returns></returns>
        Task<Result<PsPerformanceDto>> GetPerformanceListByEmplIdAndYear(string emplId, string year, string type = "");

        /// <summary>
        /// 查询所有通道信息
        /// </summary>
        /// <returns></returns>
        Task<Result<PsJobfunctionDto>> GetJobFunctionCode(string type = "");

        /// <summary>
        /// 根据通道查询领域信息
        /// </summary>
        /// <param name="code">通道代码</param>
        /// <param name="type">返回格式，支持json/xml两种格式，默认为json格式</param>
        /// <returns></returns>
        Task<Result<PsSubfunctionDto>> GetFunctionCode(string code, string type = "");

        /// <summary>
        /// 任职资格信息推送
        /// </summary>
        /// <param name="input">任职资格信息</param>
        /// <returns></returns>
        Task<Result<PsQualificationDto>> QualificationPush(PsQualificationPushInput input);
    }
}
