using Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects;
using Com.OPPO.Mo.Bpm.ActionSoft.BusinessObjects.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Bpm.ActionSoft
{
    /// <summary>
    /// ActionSoft业务对象
    /// </summary>
    [Area("actionsoft")]
    [Route("openapi/actionsoft/business-object")]

    public class ActionSoftBusinessObjectController : AbpController
    {
        private readonly int BUFFER_SIZE = 2 * 1024;
        private readonly IConfiguration _configuration;
        private readonly IActionSoftBusinessObjectAppService _actionSoftBusinessObjectAppService;

        /// <summary>
        /// <see cref="ActionSoftBusinessObjectController"/>
        /// </summary>
        public ActionSoftBusinessObjectController(IConfiguration configuration, IActionSoftBusinessObjectAppService actionSoftBusinessObjectAppService)
        {
            _configuration = configuration;
            _actionSoftBusinessObjectAppService = actionSoftBusinessObjectAppService;
        }

        /// <summary>
        /// 创建业务对象
        /// </summary>
        /// <param name="businessObjectCreateInput"><see cref="ActionSoftBusinessObjectCreateInput"/></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<Result<string>> CreateBusinessObject([FromBody] ActionSoftBusinessObjectCreateInput businessObjectCreateInput)
        {
            return await _actionSoftBusinessObjectAppService.CreateBusinessObject(businessObjectCreateInput);
        }

        /// <summary>
        /// 批量创建业务对象
        /// </summary>
        /// <param name="businessObjectBatchCreateInput"><see cref="ActionSoftBusinessObjectBatchCreateInput"/></param>
        /// <returns></returns>
        [HttpPost("batch-create")]
        public async Task<Result<List<string>>> BatchCreateBusinessObject([FromBody] ActionSoftBusinessObjectBatchCreateInput businessObjectBatchCreateInput)
        {
            return await _actionSoftBusinessObjectAppService.BatchCreateBusinessObject(businessObjectBatchCreateInput);
        }

        /// <summary>
        /// 删除与流程相关业务对象
        /// </summary>
        /// <param name="businessObjectDeleteByProcessInput"><see cref="ActionSoftBusinessObjectDeleteByProcessInput"/></param>
        /// <returns></returns>
        [HttpPost("delete-by-process")]
        public async Task<Result<int>> DeleteBusinessObjectByProcess([FromBody] ActionSoftBusinessObjectDeleteByProcessInput businessObjectDeleteByProcessInput)
        {
            return await _actionSoftBusinessObjectAppService.DeleteBusinessObjectByProcess(businessObjectDeleteByProcessInput);
        }

        /// <summary>
        /// 根据Id获取业务对象
        /// </summary>
        /// <param name="businessObjectTableName">业务对象表名称</param>
        /// <param name="businessObjectId">业务对象Id</param>
        /// <returns></returns>
        [HttpGet("get-by-id")]
        public async Task<Result<string>> GetBusinessObject(string businessObjectTableName, string businessObjectId)
        {
            var businessObjectGetInput = new ActionSoftBusinessObjectGetInput
            {
                BusinessObjectTableName = businessObjectTableName,
                BusinessObjectId = businessObjectId
            };

            return await _actionSoftBusinessObjectAppService.GetBusinessObjectById(businessObjectGetInput);
        }

        /// <summary>
        /// 查询业务对象
        /// </summary>
        /// <param name="businessObjectQueryInput"><see cref="ActionSoftBusinessObjectQueryInput"/></param>
        /// <returns></returns>
        [HttpPost("query")]
        public async Task<Result<List<Dictionary<string, string>>>> QueryBusinessObject([FromBody] ActionSoftBusinessObjectQueryInput businessObjectQueryInput)
        {
            return await _actionSoftBusinessObjectAppService.QueryBusinessObject(businessObjectQueryInput);
        }

        /// <summary>
        /// 获取特定业务对象字段
        /// </summary>
        /// <param name="businessObjectTableName">业务对象集全名称</param>
        /// <param name="businessObjectId">业务对象Id</param>
        /// <param name="fieldName">字段名称</param>
        /// <returns></returns>
        [HttpGet("get-specified-field")]
        public async Task<Result<string>> GetBusinessObjectField(string businessObjectTableName, string businessObjectId, string fieldName)
        {
            var businessObjectFieldGetInput = new ActionSoftBusinessObjectFieldGetInput
            {
                BusinessObjectTableName = businessObjectTableName,
                BusinessObjectId = businessObjectId,
                FieldName = fieldName
            };

            return await _actionSoftBusinessObjectAppService.GetBusinessObjectField(businessObjectFieldGetInput);
        }

        /// <summary>
        /// 批量更新业务对象字段
        /// </summary>
        /// <param name="businessObjectFieldBatchUpdateInput"><see cref="ActionSoftBusinessObjectFieldBatchUpdateInput"/></param>
        /// <returns></returns>
        [HttpPost("batch-update-field")]
        public async Task<Result<int>> BatchUpdateBusinessObjectField([FromBody] ActionSoftBusinessObjectFieldBatchUpdateInput businessObjectFieldBatchUpdateInput)
        {
            return await _actionSoftBusinessObjectAppService.BatchUpdateBusinessObjectField(businessObjectFieldBatchUpdateInput);
        }

        /// <summary>
        /// 按流程更新特定业务对象字段
        /// </summary>
        /// <param name="businessObjectFieldUpdateByProcessInput"><see cref="ActionSoftBusinessObjectFieldUpdateByProcessInput"/></param>
        /// <returns></returns>
        [HttpPost("update-field-by-process")]
        public async Task<Result<int>> UpdateBusinessObjectFieldByProcess([FromBody] ActionSoftBusinessObjectFieldUpdateByProcessInput businessObjectFieldUpdateByProcessInput)
        {
            return await _actionSoftBusinessObjectAppService.UpdateBusinessObjectFieldByProcess(businessObjectFieldUpdateByProcessInput);
        }

        /// <summary>
        /// 上传业务附件
        /// </summary>
        /// <param name="businessObjectAttachmentUploadInput"><see cref="ActionSoftBusinessObjectAttachmentInfoInput"/></param>
        /// <returns></returns>
        [HttpPost("attachment/upload-by-uri")]
        public async Task<Result<string>> UploadBusinessObjectAttachment([FromBody] ActionSoftBusinessObjectAttachmentUploadInput businessObjectAttachmentUploadInput)
        {
            var offset = 0;
            byte[] attachmentContent;
            var buffer = new byte[BUFFER_SIZE];
            var attachmentMaxSize = int.Parse(_configuration["oppo-mo-bpm-service-attachment-max-size"]) * 1024 * 1024;
            using (var webResponse = await FileWebRequest.Create(businessObjectAttachmentUploadInput.AttachmentUri).GetResponseAsync())
            using (var attachmentStream = webResponse.GetResponseStream())
            using (var memoryStream = new MemoryStream())
            {
                while (attachmentStream.Read(buffer, offset, BUFFER_SIZE) > 0)
                {
                    memoryStream.Write(buffer);
                }

                attachmentContent = memoryStream.ToArray();
            }

            if (attachmentContent.Length > attachmentMaxSize)
                return Result.FromCode<string>(ResultCode.Forbidden, $"业务附件最大只支持到{_configuration["oppo-mo-bpm-service-attachment-max-size"]}MB");
            return await _actionSoftBusinessObjectAppService.UploadBusinessObjectAttachment((ActionSoftBusinessObjectAttachmentInfoInput)businessObjectAttachmentUploadInput, attachmentContent);
        }

        /// <summary>
        /// 上传业务附件
        /// </summary>
        /// <param name="businessObjectAttachmentInfoInput"><see cref="ActionSoftBusinessObjectAttachmentInfoInput"/></param>
        /// <param name="attachment"><see cref="IFormFile"/>附件，最大支持50M</param>
        /// <returns></returns>
        [HttpPost("attachment/upload")]
        public async Task<Result<string>> UploadBusinessObjectAttachment(ActionSoftBusinessObjectAttachmentInfoInput businessObjectAttachmentInfoInput, IFormFile attachment)
        {
            var attachmentMaxSize = int.Parse(_configuration["oppo-mo-bpm-service-attachment-max-size"]) * 1024 * 1024;
            if (attachment.Length > attachmentMaxSize)
                return Result.FromCode<string>(ResultCode.Forbidden, $"业务附件最大只支持到{_configuration["oppo-mo-bpm-service-attachment-max-size"]}MB");
            if (attachment.Length <= 0)
                return Result.FromError<string>("附件不能为空");

            var attachmentContent = new byte[attachment.Length];
            using (var stream = attachment.OpenReadStream())
            {
                stream.Read(attachmentContent, 0, attachmentContent.Length);
            }

            return await _actionSoftBusinessObjectAppService.UploadBusinessObjectAttachment(businessObjectAttachmentInfoInput, attachmentContent);
        }

        /// <summary>
        /// 获取业务对象字段所绑定的所有附件信息s
        /// </summary>
        /// <param name="businessObjectAttachmentInfosGetInput"><see cref="ActionSoftBusinessObjectAttachmentInfosGetInput"/></param>
        /// <returns></returns>
        [HttpGet("attachment/info/get-by-field")]
        public async Task<Result<List<ActionSoftBusinessObjectAttachmentInfoDto>>> GetBusinessObjectAttachmentInfos(ActionSoftBusinessObjectAttachmentInfosGetInput businessObjectAttachmentInfosGetInput)
        {
            return await _actionSoftBusinessObjectAppService.GetBusinessObjectAttachmentInfos(businessObjectAttachmentInfosGetInput);
        }

        /// <summary>
        /// 下载业务附件
        /// </summary>
        /// <param name="businessObjectAttachmentDownloadInput"><see cref="ActionSoftBusinessObjectAttachmentDownloadInput"/></param>
        /// <returns></returns>
        [HttpPost("attachment/download")]
        public async Task<Result<ActionSoftBusinessObjectAttachmentDataDto>> DownloadBusinessObjectAttachment([FromBody] ActionSoftBusinessObjectAttachmentDownloadInput businessObjectAttachmentDownloadInput)
        {
            return await _actionSoftBusinessObjectAppService.DownloadBusinessObjectAttachment(businessObjectAttachmentDownloadInput);
        }

        /// <summary>
        /// 移除业务附件
        /// </summary>
        /// <param name="businessObjectAttachmentDeleteInput"><see cref="ActionSoftBusinessObjectAttachmentsRemoveInput"/></param>
        /// <returns></returns>
        [HttpPost("attachment/remove")]
        public async Task<Result> RemoveBusinessObjectAttachment([FromBody] ActionSoftBusinessObjectAttachmentsRemoveInput businessObjectAttachmentDeleteInput)
        {
            return await _actionSoftBusinessObjectAppService.RemoveBusinessObjectAttachment(businessObjectAttachmentDeleteInput);
        }

        /// <summary>
        /// 移除业务对象字段所绑定的所有附件
        /// </summary>
        /// <param name="businessObjectAttachmentBatchDeleteInput"><see cref="ActionSoftBusinessObjectAttachmentRemoveInput"/></param>
        /// <returns></returns>
        [HttpPost("attachment/remove-by-field")]
        public async Task<Result> RemoveusinessObjectAttachment([FromBody] ActionSoftBusinessObjectAttachmentRemoveInput businessObjectAttachmentBatchDeleteInput)
        {
            return await _actionSoftBusinessObjectAppService.RemoveBusinessObjectAttachments(businessObjectAttachmentBatchDeleteInput);
        }

    }
}
