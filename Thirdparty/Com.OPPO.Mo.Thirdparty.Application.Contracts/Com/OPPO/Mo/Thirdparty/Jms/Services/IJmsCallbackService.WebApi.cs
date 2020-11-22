using Com.OPPO.Mo.Thirdparty.Jms.Requests;
using Com.OPPO.Mo.Thirdparty.Jms.Responses;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Jms
{
    /// <summary>
    /// 跳板机系统回调WebApi服务接口
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.JmsHost)]
    public interface IJmsCallbackWebApiService : IHttpApi
    {
        /// <summary>
        /// 流程结束时回调
        /// </summary>
        /// <param name="jmsApporvalCallbackRequest"><see cref="JmsProcessFinishedCallbackRequest"/></param>
        /// <returns></returns>
        [HttpPost("/api/oppo/v1/mo/tmp-perm/update")]
        Task<JmsResponse> CallbackWhenProcessFinished([JsonContent] JmsProcessFinishedCallbackRequest jmsApporvalCallbackRequest);
    }
}
