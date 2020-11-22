using Com.OPPO.Mo.Bpm.ActionSoft.Metadatas.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Metadatas
{
    /// <summary>
    /// ActionSoft元数据WebApi服务接口
    /// </summary>
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(BpmSettingNames.ActiontSoftWebApiHost)]
    public interface IActionSoftMetadataWebApiService : IHttpApi
    {
        /// <summary>
        /// 获取人工任务定义
        /// </summary>
        /// <param name="actionSoftUserTaskDefinitionGetRequest"><see cref="ActionSoftUserTaskDefinitionGetRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<string>> GetUserTaskDefinition(ActionSoftUserTaskDefinitionGetRequest actionSoftUserTaskDefinitionGetRequest);

        /// <summary>
        /// 获取流程定义
        /// </summary>
        /// <param name="actionSoftProcessDefinitionGetRequest"><see cref="ActionSoftProcessDefinitionGetRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<string>> GetProcessDefinition(ActionSoftProcessDefinitionGetRequest actionSoftProcessDefinitionGetRequest);

        /// <summary>
        /// 获取流程说明
        /// </summary>
        /// <param name="actionSoftProcessDocumentGetRequest"><see cref="ActionSoftProcessDocumentGetRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<string>> GetProcessDocument(ActionSoftProcessDocumentGetRequest actionSoftProcessDocumentGetRequest);

        /// <summary>
        /// 获取流程主版本（正在运行的版本）Id
        /// </summary>
        /// <param name="actionSoftProcessMainVersionIdGetRequest"><see cref="ActionSoftProcessMainVersionIdGetRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<string>> GetProcessMainVersionId(ActionSoftProcessMainVersionIdGetRequest actionSoftProcessMainVersionIdGetRequest);

        /// <summary>
        /// 获取流程定义Id
        /// </summary>
        /// <param name="actionSoftProcessDefinitionIdGetRequest"><see cref="ActionSoftProcessDefinitionIdGetRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<string>> GetProcessDefinitionId(ActionSoftProcessDefinitionIdGetRequest actionSoftProcessDefinitionIdGetRequest);

        /// <summary>
        /// 获取流程跟踪Url
        /// </summary>
        /// <param name="actionSoftProcessTrackingUrlGetRequest"><see cref="ActionSoftProcessTrackingUrlGetRequest"/></param>
        /// <returns></returns>
        [HttpPost("/portal/openapi")]
        Task<ActionSoftWebApiResponse<string>> GetProcessTrackingUrl(ActionSoftProcessTrackingUrlGetRequest actionSoftProcessTrackingUrlGetRequest);


    }
}
