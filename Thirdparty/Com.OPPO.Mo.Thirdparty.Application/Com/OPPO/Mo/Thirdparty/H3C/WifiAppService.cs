using Com.OPPO.Mo.Thirdparty.Wifi.Dtos;
using Com.OPPO.Mo.Thirdparty.Wifi.Requests;
using Com.OPPO.Mo.Thirdparty.Wifi.Responses;
using Com.OPPO.Mo.Thirdparty.Wifi.Services;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.Wifi
{
    /// <summary>
    /// wifi 应用服务
    /// </summary>
    [Authorize]
    public class WifiAppService : ThirdpartyAppServiceBase, IWifiAppService
    {
        private readonly IWifiWebApiService _wifiWebApiService;

        public WifiAppService(IWifiWebApiService wifiWebApiService)
        {
            _wifiWebApiService = wifiWebApiService;
        }

        /// <summary>
        /// 根据访客接口人电话,查询wifi信息（aruba）
        /// <param name="phone">访客接口人电话</param>
        /// </summary>
        /// <returns></returns>
        public async Task<Result<WifiRefDataRawDto>> GetWifiRefDataRaw(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return Result.FromError<WifiRefDataRawDto>($"缺失参数{nameof(phone)}。");

            var response = await _wifiWebApiService.GetWifiRefDataRaw(phone);

            var res = ObjectMapper.Map<WifiRefDataRawInfo, WifiRefDataRawDto>(response);

            return Result.FromData(res);
        }

        /// <summary>
        ///  增加接入用户
        /// </summary>
        /// <param name="input">增加接入用户参数信息</param>
        /// <returns></returns>
        public async Task<Result<string>> CreateWifi(WifiCreateInput wifiCreateInput)
        {
            var request = ObjectMapper.Map<WifiCreateInput, WifiCreateRequest>(wifiCreateInput);

            var response = await _wifiWebApiService.CreateWifi(request);

            return Result.FromData(response);

        }
    }
}
