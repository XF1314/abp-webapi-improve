using Com.OPPO.Mo.Bpm.ActionSoft.Notifications.Requests;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Notifications
{
    /// <summary>
    /// ActionSoft消息通知WebApi服务接口
    /// </summary>
    [ConfigurableHttpHost(BpmSettingNames.ActiontSoftWebApiHost)]
    public interface IActionSoftNotificationWebApiService : IHttpApi
    {
        /// <summary>
        /// 检查系统消息功能是否可用
        /// </summary>
        /// <param name="webApiRequest"><see cref="BaseActionSoftWebApiRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<bool>> SystemMessageEnableCheck([FormContent] BaseActionSoftWebApiRequest webApiRequest);

        /// <summary>
        /// 给用户发送一条系统消息(要正常使用该API，需要当前AWS PaaS安装了"通知中心"应用)
        /// </summary>
        /// <param name="systemMessageSendWebApiRequest"></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<bool>> SendSystemMessage([FormContent] ActionSoftSystemMessageSendWebApiRequest systemMessageSendWebApiRequest);
    }
}
