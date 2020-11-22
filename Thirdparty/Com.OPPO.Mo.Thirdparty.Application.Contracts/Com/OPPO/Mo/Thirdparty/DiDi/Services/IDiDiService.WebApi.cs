using Com.OPPO.Mo.Thirdparty.DiDi.Dtos;
using Com.OPPO.Mo.Thirdparty.DiDi.Requests;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.DiDi.Services
{
    /// <summary>
    /// DiDi WebApi服务接口
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.DiDiOpenApiHost)]
    public interface IDiDiServiceWebApiService : IHttpApi
    {
        /// <summary>
        /// 获取授权access_token OnePlusDiDiAuthorizeInfo
        /// </summary>
        /// <param name="request"><see cref="DiDiAuthorizeRequest"/></param>
        /// <returns></returns>
        [HttpPost("/river/Auth/authorize")]
        Task<object> Authorize([JsonContent] DiDiAuthorizeRequest request);

        /// <summary>
        /// 获取用车制度
        /// </summary>
        /// <param name="request"><see cref="DiDiRegulationRequest"/></param>
        /// <returns></returns>
        [HttpGet("/river/Regulation/get")]
        Task<DiDiRegulationInfo> GetRegulationList([PathQuery] DiDiRegulationRequest request);

        /// <summary>
        /// 获取城市列表
        /// </summary>
        /// <param name="request"><see cref="DiDiRegulationRequest"/></param>
        /// <returns></returns>
        [HttpGet("/river/City/get")]
        Task<DiDiCityInfo> GetCityList([PathQuery] DiDiCityRequest request);


        /// <summary>
        /// 根据员工编号获取用车制度 【第三方接口：/river/Member/detail】
        /// </summary>
        /// <param name="request"><see cref="DiDiRegulationTRequest"/></param>
        /// <returns></returns>
        [HttpGet("/river/Member/detail")]
        Task<DiDiRegulation> GetRegulationListByMemberId([PathQuery] DiDiRegulationTRequest request);

        /// <summary>
        /// 创建滴滴审批单
        /// </summary>
        /// <param name="request"><see cref="DiDiCreateRequest"/></param>
        /// <returns></returns>
        [HttpPost("/river/Approval/create")]
        Task<DiDiCreateInfo> Create([JsonContent] DiDiCreateRequest request);
    }
}
