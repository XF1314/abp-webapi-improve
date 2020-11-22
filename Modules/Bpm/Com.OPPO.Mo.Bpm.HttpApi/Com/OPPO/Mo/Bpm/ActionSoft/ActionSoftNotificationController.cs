using Com.OPPO.Mo.Bpm.ActionSoft.Notifications;
using Com.OPPO.Mo.Bpm.ActionSoft.Notifications.Dtos;
using Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Bpm
{
    /// <summary>
    /// ActionSoft系统通知
    /// </summary>
    [Area("actionsoft")]
    [Route("openapi/actionsoft")]
    [RemoteService(Name = BpmRemoteServiceConsts.RemoteServiceName)]
    public class ActionSoftNotificationController : AbpController, IActionSoftNotificationAppService
    {
        private readonly IActionSoftNotificationAppService _actionSoftNotificationAppService;

        /// <summary>
        /// <see cref="ActionSoftNotificationController"/>
        /// </summary>
        public ActionSoftNotificationController(IActionSoftNotificationAppService actionSoftNotificationAppService)
        {
            _actionSoftNotificationAppService = actionSoftNotificationAppService;
        }

        /// <summary>
        /// 检查系统消息是否可用
        /// </summary>
        /// <returns></returns>
        [HttpPost("system-message/enable-check")]
        public async Task<Result> SystemMessageEnableCheck()
        {
            return await _actionSoftNotificationAppService.SystemMessageEnableCheck();
        }

        /// <summary>
        /// 发送系统消息
        /// </summary>
        /// <param name="systemMessageSendInput"><see cref="ActionSoftSystemMessageSendInput"/></param>
        /// <returns></returns>
        [HttpPost("system-message/send")]
        public async Task<Result> SendSystemMessage([FromBody] ActionSoftSystemMessageSendInput systemMessageSendInput)
        {
            return await _actionSoftNotificationAppService.SendSystemMessage(systemMessageSendInput);
        }

        /// <summary>
        /// 创建消息传阅（出现在用户，Portal-流程中心-我的待阅列表）
        /// </summary>
        /// <param name="circulationCreateInput"><see cref="ActionSoftCirculationCreateInput"/></param>
        /// <returns></returns>
        [HttpPost("circulation/create")]
        public async Task<Result<List<ActionSoftTaskDto>>> CreateCirculation([FromBody]ActionSoftCirculationCreateInput circulationCreateInput)
        {
            return await _actionSoftNotificationAppService.CreateCirculation(circulationCreateInput);
        }
    }
}
