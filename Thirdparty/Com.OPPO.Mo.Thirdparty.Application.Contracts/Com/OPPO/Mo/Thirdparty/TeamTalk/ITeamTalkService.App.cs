using Com.OPPO.Mo.Thirdparty.TeamTalk.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.TeamTalk
{

    /// <summary>
    /// TeamTalk应用服务接口
    /// </summary>
    public interface ITeamTalkAppService : IApplicationService
    {
        /// <summary>
        /// 
        /// 发送消息通知 【第三方接口：/oppo/tt/notification_send】
        /// </summary>
        /// <param name="teamTalkMessageSendInput"><see cref="TeamTalkNotificationSendInput"/></param>
        /// <returns></returns>
        Task<Result> SendNotification(TeamTalkNotificationSendInput teamTalkMessageSendInput);

    }
}
