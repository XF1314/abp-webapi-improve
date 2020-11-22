using Com.OPPO.Mo.Thirdparty.Jms.Requests;
using Com.OPPO.Mo.Thirdparty.Jms.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Jms
{
    /// <summary>
    /// 跳板机模块信息WebApi服务接口
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.JmsHost)]
    public interface IJmsModuleInfoWebApiService : IHttpApi
    {
        /// <summary>
        /// 根据产品和服务获取模块
        /// </summary>
        /// <param name="jmsModuleQueryRequest"><see cref="JmsModuleQueryRequest"/></param>
        /// <returns></returns>
        [HttpPost("/api/oppo/v1/mo/get-module-by-product-service")]
        Task<JmsResponse<List<string>>> GetJmsModuleByProductAndService([JsonContent] JmsModuleQueryRequest jmsModuleQueryRequest);
    }
}
