using Com.OPPO.Mo.Thirdparty.Jms.Requests;
using Com.OPPO.Mo.Thirdparty.Jms.Responses;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Jms
{
    /// <summary>
    /// 跳板机业务信息WebApi服务接口
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.JmsHost)]
    public interface IJmsBusinessInfoWebApiService : IHttpApi
    {
        /// <summary>
        /// 根据员工工号和业务树获取业务Owner
        /// </summary>
        /// <param name="jmsBusinessOwnerQueryRequest"></param>
        /// <returns></returns>
        [HttpPost("/api/oppo/v1/mo/business/owner")]
        Task<JmsResponse<JmsBusinessOwnerInfo>> GetJmsBusinessOwnerByUserAndBusinessTree([JsonContent] JmsBusinessOwnerQueryRequest jmsBusinessOwnerQueryRequest);

    }
}
