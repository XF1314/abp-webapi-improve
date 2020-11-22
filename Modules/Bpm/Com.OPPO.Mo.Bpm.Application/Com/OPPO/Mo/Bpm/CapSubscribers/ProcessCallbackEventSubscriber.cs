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
    /// 流程回调事件订阅者
    /// </summary>
    public class ProcessCallbackEventSubscriber : ICapSubscribe, ITransientDependency
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ProcessCallbackEventSubscriber> _logger;
        private readonly IBpmCallbackWebApiService _bpmCallbackWebApiService;
        private readonly IPaasAuthenticationWebApiService _paasAuthenticationWebApiService;

        /// <summary>
        /// <see cref="TaskCallbackEventSubscriber"/>
        /// </summary>
        public ProcessCallbackEventSubscriber(
            IConfiguration configuration,
            ILogger<ProcessCallbackEventSubscriber> logger,
            IBpmCallbackWebApiService bpmCallbackWebApiService,
            IPaasAuthenticationWebApiService paasAuthenticationWebApiService)
        {
            _logger = logger;
            _configuration = configuration;
            _bpmCallbackWebApiService = bpmCallbackWebApiService;
            _paasAuthenticationWebApiService = paasAuthenticationWebApiService;
        }

        [CapSubscribe(MoBpmConsts.ProcessCallbackEventTopic, Group = "bpm.service.process.callback")]
        public async Task Subscribe(ProcessCallbackEto processCallbackEto)
        {
            if (processCallbackEto.IsNeedPaasToken)
            {
                var paasAccessTokenGetResult = await GetPaasAccessToken();
                if (!paasAccessTokenGetResult.IsSuccess)
                    _logger.LogError(paasAccessTokenGetResult.Msg);
                else
                {
                    processCallbackEto.Headers.Add(PaasSettingNames.PaasAuthAppHeaderName, _configuration[PaasSettingNames.PaasAppId]);
                    processCallbackEto.Headers.Add(PaasSettingNames.PaasAuthTokenHeaderName, paasAccessTokenGetResult.Data);
                }
            }

            var callbackResponse = await _bpmCallbackWebApiService.Callback(processCallbackEto.CallbackUrl, processCallbackEto.Headers, processCallbackEto.Params);
            if (processCallbackEto.SuccessAssertions != null && processCallbackEto.SuccessAssertions.Any())
            {
                var matchString = callbackResponse.Replace(" ", "");
                var mathcResults = processCallbackEto.SuccessAssertions.Select(x => Regex.Match(matchString, x, RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture));
                if (mathcResults.Any(y => !y.Success))
                    throw new Exception($"{processCallbackEto.ProcessEventMessageId}\r\n{callbackResponse}");
            }

            Trace.WriteLine($"已完成对流程事件消息【{processCallbackEto.ProcessEventMessageId}】=>【{processCallbackEto.CallbackUrl}】的回调");
            _logger.LogInformation($"已完成对流程事件消息【{processCallbackEto.ProcessEventMessageId}】=>【{processCallbackEto.CallbackUrl}】的回调");
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
