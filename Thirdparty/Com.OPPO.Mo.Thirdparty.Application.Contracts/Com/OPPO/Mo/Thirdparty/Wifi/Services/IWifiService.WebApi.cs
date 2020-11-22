using Com.OPPO.Mo.Thirdparty.Wifi.Requests;
using Com.OPPO.Mo.Thirdparty.Wifi.Responses;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Wifi.Services
{
    /// <summary>
    /// H3C  WebApi Service
    /// </summary>
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.WifiWebApiHost)]
    public interface IWifiWebApiService : IHttpApi
    {
        /// <summary>
        /// 查询wifi
        /// <param name="userName">访客接口人电话</param>
        /// </summary>
        /// <returns></returns>
        [HttpGet("/imcrs/uam/acmUser/")]
        Task<WifiRefDataRawInfo> GetWifiRefDataRaw([Uri] string userName);

        /// <summary>
        /// 创建wifi
        /// <param name="request">创建wifii参数信息</param>
        /// </summary>
        /// <returns></returns>
        [HttpPost("/imcrs/uam/acmUser")]
        Task<string> CreateWifi([JsonContent] WifiCreateRequest request);
    }
}
