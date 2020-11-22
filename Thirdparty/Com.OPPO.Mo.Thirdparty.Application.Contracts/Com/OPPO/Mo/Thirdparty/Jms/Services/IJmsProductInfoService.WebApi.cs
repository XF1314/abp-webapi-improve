using Com.OPPO.Mo.Thirdparty.Jms.Requests;
using Com.OPPO.Mo.Thirdparty.Jms.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Jms
{
    /// <summary>
    /// 跳板机产品WebApi服务接口
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.JmsHost)]
    public interface IJmsProductInfoWebApiService : IHttpApi
    {
        /// <summary>
        /// 获取所有产品s
        /// </summary>
        /// <param name="baseJmsRequest"><see cref="BaseJmsRequest"/></param>
        /// <returns></returns>
        [HttpPost("/api/oppo/v1/mo/product-list")]
        Task<JmsResponse<List<string>>> GetAllProducts([JsonContent] BaseJmsRequest baseJmsRequest);

    }
}
