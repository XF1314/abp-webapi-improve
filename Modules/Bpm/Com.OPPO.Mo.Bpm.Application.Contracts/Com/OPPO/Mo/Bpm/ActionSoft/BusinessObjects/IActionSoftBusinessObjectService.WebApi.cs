using Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects
{
    /// <summary>
    /// ActionSoft业务对象WebApi服务接口
    /// </summary>
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(BpmSettingNames.ActiontSoftWebApiHost)]
    public interface IActionSoftBusinessObjectWebApiService : IHttpApi
    {
        /// <summary>
        /// 创建ActionSoft业务对象
        /// </summary>
        /// <param name="actionSoftBusinessObjectCreateRequest"><see cref="ActionSoftBusinessObjectCreateRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<string>> CreateBusinessObject([FormContent] ActionSoftBusinessObjectCreateRequest actionSoftBusinessObjectCreateRequest);

        /// <summary>
        /// 批量创建ActionSoft业务对象
        /// </summary>
        /// <param name="actionSoftBusinessObjectBatchCreateRequest"></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<List<string>>> BatchCreateBusinessObject([FormContent] ActionSoftBusinessObjectBatchCreateRequest actionSoftBusinessObjectBatchCreateRequest);

        /// <summary>
        /// 批量更新ActionSoft业务对象字段
        /// </summary>
        /// <param name="actionSoftBusinessObjectFieldBatchUpdateRequest"><see cref="ActionSoftBusinessObjectFieldBatchUpdateRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<int>> BatchUpdateBusinessObjectField([FormContent] ActionSoftBusinessObjectFieldBatchUpdateRequest actionSoftBusinessObjectFieldBatchUpdateRequest);

        /// <summary>
        /// 获取ActionSoft业务对象字段
        /// </summary>
        /// <param name="actionSoftBusinessObjectFieldGetRequest"><see cref="ActionSoftBusinessObjectFieldGetRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<string>> GetBusinessObjectField([FormContent] ActionSoftBusinessObjectFieldGetRequest actionSoftBusinessObjectFieldGetRequest);

        /// <summary>
        /// 按流程更新ActionSoft业务对象字段
        /// </summary>
        /// <param name="actionSoftBusinessObjectFieldUpdateByProcessRequest"><see cref="ActionSoftBusinessObjectFieldUpdateByProcessRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<int>> UpdateBusinessObjectFieldByProcess([FormContent] ActionSoftBusinessObjectFieldUpdateByProcessRequest actionSoftBusinessObjectFieldUpdateByProcessRequest);

        /// <summary>
        /// 按流程批量删除相关联的ActionSoft业务对象
        /// </summary>
        /// <param name="actionSoftBusinessObjectDeleteByProcessRequest"><see cref="ActionSoftBusinessObjectDeleteByProcessRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<int>> BatchDeleteBusinessObjectByProcess([FormContent] ActionSoftBusinessObjectDeleteByProcessRequest actionSoftBusinessObjectDeleteByProcessRequest);

        /// <summary>
        /// 按BoId删除ActionSoft业务对象
        /// </summary>
        /// <param name="actionSoftBusinessObjectDeleteByIdRequest"><see cref="ActionSoftBusinessObjectDeleteByIdRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<int>> DeleteBusinessObjectById([FormContent] ActionSoftBusinessObjectDeleteByIdRequest actionSoftBusinessObjectDeleteByIdRequest);

        /// <summary>
        /// 获取ActionSoft业务对象
        /// </summary>
        /// <param name="actionSoftBusinessObjectGetRequest"><see cref="ActionSoftBusinessObjectGetRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<string>> GetBusinessObject([FormContent] ActionSoftBusinessObjectGetRequest actionSoftBusinessObjectGetRequest);

        /// <summary>
        /// 查询ActionSoft业务对象
        /// </summary>
        /// <param name="actionSoftBusinessObjectQueryRequest"><see cref="ActionSoftBusinessObjectQueryRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<List<Dictionary<string, string>>>> QueryBusinessObject([FormContent] ActionSoftBusinessObjectQueryRequest actionSoftBusinessObjectQueryRequest);

        /// <summary>
        /// 上传业务附件
        /// </summary>
        /// <param name="actionSoftBusinessObjectAttachmentUploadRequest"><see cref="ActionSoftBusinessObjectAttachmentUploadRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<string>> UploadBusinessObjectAttachment([FormContent] ActionSoftBusinessObjectAttachmentUploadRequest actionSoftBusinessObjectAttachmentUploadRequest);

        /// <summary>
        /// 获取业务附件信息s
        /// </summary>
        /// <param name="actionSoftBusinessObjectAttachmentInfosGetRequest"><see cref="ActionSoftBusinessObjectAttachmentInfosGetRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<List<ActionSoftBusinessObjectAttachmentInfo>>> GetBusinessObjectAttachmentInfos([FormContent] ActionSoftBusinessObjectAttachmentInfosGetRequest actionSoftBusinessObjectAttachmentInfosGetRequest);

        /// <summary>
        /// 下载业务附件
        /// </summary>
        /// <param name="actionSoftBusinessObjectAttachmentDownloadRequest"><see cref="ActionSoftBusinessObjectAttachmentDownloadRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<ActionSoftBusinessObjectAttachmentData>> DownloadBusinessObjectAttachment([FormContent] ActionSoftBusinessObjectAttachmentDownloadRequest actionSoftBusinessObjectAttachmentDownloadRequest);

        /// <summary>
        /// 删除业务附件
        /// </summary>
        /// <param name="actionSoftBusinessObjectAttachmentDeleteRequest"><see cref="ActionSoftBusinessObjectAttachmentRemoveRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse> DeleteBusinessObjectAttachment([FormContent] ActionSoftBusinessObjectAttachmentRemoveRequest actionSoftBusinessObjectAttachmentDeleteRequest);

        /// <summary>
        /// 批量删除业务附件
        /// </summary>
        /// <param name="actionSoftBusinessObjectAttachmentBatchDeleteRequest"><see cref="ActionSoftBusinessObjectAttachmentsRemoveRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse> BatchDeleteBusinessObjectAttachment([FormContent] ActionSoftBusinessObjectAttachmentsRemoveRequest actionSoftBusinessObjectAttachmentBatchDeleteRequest);

    }
}
