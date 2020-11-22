using Com.OPPO.Mo.Bpm.ActionSoft.Notifications.Dtos;
using Com.OPPO.Mo.Bpm.ActionSoft.Tasks.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Notifications
{
    /// <summary>
    /// ActionSoft消息通知应用服务接口
    /// </summary>
    public interface IActionSoftNotificationAppService : IApplicationService
    {
        /// <summary>
        /// 检查系统消息功能是否可用
        /// </summary>
        /// <returns></returns>
        Task<Result> SystemMessageEnableCheck();

        /// <summary>
        /// 给用户发送一条系统消息(要正常使用该API，需要当前AWS PaaS安装了"通知中心"应用)
        /// </summary>
        /// <param name="systemMessageSendInput"><see cref="ActionSoftSystemMessageSendInput"/></param>
        /// <returns></returns>
        Task<Result> SendSystemMessage(ActionSoftSystemMessageSendInput systemMessageSendInput);

        /// <summary>
        /// 创建消息传阅（出现在用户，Portal-流程中心-我的待阅列表）
        /// </summary>
        /// <param name="actionSoftCirculationCreateInput"><see cref="ActionSoftCirculationCreateInput"/></param>
        /// <returns></returns>
        Task<Result<List<ActionSoftTaskDto>>> CreateCirculation(ActionSoftCirculationCreateInput actionSoftCirculationCreateInput);
    }
}
