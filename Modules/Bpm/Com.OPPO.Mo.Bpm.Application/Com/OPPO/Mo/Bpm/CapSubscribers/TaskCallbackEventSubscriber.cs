using Com.OPPO.Mo.Bpm.Etos;
using Com.OPPO.Mo.Thirdparty.Paas;
using Com.OPPO.Mo.Thirdparty.Paas.Requests;
using DotNetCore.CAP;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Com.OPPO.Mo.Bpm.CapSubscribers
{
    /// <summary>
    /// 任务回调事件订阅者
    /// </summary>
    public class TaskCallbackEventSubscriber : ICapSubscribe, ITransientDependency
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<TaskCallbackEventSubscriber> _logger;
        private readonly IBpmCallbackWebApiService _bpmCallbackWebApiService;
        private readonly IPaasAuthenticationWebApiService _paasAuthenticationWebApiService;

        /// <summary>
        /// <see cref="TaskCallbackEventSubscriber"/>
        /// </summary>
        public TaskCallbackEventSubscriber(
             IConfiguration configuration,
            ILogger<TaskCallbackEventSubscriber> logger,
            IBpmCallbackWebApiService bpmCallbackWebApiService,
            IPaasAuthenticationWebApiService paasAuthenticationWebApiService)
        {
            _logger = logger;
            _configuration = configuration;
            _bpmCallbackWebApiService = bpmCallbackWebApiService;
            _paasAuthenticationWebApiService = paasAuthenticationWebApiService;
        }

        [CapSubscribe(MoBpmConsts.TaskCallbackEventTopic, Group = "bpm.servcie.task.callback.test")]
        public async Task Subscribe(TaskCallbackEto taskCallbackEto)
        {
            if (taskCallbackEto.IsNeedPaasToken)
            {
                var paasAccessTokenGetResult = await GetPaasAccessToken();
                if (!paasAccessTokenGetResult.IsSuccess)
                    _logger.LogError(paasAccessTokenGetResult.Msg);
                else
                {
                    taskCallbackEto.Headers.Add(PaasSettingNames.PaasAuthAppHeaderName, _configuration[PaasSettingNames.PaasAppId]);
                    taskCallbackEto.Headers.Add(PaasSettingNames.PaasAuthTokenHeaderName, paasAccessTokenGetResult.Data);
                }
            }

            var callbackResponse = await _bpmCallbackWebApiService.Callback(taskCallbackEto.CallbackUrl, taskCallbackEto.Headers, taskCallbackEto.Params);
            if (taskCallbackEto.SuccessAssertions != null && taskCallbackEto.SuccessAssertions.Any())
            {
                var matchString = callbackResponse.Replace(" ", "");
                var mathcResults = taskCallbackEto.SuccessAssertions.Select(x => Regex.Match(matchString, x, RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture));
                if (mathcResults.Any(y => !y.Success))
                    throw new Exception($"{taskCallbackEto.TaskEventMessageId}\r\n{callbackResponse}");
            }

            Trace.WriteLine($"已完成对任务事件消息【{taskCallbackEto.TaskEventMessageId}】=>【{taskCallbackEto.CallbackUrl}】的回调");
            _logger.LogInformation($"已完成对任务事件消息【{taskCallbackEto.TaskEventMessageId}】=>【{taskCallbackEto.CallbackUrl}】的回调");
        }

        private async Task<Result<string>> GetPaasAccessToken()
        {
            var paasAppLoginRequest = new PaasAppLoginRequest
            {
                AppTag = _configuration[PaasSettingNames.PaasAppTag],
                AppEncrptedSecret = _configuration[PaasSettingNames.PaasAppSecret]
            };
            var loginResponse = await _paasAuthenticationWebApiService.AppLogin(paasAppLoginRequest, _configuration[PaasSettingNames.PaasTenantId]);
            if (loginResponse.IsOk)
                return Result.FromData(loginResponse.Payload.AccessToken);
            else
            {
                return Result.FromError<string>(loginResponse.Message);
            }
        }
    }
}
