using Com.OPPO.Mo.Thirdparty.Jms.Requests;
using Com.OPPO.Mo.Thirdparty.Jms.Responses;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Jms
{
    /// <summary>
    /// 跳板机Host信息WebApi服务接口
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.JmsHost)]
    public interface IJmsHostInfoWebApiService : IHttpApi
    {
        /// <summary>
        /// 通过Ip或服务名获取服务器信息
        /// </summary>
        /// <param name="jmsHostInfoQueryRequest"></param>
        /// <returns></returns>
        [HttpPost("/api/oppo/v1/mo/host/info")]
        Task<JmsResponse<JmsHostInfo>> GetHostInfoByIpOrHostName([JsonContent] JmsHostInfoQueryRequest jmsHostInfoQueryRequest);

    }
}
