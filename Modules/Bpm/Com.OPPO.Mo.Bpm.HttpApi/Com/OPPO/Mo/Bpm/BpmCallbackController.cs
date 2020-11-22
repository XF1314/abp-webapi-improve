using Com.OPPO.Mo.Bpm.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Bpm
{
    /// <summary>
    /// Bpm回调
    /// </summary>
    [Area("bpm")]
    [Route("api/mo/bpm/callback")]
    public class BpmCallbackController : AbpController
    {
        private readonly IBpmCallbackAppService _bpmCallbackAppService;

        /// <summary>
        /// <see cref="BpmCallbackController"/>
        /// </summary>
        public BpmCallbackController(IBpmCallbackAppService bpmCallbackAppService)
        {
            _bpmCallbackAppService = bpmCallbackAppService;
        }

        /// <summary>
        /// 回调测试【Client端】
        /// </summary>
        /// <param name="params">参数s</param>
        /// <returns></returns>
        [HttpPost("client-receive")]
        public Result Test([FromBody] Dictionary<string, string> @params)
        {
            Logger.LogError(JsonConvert.SerializeObject(@params));
            return Result.Ok();
        }

        /// <summary>
        /// 触发任务事件回调【Server端】
        /// </summary>
        /// <param name="taskEventMessageId">任务事件消息Id</param>
        /// <returns></returns>
        [HttpPost("task/server-trigger")]
        public async Task<Result> TriggerTaskCallback(string taskEventMessageId)
        {
            return await _bpmCallbackAppService.TriggerTaskCallback(taskEventMessageId);
        }

        /// <summary>
        /// 触发流程事件回调【Server端】
        /// </summary>
        /// <param name="processEventMessageId">流程事件消息Id</param>
        /// <returns></returns>
        [HttpPost("process/server-trigger")]
        public async Task<Result> TriggerProcessCallback(string processEventMessageId)
        {
            return await _bpmCallbackAppService.TriggerProcessCallback(processEventMessageId);
        }

        /// <summary>
        /// 任务回调
        /// </summary>
        /// <param name="taskEventCallbackInput"><see cref="TaskEventCallbackInput"/></param>
        /// <returns></returns>
        [HttpPost("task")]
        public async Task<Result<string>> Callback([FromBody] TaskEventCallbackInput taskEventCallbackInput)
        {
            return await _bpmCallbackAppService.TaskCallback(taskEventCallbackInput);
        }

        /// <summary>
        /// 流程回调
        /// </summary>
        /// <param name="processEventCallbackInput"><see cref="ProcessEventCallbackInput"/></param>
        /// <returns></returns>
        [HttpPost("process")]
        public async Task<Result<string>> ProcessCallback([FromBody] ProcessEventCallbackInput processEventCallbackInput)
        {
            return await _bpmCallbackAppService.ProcessCallback(processEventCallbackInput);
        }
    }
}
