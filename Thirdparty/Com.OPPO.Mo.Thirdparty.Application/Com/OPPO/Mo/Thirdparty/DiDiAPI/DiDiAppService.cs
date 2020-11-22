using Com.OPPO.Mo.Thirdparty.DiDi.Dtos;
using Com.OPPO.Mo.Thirdparty.DiDi.Requests;
using Com.OPPO.Mo.Thirdparty.DiDi.Services;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DiDi
{
    /// <summary>
    /// DiDi 服务实现类
    /// </summary>
    [Authorize]
    public class DiDiAppService : ThirdpartyAppServiceBase, IDiDiAppService
    {
        private readonly IDiDiServiceWebApiService _diDiServiceWebApiService;

        public DiDiAppService(IDiDiServiceWebApiService diDiServiceWebApiService)
        {
            _diDiServiceWebApiService = diDiServiceWebApiService;
        }

        /// <summary>
        /// 获取滴滴AccessToken OnePlusDiDiAuthorizeDto
        /// </summary>
        /// <param name="phone">管理员手机号</param>
        /// <returns></returns>
        public async Task<Result<object>> GetAccessToken(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return Result.FromError<object>($"缺失参数{nameof(phone)}。");

            var response = await _diDiServiceWebApiService.Authorize(new DiDiAuthorizeRequest
            {
                Phone = phone
            });

            //var info = ObjectMapper.Map<OnePlusDiDiAuthorizeInfo, OnePlusDiDiAuthorizeDto>(response);

            return Result.FromData(response);
        }

        /// <summary>
        /// 获取用车制度 【第三方接口：/river/Regulation/get】
        /// </summary>
        /// <param name="accessToken">授权后的access token</param>
        /// <returns></returns>
        public async Task<Result<DiDiRegulationDto>> GetRegulationList(string accessToken)
        {
            var response = await _diDiServiceWebApiService.GetRegulationList(new DiDiRegulationRequest
            {
                AccessToken = accessToken
            });

            var info = ObjectMapper.Map<DiDiRegulationInfo, DiDiRegulationDto>(response);

            return Result.FromData(info);
        }

        /// <summary>
        /// 获取城市
        /// </summary>
        /// <param name="accessToken">授权后的access token</param>
        /// <returns></returns>
        public async Task<Result<DiDiCityDto>> GetCityList(string accessToken)
        {
            var response = await _diDiServiceWebApiService.GetCityList(new  DiDiCityRequest
            {
                AccessToken = accessToken
            });

            var info = ObjectMapper.Map<DiDiCityInfo, DiDiCityDto>(response);

            return Result.FromData(info);
        }

        /// <summary>
        /// 根据员工编号获取用车制度 【第三方接口：/river/Member/detail】
        /// </summary>
        /// <param name="accessToken">授权后的access token</param>
        /// <param name="nmemberId">员工id（员工新建接口中返回的企业版id）</param>
        /// <returns></returns>
        public async Task<Result<DiDiRegulateDto>> GetRegulationListByMemberId(string accessToken, long nmemberId)
        {
            var response = await _diDiServiceWebApiService.GetRegulationListByMemberId(new DiDiRegulationTRequest
            {
                AccessToken = accessToken,
                MemberId = nmemberId
            });

            var info = ObjectMapper.Map<DiDiRegulation, DiDiRegulateDto>(response);

            return Result.FromData(info);
        }

        /// <summary>
        /// 创建滴滴审批单
        /// </summary>
        /// <param name="input">创建审批单输入参数信息</param>
        /// <returns></returns>
        public async Task<Result<DiDiCreateDto>> Create(DiDiCreateInput input)
        {
            if (string.IsNullOrWhiteSpace(input.Phone))
                return Result.FromError<DiDiCreateDto>($"缺失参数{nameof(input.Phone)}。");
            if (input.ApprovalType == ApprovalType.Travel)
            {
                if (input.TravelDetail == null)
                {
                    return Result.FromError<DiDiCreateDto>($"缺失参数{nameof(input.TravelDetail)}。");
                }
                else if (input.TravelDetail.Trips == null)
                {
                    return Result.FromError<DiDiCreateDto>($"缺失参数{nameof(input.TravelDetail.Trips)}。");
                }
            }

            var resquest = new DiDiCreateRequest
            {
                Token = input.AccessToken,
                Phone = input.Phone,
                ApprovalType = Convert.ToInt32(input.ApprovalType),
                TravelDetail = new TravelDetailInfo
                {
                    StartDate = input.TravelDetail.StartDate.ToString("yyyy-MM-dd"),
                    EndDate = input.TravelDetail.EndDate.ToString("yyyy-MM-dd"),
                    Trips = input.TravelDetail.Trips.Select(m => new TripsInfo
                    {
                        DepartureCity = m.DepartureCity,
                        DepartureCityId = m.DepartureCityId,
                        DestinationCity = m.DestinationCity,
                        DestinationCityId = m.DestinationCityId,
                        StartDate = m.StartDate.ToString("yyyy-MM-dd"),
                        EndDate = m.EndDate.ToString("yyyy-MM-dd")
                    }).ToList(),
                    EndCityRule = Convert.ToInt32(input.TravelDetail.EndCityRule)
                },
                RegulationId = input.RegulationId
            };

            var response = await _diDiServiceWebApiService.Create(resquest);

            var info = ObjectMapper.Map<DiDiCreateInfo, DiDiCreateDto>(response);

            return Result.FromData(info);
        }

        
    }
}
