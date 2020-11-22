using Com.OPPO.Mo.Bpm.ActionSoft.Extensions;
using Com.OPPO.Mo.Bpm.ActionSoft.Extensions.Requests;
using Com.OPPO.Mo.Bpm.ActionSoft.Metadatas;
using Com.OPPO.Mo.Bpm.ActionSoft.Metadatas.Dtos;
using Com.OPPO.Mo.Bpm.ActionSoft.Metadatas.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Bpm.ActionSoft
{
    /// <summary>
    /// ActionSoft元数据应用服务
    /// </summary>
    [Authorize]
    public class ActionSoftMetadataAppService : BpmAppServiceBase, IActionSoftMetadataAppService
    {
        private readonly IActionSoftMetadataWebApiService _actionSoftMetadataWebApiService;

        /// <summary>
        /// <see cref="ActionSoftMetadataAppService"/>
        /// </summary>
        public ActionSoftMetadataAppService(IActionSoftMetadataWebApiService actionSoftMetadataWebApiService)
        {
            _actionSoftMetadataWebApiService = actionSoftMetadataWebApiService;
        }

        /// <inheritdoc/>
        public async Task<Result<string>> GetUserTaskDefinition(ActionSoftUserTaskDefinitionGetInput userTaskDefinitionGetInput)
        {
            var userTaskDefintionGetRequest = ObjectMapper
                .Map<ActionSoftUserTaskDefinitionGetInput, ActionSoftUserTaskDefinitionGetRequest>(userTaskDefinitionGetInput);
            var userTaskDefinitionGetResponse = await _actionSoftMetadataWebApiService.GetUserTaskDefinition(userTaskDefintionGetRequest);
            if (userTaskDefinitionGetResponse.IsOk)
                return Result.FromData(userTaskDefinitionGetResponse.Data);
            else
            {
                var errorMessage = $"【{userTaskDefinitionGetResponse.ErrorCode}】{userTaskDefinitionGetResponse.Message}";
                Logger.LogError(errorMessage);
                return Result.FromError<string>(errorMessage);
            }
        }

        /// <inheritdoc/>
        public async Task<Result<string>> GetProcessDefinition(string processDefinitionId)
        {
            var processDefintionGetRequest = new ActionSoftProcessDefinitionGetRequest { ProcessDefinitionId = processDefinitionId };
            var processDefintionGetResponse = await _actionSoftMetadataWebApiService.GetProcessDefinition(processDefintionGetRequest);
            if (processDefintionGetResponse.IsOk)
                return Result.FromData(processDefintionGetResponse.Data);
            else
            {
                var errorMessage = $"【{processDefintionGetResponse.ErrorCode}】{processDefintionGetResponse.Message}";
                Logger.LogError(errorMessage);
                return Result.FromError<string>(errorMessage);
            }
        }

        /// <inheritdoc/>
        public async Task<Result<string>> GetProcessDocument(string processDefinitionId)
        {
            var processDocumentGetRequset = new ActionSoftProcessDocumentGetRequest { ProcessDefinitionId = processDefinitionId };
            var processDocumentGetResponse = await _actionSoftMetadataWebApiService.GetProcessDocument(processDocumentGetRequset);
            if (processDocumentGetResponse.IsOk)
                return Result.FromData(processDocumentGetResponse.Data);
            else
            {
                var errorMessage = $"【{processDocumentGetResponse.ErrorCode}】{processDocumentGetResponse.Message}";
                Logger.LogError(errorMessage);
                return Result.FromError<string>(errorMessage);
            }
        }

        /// <inheritdoc/>
        public async Task<Result<string>> GetProcessMainVersionId(string processDefinitionId)
        {
            var processMainVersionIdGetRequest = new ActionSoftProcessMainVersionIdGetRequest { ProcessDefinitionId = processDefinitionId };
            var processMainVersionIdGetResponse = await _actionSoftMetadataWebApiService.GetProcessMainVersionId(processMainVersionIdGetRequest);
            if (processMainVersionIdGetResponse.IsOk)
                return Result.FromData(processMainVersionIdGetResponse.Data);
            else
            {
                var errorMessage = $"【{processMainVersionIdGetResponse.ErrorCode}】{processMainVersionIdGetResponse.Message}";
                Logger.LogError(errorMessage);
                return Result.FromError<string>(errorMessage);
            }
        }

        /// <inheritdoc/>
        public async Task<Result<string>> GetProcessDefinitionId(string processDefinitionVersionId)
        {
            var processDefinitionIdGetRequest = new ActionSoftProcessDefinitionIdGetRequest { ProcessDefinitionVersionId = processDefinitionVersionId };
            var processDefinitionIdGetResponse = await _actionSoftMetadataWebApiService.GetProcessDefinitionId(processDefinitionIdGetRequest);
            if (processDefinitionIdGetResponse.IsOk)
                return Result.FromData(processDefinitionIdGetResponse.Data);
            else
            {
                var errorMessage = $"【{processDefinitionIdGetResponse.ErrorCode}】{processDefinitionIdGetResponse.Message}";
                Logger.LogError(errorMessage);
                return Result.FromError<string>(errorMessage);
            }
        }

        /// <inheritdoc/>
        public async Task<Result<string>> GetProcessTrackingUrl(string processInstanceId)
        {
            var actionSoftExtensionWebApiService = ServiceProvider.GetRequiredService<IActionSoftExtensionWebApiService>();
            var sessionIdGetRequest = new ActionSoftSessionIdGetRequest
            {
                UserCode = MoBpmConsts.ActionSoftAdminUserCode,
                Ip = "127.0.0.1"
            };
            var sessionIdGetResponse = await actionSoftExtensionWebApiService.GetAccessToken(sessionIdGetRequest);
            if (!sessionIdGetResponse.IsOk)
            {
                var message = $"用户【{MoBpmConsts.ActionSoftAdminUserCode}】SessionId获取失败，【{sessionIdGetResponse.ErrorCode}】{sessionIdGetResponse.Message}";
                Logger.LogWarning(message);
                return Result.FromCode<string>(ResultCode.Fail, message);
            }
            else
            {
                var processTrackingUrlGetRequest = new ActionSoftProcessTrackingUrlGetRequest { SessionId = sessionIdGetResponse.Data, ProcessInstanceId = processInstanceId };
                var processTrackingUrlGetResponse = await _actionSoftMetadataWebApiService.GetProcessTrackingUrl(processTrackingUrlGetRequest);
                if (processTrackingUrlGetResponse.IsOk)
                    return Result.FromData(processTrackingUrlGetResponse.Data);
                else
                {
                    var errorMessage = $"【{processTrackingUrlGetResponse.ErrorCode}】{processTrackingUrlGetResponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError<string>(errorMessage);
                }
            }
        }
    }
}
