using Com.OPPO.Mo.Thirdparty.Wifi.Dtos;
using Com.OPPO.Mo.Thirdparty.Wifi;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Thirdparty.Wifi
{
    /// <summary>
    /// h3c-wifi
    /// </summary>
    [Area("h3c-wifi")]
    [Route("api/mo/thirdparty/h3c/")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class WifiController : AbpController, IWifiAppService
    {
        private readonly IWifiAppService _wifiAppService;

        /// <summary>
        /// <see cref="WifiController"/>
        /// </summary>
        public WifiController(IWifiAppService wifiAppService)
        {
            _wifiAppService = wifiAppService;
        }

        /// <summary>
        /// 根据访客接口人电话,查询wifi信息【第三方接口：/imcrs/uam/acmUser】
        /// </summary>
        /// <param name="phone">访客接口人电话</param>
        /// <returns></returns>
        [HttpGet("get-wifi-info-by-phone")]
        public async Task<Result<WifiRefDataRawDto>> GetWifiRefDataRaw(string phone)
        {
            return await _wifiAppService.GetWifiRefDataRaw(phone);
        }

        /// <summary>
        /// 增加接入用户 【第三方接口：/imcrs/uam/acmUser】
        /// </summary>
        /// <param name="wifiCreateInput">增加接入用户参数信息</param>
        /// <returns></returns>
        [HttpPost("create-wifi")]
        public async Task<Result<string>> CreateWifi(WifiCreateInput wifiCreateInput)
        {
            return await _wifiAppService.CreateWifi(wifiCreateInput);
        }


    }
}
