using Com.OPPO.Mo.Thirdparty.DiDi.Dtos;
using Com.OPPO.Mo.Thirdparty.DiDi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Thirdparty.DiDi
{
    /// <summary>
    /// didi
    /// </summary>
    [Area("didi")]
    [Route("api/mo/thirdparty/didi/")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class DiDiController : AbpController, IDiDiAppService
    {
        private readonly IDiDiAppService _diDiAppService;
        public DiDiController(IDiDiAppService diDiAppService)
        {
            _diDiAppService = diDiAppService;
        }

        /// <summary>
        /// 获取滴滴AccessToken 【第三方接口：river/Auth/authorize】
        /// </summary>
        /// <param name="phone">管理员手机号</param>
        /// <returns></returns>
        [HttpGet("get-access-token")]
        public async Task<Result<object>> GetAccessToken(string phone)
        {
            return await _diDiAppService.GetAccessToken(phone);
        }

        /// <summary>
        /// 获取城市 【第三方接口：/river/City/get】
        /// </summary>
        /// <param name="accessToken">授权后的access token</param>
        /// <returns></returns>
        [HttpGet("get-city")]
        public async Task<Result<DiDiCityDto>> GetCityList(string accessToken)
        {
            return await _diDiAppService.GetCityList(accessToken);
        }

        /// <summary>
        /// 获取用车制度 【第三方接口：/river/Regulation/get】
        /// </summary>
        /// <param name="accessToken">授权后的access token</param>
        /// <returns></returns>
        [HttpGet("get-regulation")]
        public async Task<Result<DiDiRegulationDto>> GetRegulationList(string accessToken)
        {
            return await _diDiAppService.GetRegulationList(accessToken);
        }

        /// <summary>
        /// 根据员工编号获取用车制度 【第三方接口：/river/Member/detail】
        /// </summary>
        /// <param name="accessToken">授权后的access token</param>
        /// <param name="nmemberId">员工id（员工新建接口中返回的企业版id）</param>
        /// <returns></returns>
        [HttpGet("get-member-detail-regulation")]
        public async Task<Result<DiDiRegulateDto>> GetRegulationListByMemberId(string accessToken, long nmemberId)
        {
            return await _diDiAppService.GetRegulationListByMemberId(accessToken, nmemberId);
        }

        /// <summary>
        /// 创建滴滴审批单 【第三方接口：/river/Approval/create】
        /// </summary>
        /// <param name="input">创建审批单输入参数信息</param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<Result<DiDiCreateDto>> Create([FromBody]DiDiCreateInput input)
        {
            return await _diDiAppService.Create(input);
        }


    }
}
