using Com.OPPO.Mo.Thirdparty.TeamTalk.Requests;
using Com.OPPO.Mo.Thirdparty.TeamTalk.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.TeamTalk
{
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [ConfigurableHttpHost(ThirdpartySettingNames.EsbHost)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    public interface ITeamTalkEsbService : IHttpApi
    {
        /// <summary>
        /// TeamTalk消息推送接口 【第三方接口：/oppo/tt/notification_send】
        /// </summary>
        /// <param name="notificationSendRequest"><see cref="TeamTalkNotificationSendRequest"/></param>
        /// <returns></returns>
        [HttpPost("/oppo/tt/notification_send")]
        Task<TeamTalkNotificationSendResponse> SendNotification([FormContent] TeamTalkNotificationSendRequest notificationSendRequest);

    }
}
