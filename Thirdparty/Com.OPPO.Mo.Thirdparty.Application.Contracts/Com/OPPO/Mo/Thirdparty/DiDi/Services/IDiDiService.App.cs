using Com.OPPO.Mo.Thirdparty.DiDi.Dtos;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.DiDi.Services
{
    /// <summary>
    /// 滴滴 服务接口
    /// </summary>
    public interface IDiDiAppService : IApplicationService
    {
        /// <summary>
        /// 获取滴滴AccessToken OnePlusDiDiAuthorizeDto
        /// </summary>
        /// <param name="phone">管理员手机号</param>
        /// <returns></returns>
        Task<Result<object>> GetAccessToken(string phone);

        Task<Result<DiDiRegulationDto>> GetRegulationList(string accessToken);

        /// <summary>
        /// 获取用车制度 【第三方接口：/river/City/get】
        /// </summary>
        /// <param name="accessToken">授权后的access token</param>
        /// <returns></returns>
        Task<Result<DiDiCityDto>> GetCityList(string accessToken);

        /// <summary>
        /// 根据员工编号获取用车制度 【第三方接口：/river/Member/detail】
        /// </summary>
        /// <param name="accessToken">授权后的access token</param>
        /// <param name="nmemberId">员工id（员工新建接口中返回的企业版id）</param>
        /// <returns></returns>
        Task<Result<DiDiRegulateDto>> GetRegulationListByMemberId(string accessToken, long nmemberId);

        /// <summary>
        /// 创建滴滴审批单
        /// </summary>
        /// <param name="input">创建审批单输入参数信息</param>
        /// <returns></returns>
        Task<Result<DiDiCreateDto>> Create(DiDiCreateInput input);
    }
}
