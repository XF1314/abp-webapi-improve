using Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Dtos;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects
{
    /// <summary>
    /// 业务对象应用服务接口
    /// </summary>
    public interface IActionSoftBusinessObjectAppService : IApplicationService
    {
        /// <summary>
        /// 创建业务对象
        /// </summary>
        /// <param name="actionSoftBusinessObjectCreateInput"><see cref="ActionSoftBusinessObjectCreateInput"/></param>
        /// <returns></returns>
        Task<Result<string>> CreateBusinessObject(ActionSoftBusinessObjectCreateInput actionSoftBusinessObjectCreateInput);

        /// <summary>
        /// 创建业务对象
        /// </summary>
        /// <param name="actionSoftBusinessObjectBatchCreateInput"><see cref="ActionSoftBusinessObjectBatchCreateInput"/></param>
        /// <returns></returns>
        Task<Result<List<string>>> BatchCreateBusinessObject(ActionSoftBusinessObjectBatchCreateInput actionSoftBusinessObjectBatchCreateInput);

        /// <summary>
        /// 按流程删除相关联的业务对象
        /// </summary>
        /// <param name="actionSoftBusinessObjectDeleteByProcessInput"><see cref="ActionSoftBusinessObjectDeleteByProcessInput"/></param>
        /// <returns></returns>
        Task<Result<int>> DeleteBusinessObjectByProcess(ActionSoftBusinessObjectDeleteByProcessInput actionSoftBusinessObjectDeleteByProcessInput);

        /// <summary>
        /// 获取业务对象
        /// </summary>
        /// <param name="actionSoftBusinessObjectGetInput"><see cref="ActionSoftBusinessObjectGetInput"/></param>
        /// <returns></returns>
        Task<Result<string>> GetBusinessObjectById(ActionSoftBusinessObjectGetInput actionSoftBusinessObjectGetInput);

        /// <summary>
        /// 查询业务对象
        /// </summary>
        /// <param name="actionSoftBusinessObjectQueryInput"><see cref="ActionSoftBusinessObjectQueryInput"/></param>
        /// <returns></returns>
        Task<Result<List<Dictionary<string, string>>>> QueryBusinessObject(ActionSoftBusinessObjectQueryInput actionSoftBusinessObjectQueryInput);

        /// <summary>
        /// 获取业务对象字段
        /// </summary>
        /// <param name="actionSoftBusinessObjectFieldGetInput"><see cref="ActionSoftBusinessObjectFieldGetInput"/></param>
        /// <returns></returns>
        Task<Result<string>> GetBusinessObjectField(ActionSoftBusinessObjectFieldGetInput actionSoftBusinessObjectFieldGetInput);

        /// <summary>
        /// 按流程实例更新业务对象字段
        /// </summary>
        /// <param name="actionSoftBusinessObjectFieldUpdateByProcessInput"><see cref="ActionSoftBusinessObjectFieldUpdateByProcessInput"/></param>
        /// <returns></returns>
        Task<Result<int>> UpdateBusinessObjectFieldByProcess(ActionSoftBusinessObjectFieldUpdateByProcessInput actionSoftBusinessObjectFieldUpdateByProcessInput);

        /// <summary>
        /// 批量更新业务对象字段
        /// </summary>
        /// <param name="actionSoftBusinessObjectFieldBatchUpdateInput"><see cref="ActionSoftBusinessObjectFieldBatchUpdateInput"/></param>
        /// <returns></returns>
        Task<Result<int>> BatchUpdateBusinessObjectField(ActionSoftBusinessObjectFieldBatchUpdateInput actionSoftBusinessObjectFieldBatchUpdateInput);

        /// <summary>
        /// 上传业务附件
        /// </summary>
        /// <param name="actionSoftBusinessObjectAttachmentInfoInput"><see cref="ActionSoftBusinessObjectAttachmentInfoInput"/></param>
        /// <param name="fileContent">附件内容</param>
        /// <returns></returns>
        Task<Result<string>> UploadBusinessObjectAttachment(ActionSoftBusinessObjectAttachmentInfoInput actionSoftBusinessObjectAttachmentInfoInput, byte[] fileContent);

        /// <summary>
        /// 获取业务附件信息s
        /// </summary>
        /// <param name="actionSoftBusinessObjectAttachmentInfosGetInput"><see cref="ActionSoftBusinessObjectAttachmentInfosGetInput"/></param>
        /// <returns></returns>
        Task<Result<List<ActionSoftBusinessObjectAttachmentInfoDto>>> GetBusinessObjectAttachmentInfos(ActionSoftBusinessObjectAttachmentInfosGetInput actionSoftBusinessObjectAttachmentInfosGetInput);

        /// <summary>
        /// 下载业务附件
        /// </summary>
        /// <param name="actionSoftBusinessObjectAttachmentDownloadInput"><see cref="ActionSoftBusinessObjectAttachmentDownloadInput"/></param>
        /// <returns></returns>
        Task<Result<ActionSoftBusinessObjectAttachmentDataDto>> DownloadBusinessObjectAttachment(ActionSoftBusinessObjectAttachmentDownloadInput actionSoftBusinessObjectAttachmentDownloadInput);

        /// <summary>
        /// 移除业务附件
        /// </summary>
        /// <param name="actionSoftBusinessObjectAttachmentDeleteInput"><see cref="ActionSoftBusinessObjectAttachmentsRemoveInput"/></param>
        /// <returns></returns>
        Task<Result> RemoveBusinessObjectAttachment(ActionSoftBusinessObjectAttachmentsRemoveInput actionSoftBusinessObjectAttachmentDeleteInput);

        /// <summary>
        /// 批量移除业务附件
        /// </summary>
        /// <param name="actionSoftBusinessObjectAttachmentBatchDeleteInput"><see cref="ActionSoftBusinessObjectAttachmentRemoveInput"/></param>
        /// <returns></returns>
        Task<Result> RemoveBusinessObjectAttachments(ActionSoftBusinessObjectAttachmentRemoveInput actionSoftBusinessObjectAttachmentBatchDeleteInput);

    }
}
