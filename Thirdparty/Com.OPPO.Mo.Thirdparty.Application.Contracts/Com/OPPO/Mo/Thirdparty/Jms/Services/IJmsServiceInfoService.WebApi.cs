using Com.OPPO.Mo.Thirdparty.Jms.Requests;
using Com.OPPO.Mo.Thirdparty.Jms.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Jms
{
    /// <summary>
    /// 跳板机服务信息WebApi服务接口
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.JmsHost)]
    public interface IJmsServiceInfoWebApiService : IHttpApi
    {
        /// <summary>
        /// 根据产品获取服务s
        /// </summary>
        /// <param name="jmsServiceQueryRequest"><see cref="JmsServiceQueryRequest"/></param>
        /// <returns></returns>
        [HttpPost("/api/oppo/v1/mo/get-service-by-product")]
        Task<JmsResponse<List<string>>> GetServiceByProduct([JsonContent] JmsServiceQueryRequest jmsServiceQueryRequest);

    }
}
