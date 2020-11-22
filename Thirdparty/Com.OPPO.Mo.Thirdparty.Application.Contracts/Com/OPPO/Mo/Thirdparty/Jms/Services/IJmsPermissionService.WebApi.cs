using Com.OPPO.Mo.Thirdparty.Jms.Requests;
using Com.OPPO.Mo.Thirdparty.Jms.Responses;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Jms
{
    /// <summary>
    /// 跳板机权限信息WebApi服务接口
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.JmsHost)]
    public interface IJmsPermissionWebApiService : IHttpApi
    {
        /// <summary>
        /// 新增Jms权限
        /// </summary>
        /// <param name="jmsPermissionAddRequest"><see cref="JmsPermissionAddRequest"/></param>
        /// <returns></returns>
        [HttpPost("/api/oppo/v1/mo/asset-permissions/add")]
        Task<JmsResponse> AddPermission([JsonContent] JmsPermissionAddRequest jmsPermissionAddRequest);
    }
}
