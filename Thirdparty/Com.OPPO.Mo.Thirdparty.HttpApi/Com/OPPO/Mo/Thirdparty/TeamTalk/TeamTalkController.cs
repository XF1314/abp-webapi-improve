using Com.OPPO.Mo.Thirdparty.TeamTalk.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Thirdparty.TeamTalk
{

    /// <summary>
    /// TeamTalk
    /// </summary>
    [Area("teamTalk")]
    [Route("api/mo/thirdparty/tt")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class TeamTalkController : AbpController, ITeamTalkAppService
    {
        private readonly ITeamTalkAppService _teamTalkAppService;

        /// <summary>
        /// <see cref="TeamTalkController"/>
        /// </summary>>
        public TeamTalkController(ITeamTalkAppService teamTalkAppService)
        {
            _teamTalkAppService = teamTalkAppService;
        }

        /// <summary>
        /// 发送消息通知 【第三方接口：/oppo/tt/notification_send】
        /// </summary>
        /// <param name="notificationSendInput"><see cref="TeamTalkNotificationSendInput"/></param>
        /// <returns></returns>
        [HttpPost("notification-send")]
        public async Task<Result> SendNotification(TeamTalkNotificationSendInput notificationSendInput)
        {
            return await _teamTalkAppService.SendNotification(notificationSendInput);
        }

    }
}
