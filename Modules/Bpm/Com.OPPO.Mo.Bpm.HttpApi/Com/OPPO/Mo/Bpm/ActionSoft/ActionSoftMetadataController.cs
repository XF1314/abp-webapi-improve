using Com.OPPO.Mo.Bpm.ActionSoft.Metadatas;
using Com.OPPO.Mo.Bpm.ActionSoft.Metadatas.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Bpm.ActionSoft
{
    /// <summary>
    /// ActionSoft元数据
    /// </summary>
    [Area("actionsoft")]
    [Route("openapi/actionsoft/metadata")]
    public class ActionSoftMetadataController : AbpController
    {
        private readonly IActionSoftMetadataAppService _actionSoftMetadataAppService;

        /// <summary>
        /// <see cref="ActionSoftMetadataController"/>
        /// </summary>
        public ActionSoftMetadataController(IActionSoftMetadataAppService actionSoftMetadataAppService)
        {
            _actionSoftMetadataAppService = actionSoftMetadataAppService;
        }

        /// <summary>
        /// 获取人工任务定义
        /// </summary>
        /// <param name="userTaskDefinitionGetInput"><see cref="ActionSoftUserTaskDefinitionGetInput"/></param>
        /// <returns></returns>
        [HttpGet("user-task-definition/get")]
        public async Task<Result<string>> GetUserTaskDefinition([FromQuery] ActionSoftUserTaskDefinitionGetInput userTaskDefinitionGetInput)
        {
            return await _actionSoftMetadataAppService.GetUserTaskDefinition(userTaskDefinitionGetInput);
        }

        /// <summary>
        /// 获取流程定义
        /// </summary>
        /// <param name="processDefinitionId">流程定义Id</param>
        /// <returns></returns>
        [HttpGet("process-definition/get")]
        public async Task<Result<string>> GetProcessDefinition(string processDefinitionId)
        {
            return await _actionSoftMetadataAppService.GetProcessDefinition(processDefinitionId);
        }

        /// <summary>
        /// 获取流程说明
        /// </summary>
        /// <param name="processDefinitionId">流程定义Id</param>
        /// <returns></returns>
        [HttpGet("process-document/get")]
        public async Task<Result<string>> GetProcessDocument(string processDefinitionId)
        {
            return await _actionSoftMetadataAppService.GetProcessDocument(processDefinitionId);
        }

        /// <summary>
        /// 获取流程主版本（正在运行的版本）Id
        /// </summary>
        /// <param name="processDefinitionId">流程定义Id</param>
        /// <returns></returns>
        [HttpGet("process-main-version-id/get")]
        public async Task<Result<string>> GetProcessMainVersionId(string processDefinitionId)
        {
            return await _actionSoftMetadataAppService.GetProcessMainVersionId(processDefinitionId);
        }

        /// <summary>
        /// 获取流程定义Id
        /// </summary>
        /// <param name="processDefinitionVersionId">流程定义版本Id</param>
        /// <returns></returns>
        [HttpGet("process-definition-id/get")]
        public async Task<Result<string>> GetProcessDefinitionId(string processDefinitionVersionId)
        {
            return await _actionSoftMetadataAppService.GetProcessDefinitionId(processDefinitionVersionId);
        }

        /// <summary>
        /// 获取流程跟踪Url
        /// </summary>
        /// <param name="processInstanceId">流程实例Id</param>
        /// <returns></returns>
        [HttpGet("process-tracking-url/get")]
        public async Task<Result<string>> GetProcessTrackingUrl(string processInstanceId)
        {
            return await _actionSoftMetadataAppService.GetProcessTrackingUrl(processInstanceId);
        }
    }
}
