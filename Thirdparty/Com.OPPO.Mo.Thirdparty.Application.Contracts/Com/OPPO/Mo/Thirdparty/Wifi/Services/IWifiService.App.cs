using Com.OPPO.Mo.Thirdparty.Wifi.Dtos;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.Wifi
{
    public interface IWifiAppService : IApplicationService
    {
        /// <summary>
        /// 根据访客接口人电话,查询wifi信息（aruba）
        /// <param name="phone">访客接口人电话</param>
        /// </summary>
        /// <returns></returns>
        Task<Result<WifiRefDataRawDto>> GetWifiRefDataRaw(string phone);

        /// <summary>
        /// 创建wifi
        /// </summary>
        /// <param name="input">创建wifi参数信息</param>
        /// <returns></returns>
        Task<Result<string>> CreateWifi(WifiCreateInput input);

    }
}
