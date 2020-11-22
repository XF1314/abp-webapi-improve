using Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects;
using Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Dtos;
using Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Nito.AsyncEx;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Volo.Abp.Auditing;

namespace Com.OPPO.Mo.Bpm.ActionSoft
{
    /// <summary>
    /// ActionSoft业务对象应用服务
    /// </summary>
    [Authorize]
    public class ActionSoftBusinessObjectAppService : BpmAppServiceBase, IActionSoftBusinessObjectAppService
    {
        private readonly IActionSoftBusinessObjectWebApiService _actionSoftBusinessObjectWebApiService;

        /// <summary>
        /// <see cref="ActionSoftBusinessObjectAppService"/>
        /// </summary>
        public ActionSoftBusinessObjectAppService(IActionSoftBusinessObjectWebApiService actionSoftBusinessObjectWebApiService)
        {
            _actionSoftBusinessObjectWebApiService = actionSoftBusinessObjectWebApiService;
        }

        /// <inheritdoc/>
        public async Task<Result<string>> CreateBusinessObject(ActionSoftBusinessObjectCreateInput actionSoftBusinessObjectCreateInput)
        {
            var ss = BusinessObjectTablePermissionRepository.GetQueryable();
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var businessObjectTablePermission = await BusinessObjectTablePermissionRepository.GetBusinessObjectTablePermission(appId: clientId, actionSoftBusinessObjectCreateInput.BusinessObjectTableName);
            if (businessObjectTablePermission is null || !businessObjectTablePermission.IsValid)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权向业务对象表【{actionSoftBusinessObjectCreateInput.BusinessObjectTableName}】新增数据");
                return Result.FromCode<string>(ResultCode.Forbidden, $"应用【{clientId}】无业务对象表【{actionSoftBusinessObjectCreateInput.BusinessObjectTableName}】权限");
            }
            else
            {
                var businessObjectCreateRequest = ObjectMapper.Map<ActionSoftBusinessObjectCreateInput, ActionSoftBusinessObjectCreateRequest>(actionSoftBusinessObjectCreateInput);
                var businessObjectCreateResponse = await _actionSoftBusinessObjectWebApiService.CreateBusinessObject(businessObjectCreateRequest);
                if (businessObjectCreateResponse.IsOk)
                {
                    await BusinessObjectBelongRepository.InsertAsync(new BusinessObjectBelong
                    {
                        BusinessObjectTableName = actionSoftBusinessObjectCreateInput.BusinessObjectTableName,
                        ProcessInstanceId = actionSoftBusinessObjectCreateInput.ProcessInstanceId,
                        BusinessObjectId = businessObjectCreateResponse.Data,
                        AppId = clientId
                    });

                    return Result.FromData(businessObjectCreateResponse.Data);
                }
                else
                {
                    var errorMessage = $"【{businessObjectCreateResponse.ErrorCode}】{businessObjectCreateResponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError<string>(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<List<string>>> BatchCreateBusinessObject(ActionSoftBusinessObjectBatchCreateInput actionSoftBusinessObjectBatchCreateInput)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var businessObjectTablePermission = await BusinessObjectTablePermissionRepository.GetBusinessObjectTablePermission(appId: clientId, actionSoftBusinessObjectBatchCreateInput.BusinessObjectTableName);
            if (businessObjectTablePermission is null || !businessObjectTablePermission.IsValid)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权向业务对象表【{actionSoftBusinessObjectBatchCreateInput.BusinessObjectTableName}】批量新增数据");
                return Result.FromCode<List<string>>(ResultCode.Forbidden, $"应用【{clientId}】无业务对象表【{actionSoftBusinessObjectBatchCreateInput.BusinessObjectTableName}】权限");
            }
            else
            {
                var businessObjectBatchCreateRequest = ObjectMapper.Map<ActionSoftBusinessObjectBatchCreateInput, ActionSoftBusinessObjectBatchCreateRequest>(actionSoftBusinessObjectBatchCreateInput);
                var businessObjectBatchCreateResponse = await _actionSoftBusinessObjectWebApiService.BatchCreateBusinessObject(businessObjectBatchCreateRequest);
                if (businessObjectBatchCreateResponse.IsOk)
                {
                    var businessObjectBelongCreateTasks = businessObjectBatchCreateResponse.Data.Select(x => BusinessObjectBelongRepository.InsertAsync(new BusinessObjectBelong
                    {
                        BusinessObjectTableName = actionSoftBusinessObjectBatchCreateInput.BusinessObjectTableName,
                        ProcessInstanceId = actionSoftBusinessObjectBatchCreateInput.ProcessInstanceId,
                        BusinessObjectId = x,
                        AppId = clientId

                    }));
                    await businessObjectBelongCreateTasks.WhenAll();

                    return Result.FromData(businessObjectBatchCreateResponse.Data);
                }
                else
                {
                    var errorMessage = $"【{businessObjectBatchCreateResponse.ErrorCode}】{businessObjectBatchCreateResponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError<List<string>>(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<string>> GetBusinessObjectById(ActionSoftBusinessObjectGetInput actionSoftBusinessObjectGetInput)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var businessObjectBelong = BusinessObjectBelongRepository
                .GetBusinessObjectBelongByBusinessObjectId(appId: clientId, actionSoftBusinessObjectGetInput.BusinessObjectId);
            if (businessObjectBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权获取业务对象【{actionSoftBusinessObjectGetInput.BusinessObjectId}】信息");
                return Result.FromCode<string>(ResultCode.Forbidden, $"应用【{clientId}】无业务对象【{actionSoftBusinessObjectGetInput.BusinessObjectId}】权限");
            }
            else
            {
                var businessObjectGetRequest = ObjectMapper.Map<ActionSoftBusinessObjectGetInput, ActionSoftBusinessObjectGetRequest>(actionSoftBusinessObjectGetInput);
                var businessObjectGetResponse = await _actionSoftBusinessObjectWebApiService.GetBusinessObject(businessObjectGetRequest);
                if (businessObjectGetResponse.IsOk)
                    return Result.FromData(businessObjectGetResponse.Data);
                else
                {
                    var errorMessage = $"【{businessObjectGetResponse.ErrorCode}】{businessObjectGetResponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError<string>(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<string>> GetBusinessObjectField(ActionSoftBusinessObjectFieldGetInput actionSoftBusinessObjectFieldGetInput)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var businessObjectBelong = BusinessObjectBelongRepository
                .GetBusinessObjectBelongByBusinessObjectId(appId: clientId, actionSoftBusinessObjectFieldGetInput.BusinessObjectId);
            if (businessObjectBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权获取业务对象【{actionSoftBusinessObjectFieldGetInput.BusinessObjectId}】信息");
                return Result.FromCode<string>(ResultCode.Forbidden, $"应用【{clientId}】无业务对象【{actionSoftBusinessObjectFieldGetInput.BusinessObjectId}】权限");
            }
            else
            {
                var businessObjectFieldGetRequest = ObjectMapper.Map<ActionSoftBusinessObjectFieldGetInput, ActionSoftBusinessObjectFieldGetRequest>(actionSoftBusinessObjectFieldGetInput);
                var businessObjectFieldGetResponse = await _actionSoftBusinessObjectWebApiService.GetBusinessObjectField(businessObjectFieldGetRequest);
                if (businessObjectFieldGetResponse.IsOk)
                    return Result.FromData(businessObjectFieldGetResponse.Data);
                else
                {
                    var errorMessage = $"【{businessObjectFieldGetResponse.ErrorCode}】{businessObjectFieldGetResponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError<string>(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<int>> BatchUpdateBusinessObjectField(ActionSoftBusinessObjectFieldBatchUpdateInput actionSoftBusinessObjectFieldBatchUpdateInput)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var businessObjectBelong = BusinessObjectBelongRepository
                .GetBusinessObjectBelongByBusinessObjectId(appId: clientId, actionSoftBusinessObjectFieldBatchUpdateInput.BusinessObjectId);
            if (businessObjectBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权更新业务对象【{actionSoftBusinessObjectFieldBatchUpdateInput.BusinessObjectId}】信息");
                return Result.FromCode<int>(ResultCode.Forbidden, $"应用【{clientId}】无业务对象【{actionSoftBusinessObjectFieldBatchUpdateInput.BusinessObjectId}】权限");
            }
            else
            {
                var bussinessObjectFieldBatchUpdateRequest = ObjectMapper
                    .Map<ActionSoftBusinessObjectFieldBatchUpdateInput, ActionSoftBusinessObjectFieldBatchUpdateRequest>(actionSoftBusinessObjectFieldBatchUpdateInput);
                var bussinessObjectFieldBatchUpdateResponse = await _actionSoftBusinessObjectWebApiService.BatchUpdateBusinessObjectField(bussinessObjectFieldBatchUpdateRequest);
                if (bussinessObjectFieldBatchUpdateResponse.IsOk)
                    return Result.FromData(bussinessObjectFieldBatchUpdateResponse.Data);
                else
                {
                    var errorMessage = $"【{bussinessObjectFieldBatchUpdateResponse.ErrorCode}】{bussinessObjectFieldBatchUpdateResponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError<int>(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<int>> UpdateBusinessObjectFieldByProcess(ActionSoftBusinessObjectFieldUpdateByProcessInput actionSoftBusinessObjectFieldUpdateByProcessInput)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var businessObjectBelong = BusinessObjectBelongRepository
                .GetBusinessObjectBelongByProcessInstanceId(appId: clientId, actionSoftBusinessObjectFieldUpdateByProcessInput.BusinessObjectTableName, actionSoftBusinessObjectFieldUpdateByProcessInput.ProcessInstanceId);
            if (businessObjectBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权更新流程实例【{actionSoftBusinessObjectFieldUpdateByProcessInput.ProcessInstanceId}】对应的业务对象信息");
                return Result.FromCode<int>(ResultCode.Forbidden, $"应用【{clientId}】无流程实例【{actionSoftBusinessObjectFieldUpdateByProcessInput.ProcessInstanceId}】对应的业务对象权限");
            }
            else
            {
                var businessObjectFieldUpdateByProcessInstanceRequest = ObjectMapper
                    .Map<ActionSoftBusinessObjectFieldUpdateByProcessInput, ActionSoftBusinessObjectFieldUpdateByProcessRequest>(actionSoftBusinessObjectFieldUpdateByProcessInput);
                var businessObjectFieldUpdateByProcessInstanceResponse = await _actionSoftBusinessObjectWebApiService.UpdateBusinessObjectFieldByProcess(businessObjectFieldUpdateByProcessInstanceRequest);
                if (businessObjectFieldUpdateByProcessInstanceResponse.IsOk)
                    return Result.FromData(businessObjectFieldUpdateByProcessInstanceResponse.Data);
                else
                {
                    var errorMessage = $"【{businessObjectFieldUpdateByProcessInstanceResponse.ErrorCode}】{businessObjectFieldUpdateByProcessInstanceResponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError<int>(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<int>> DeleteBusinessObjectByProcess(ActionSoftBusinessObjectDeleteByProcessInput actionSoftBusinessObjectDeleteByProcessInput)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var businessObjectBelong = BusinessObjectBelongRepository
                .GetBusinessObjectBelongByProcessInstanceId(appId: clientId, actionSoftBusinessObjectDeleteByProcessInput.BusinessObjectTableName, actionSoftBusinessObjectDeleteByProcessInput.ProcessInstanceId);
            if (businessObjectBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权获取流程实例【{actionSoftBusinessObjectDeleteByProcessInput.ProcessInstanceId}】对应的业务对象信息");
                return Result.FromCode<int>(ResultCode.Forbidden, $"应用【{clientId}】无流程实例【{actionSoftBusinessObjectDeleteByProcessInput.ProcessInstanceId}】对应的业务对象权限");
            }
            else
            {
                var actionSoftBusinessObjectDeleteByProcessInstanceRequest = ObjectMapper
                    .Map<ActionSoftBusinessObjectDeleteByProcessInput, ActionSoftBusinessObjectDeleteByProcessRequest>(actionSoftBusinessObjectDeleteByProcessInput);
                var actionSoftBusinessObjectDeleteByProcessInstanceResponse = await _actionSoftBusinessObjectWebApiService.BatchDeleteBusinessObjectByProcess(actionSoftBusinessObjectDeleteByProcessInstanceRequest);
                if (actionSoftBusinessObjectDeleteByProcessInstanceResponse.IsOk)
                    return Result.FromData(actionSoftBusinessObjectDeleteByProcessInstanceResponse.Data);
                else
                {
                    var errorMessage = $"【{actionSoftBusinessObjectDeleteByProcessInstanceResponse.ErrorCode}】{actionSoftBusinessObjectDeleteByProcessInstanceResponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError<int>(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<List<Dictionary<string, string>>>> QueryBusinessObject(ActionSoftBusinessObjectQueryInput actionSoftBusinessObjectQueryInput)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var businessObjectTablePermission = await BusinessObjectTablePermissionRepository.GetBusinessObjectTablePermission(appId: clientId, actionSoftBusinessObjectQueryInput.BusinessObjectTableName);
            if (businessObjectTablePermission is null || !businessObjectTablePermission.IsValid)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权查询业务对象表【{actionSoftBusinessObjectQueryInput.BusinessObjectTableName}】");
                return Result.FromCode<List<Dictionary<string, string>>>(ResultCode.Forbidden, $"应用【{clientId}】无业务对象表【{actionSoftBusinessObjectQueryInput.BusinessObjectTableName}】权限");
            }
            else
            {
                var actionSoftBusinessObjectQueryRequest = ObjectMapper.Map<ActionSoftBusinessObjectQueryInput, ActionSoftBusinessObjectQueryRequest>(actionSoftBusinessObjectQueryInput);
                var actionSoftBusinessObjectQueryResponse = await _actionSoftBusinessObjectWebApiService.QueryBusinessObject(actionSoftBusinessObjectQueryRequest);
                if (actionSoftBusinessObjectQueryResponse.IsOk)
                    return Result.FromData(actionSoftBusinessObjectQueryResponse.Data);
                else
                {
                    var errorMessage = $"【{actionSoftBusinessObjectQueryResponse.ErrorCode}】{actionSoftBusinessObjectQueryResponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError<List<Dictionary<string, string>>>(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        [DisableAuditing]
        public async Task<Result<string>> UploadBusinessObjectAttachment(ActionSoftBusinessObjectAttachmentInfoInput businessObjectAttachmentInfoInput, byte[] attachmentContent)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var businessObjectBelong = await BusinessObjectBelongRepository
                .GetBusinessObjectBelongByBusinessObjectId(clientId, businessObjectAttachmentInfoInput.BusinessObjectId);
            if (businessObjectBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权为业务对象【{businessObjectAttachmentInfoInput.BusinessObjectId}】上传附件");
                return Result.FromCode<string>(ResultCode.Forbidden, $"应用【{clientId}】无业务对象【{businessObjectAttachmentInfoInput.BusinessObjectId}】附件上传权限");
            }
            else
            {
                var businessObjectAttachmentInfo = ObjectMapper.Map<ActionSoftBusinessObjectAttachmentInfoInput, ActionSoftBusinessObjectAttachmentInfo>(businessObjectAttachmentInfoInput);
                var businessObjectAttachmentData = new ActionSoftBusinessObjectAttachmentData { AttachmentContent = attachmentContent, AttachmentName = businessObjectAttachmentInfoInput.AttachmentName };
                var businessObjectAttachmentUploadRequest = new ActionSoftBusinessObjectAttachmentUploadRequest
                {
                    AttachmentInfo = businessObjectAttachmentInfo,
                    AttachmentData = businessObjectAttachmentData
                };
                var businessObjdectAttachmentUploadResponse = await _actionSoftBusinessObjectWebApiService.UploadBusinessObjectAttachment(businessObjectAttachmentUploadRequest);
                if (businessObjdectAttachmentUploadResponse.IsOk)
                    return Result.FromData(businessObjdectAttachmentUploadResponse.Data);
                else
                {
                    var errorMessage = $"【{businessObjdectAttachmentUploadResponse.ErrorCode}】{businessObjdectAttachmentUploadResponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError<string>(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<List<ActionSoftBusinessObjectAttachmentInfoDto>>> GetBusinessObjectAttachmentInfos(ActionSoftBusinessObjectAttachmentInfosGetInput actionSoftBusinessObjectAttachmentInfosGetInput)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var businessObjectBelong = await BusinessObjectBelongRepository
                .GetBusinessObjectBelongByBusinessObjectId(clientId, actionSoftBusinessObjectAttachmentInfosGetInput.BusinessObjectId);
            if (businessObjectBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权获取业务对象【{actionSoftBusinessObjectAttachmentInfosGetInput.BusinessObjectId}】附件信息");
                return Result.FromCode<List<ActionSoftBusinessObjectAttachmentInfoDto>>(ResultCode.Forbidden, $"应用【{clientId}】无业务对象【{actionSoftBusinessObjectAttachmentInfosGetInput.BusinessObjectId}】附件信息获取权限");
            }
            else
            {
                var businessObjectAttachmentInfosGetRequest = ObjectMapper.Map<ActionSoftBusinessObjectAttachmentInfosGetInput, ActionSoftBusinessObjectAttachmentInfosGetRequest>(actionSoftBusinessObjectAttachmentInfosGetInput);
                var businessObjectAttachmentInfosGetResponse = await _actionSoftBusinessObjectWebApiService.GetBusinessObjectAttachmentInfos(businessObjectAttachmentInfosGetRequest);
                if (businessObjectAttachmentInfosGetResponse.IsOk)
                {
                    var businessObjectAttachmentInfos = ObjectMapper.Map<List<ActionSoftBusinessObjectAttachmentInfo>, List<ActionSoftBusinessObjectAttachmentInfoDto>>(businessObjectAttachmentInfosGetResponse.Data);
                    return Result.FromData(businessObjectAttachmentInfos);
                }
                else
                {
                    var errorMessage = $"【{businessObjectAttachmentInfosGetResponse.ErrorCode}】{businessObjectAttachmentInfosGetResponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError<List<ActionSoftBusinessObjectAttachmentInfoDto>>(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result<ActionSoftBusinessObjectAttachmentDataDto>> DownloadBusinessObjectAttachment(ActionSoftBusinessObjectAttachmentDownloadInput actionSoftBusinessObjectAttachmentDownloadInput)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var businessObjectBelong = await BusinessObjectBelongRepository
                .GetBusinessObjectBelongByBusinessObjectId(clientId, actionSoftBusinessObjectAttachmentDownloadInput.BusinessObjectId);
            if (businessObjectBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权下载业务对象【{actionSoftBusinessObjectAttachmentDownloadInput.BusinessObjectId}】附件");
                return Result.FromCode<ActionSoftBusinessObjectAttachmentDataDto>(ResultCode.Forbidden, $"应用【{clientId}】无业务对象【{actionSoftBusinessObjectAttachmentDownloadInput.BusinessObjectId}】附件下载权限");
            }
            else
            {
                var businessObjectAttachmentDataDownloadRequest = new ActionSoftBusinessObjectAttachmentDownloadRequest { AttachmentId = actionSoftBusinessObjectAttachmentDownloadInput.AttachmentId };
                var businessObjectAttachmentDataDownloadResponse = await _actionSoftBusinessObjectWebApiService.DownloadBusinessObjectAttachment(businessObjectAttachmentDataDownloadRequest);
                if (businessObjectAttachmentDataDownloadResponse.IsOk)
                {
                    var businessObjectAttachmentDataDto = ObjectMapper.Map<ActionSoftBusinessObjectAttachmentData, ActionSoftBusinessObjectAttachmentDataDto>(businessObjectAttachmentDataDownloadResponse.Data);
                    return Result.FromData(businessObjectAttachmentDataDto);
                }
                else
                {
                    var errorMessage = $"【{businessObjectAttachmentDataDownloadResponse.ErrorCode}】{businessObjectAttachmentDataDownloadResponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError<ActionSoftBusinessObjectAttachmentDataDto>(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result> RemoveBusinessObjectAttachment(ActionSoftBusinessObjectAttachmentsRemoveInput actionSoftBusinessObjectAttachmentDeleteInput)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var businessObjectBelong = await BusinessObjectBelongRepository
                .GetBusinessObjectBelongByBusinessObjectId(clientId, actionSoftBusinessObjectAttachmentDeleteInput.BusinessObjectId);
            if (businessObjectBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权移除业务对象【{actionSoftBusinessObjectAttachmentDeleteInput.BusinessObjectId}】附件");
                return Result.FromCode<ActionSoftBusinessObjectAttachmentDataDto>(ResultCode.Forbidden, $"应用【{clientId}】无业务对象【{actionSoftBusinessObjectAttachmentDeleteInput.BusinessObjectId}】附件移除权限");
            }
            else
            {
                var businessObjectAttachmentDeleteRequest = new ActionSoftBusinessObjectAttachmentRemoveRequest { AttachmentId = actionSoftBusinessObjectAttachmentDeleteInput.AttachmentId };
                var businessObjectAttachmentDeleteResponse = await _actionSoftBusinessObjectWebApiService.DeleteBusinessObjectAttachment(businessObjectAttachmentDeleteRequest);
                if (businessObjectAttachmentDeleteResponse.IsOk)
                    return Result.Ok();
                else
                {
                    var errorMessage = $"【{businessObjectAttachmentDeleteResponse.ErrorCode}】{businessObjectAttachmentDeleteResponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError(errorMessage);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result> RemoveBusinessObjectAttachments(ActionSoftBusinessObjectAttachmentRemoveInput actionSoftBusinessObjectAttachmentBatchDeleteInput)
        {
            var clientId = CurrentPrincipalAccessor.Principal.Identity.FindClientId();
            var businessObjectBelong = await BusinessObjectBelongRepository
                .GetBusinessObjectBelongByBusinessObjectId(clientId, actionSoftBusinessObjectAttachmentBatchDeleteInput.BusinessObjectId);
            if (businessObjectBelong is null)
            {
                Logger.LogWarning($"应用【{clientId}】尝试越权移除业务对象【{actionSoftBusinessObjectAttachmentBatchDeleteInput.BusinessObjectId}】附件");
                return Result.FromCode<ActionSoftBusinessObjectAttachmentDataDto>(ResultCode.Forbidden, $"应用【{clientId}】无业务对象【{actionSoftBusinessObjectAttachmentBatchDeleteInput.BusinessObjectId}】附件移除权限");
            }
            else
            {
                var businessObjectAttachmentBatchDeleteRequest = ObjectMapper
                    .Map<ActionSoftBusinessObjectAttachmentRemoveInput, ActionSoftBusinessObjectAttachmentsRemoveRequest>(actionSoftBusinessObjectAttachmentBatchDeleteInput);
                var businessObjectAttachmentBatchDeleteResponse = await _actionSoftBusinessObjectWebApiService.BatchDeleteBusinessObjectAttachment(businessObjectAttachmentBatchDeleteRequest);
                if (businessObjectAttachmentBatchDeleteResponse.IsOk)
                    return Result.Ok();
                else
                {
                    var errorMessage = $"【{businessObjectAttachmentBatchDeleteResponse.ErrorCode}】{businessObjectAttachmentBatchDeleteResponse.Message}";
                    Logger.LogError(errorMessage);
                    return Result.FromError(errorMessage);
                }
            }
        }
    }
}
