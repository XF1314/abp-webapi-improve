using Com.OPPO.Mo.Thirdparty.TeamTalk.Dtos;
using Com.OPPO.Mo.Thirdparty.TeamTalk.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.TeamTalk
{
    /// <summary>
    /// TeamTalk应用服务
    /// </summary>
    [Authorize]
    public class TeamTalkAppService : ThirdpartyAppServiceBase, ITeamTalkAppService
    {
        /// <inheritdoc/>
        public async Task<Result> SendNotification(TeamTalkNotificationSendInput notificationSendInput)
        {
            var teamTalkEsbService = ServiceProvider.GetRequiredService<ITeamTalkEsbService>();
            var notificationInfo = ObjectMapper.Map<TeamTalkNotificationSendInput, TeamTalkNotificationInfo>(notificationSendInput);
            var notificationSendResponse = await teamTalkEsbService.SendNotification(new TeamTalkNotificationSendRequest
            {
                NotificationInfo = notificationInfo

            });

            if (notificationSendResponse.Code == 0)
                return Result.Ok(notificationSendResponse.Message);
            else
            {
                var message = $"【{notificationSendResponse.Code}】{notificationSendResponse.Message}";
                Logger.LogWarning(message);

                return Result.FromError(message);
            }
        }

    }
}
