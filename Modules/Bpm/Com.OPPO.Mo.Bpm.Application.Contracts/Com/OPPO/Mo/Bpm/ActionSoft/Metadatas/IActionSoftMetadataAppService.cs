using Com.OPPO.Mo.Bpm.ActionSoft.Metadatas.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Metadatas
{
    /// <summary>
    /// ActionSoft元数据应用服务接口
    /// </summary>
    public interface IActionSoftMetadataAppService : IApplicationService
    {
        /// <summary>
        /// 获取人工任务定义
        /// </summary>
        /// <param name="userTaskDefinitionGetInput"><see cref="ActionSoftUserTaskDefinitionGetInput"/></param>
        /// <returns></returns>
        Task<Result<string>> GetUserTaskDefinition(ActionSoftUserTaskDefinitionGetInput userTaskDefinitionGetInput);

        /// <summary>
        /// 获取流程定义
        /// </summary>
        /// <param name="processDefinitionId">流程定义Id</param>
        /// <returns></returns>
        Task<Result<string>> GetProcessDefinition(string processDefinitionId);

        /// <summary>
        /// 获取流程说明
        /// </summary>
        /// <param name="processDefinitionId">流程定义Id</param>
        /// <returns></returns>
        Task<Result<string>> GetProcessDocument(string processDefinitionId);

        /// <summary>
        /// 获取流程主版本（正在运行的版本）Id
        /// </summary>
        /// <param name="processDefinitionId">流程定义Id</param>
        /// <returns></returns>
        Task<Result<string>> GetProcessMainVersionId(string processDefinitionId);

        /// <summary>
        /// 获取流程定义Id
        /// </summary>
        /// <param name="processDefinitionVersionId">流程定义版本Id</param>
        /// <returns></returns>
        Task<Result<string>> GetProcessDefinitionId(string processDefinitionVersionId);

        /// <summary>
        /// 获取流程跟踪Url
        /// </summary>
        /// <param name="processInstanceId">流程实例Id</param>
        /// <returns></returns>
        Task<Result<string>> GetProcessTrackingUrl(string processInstanceId);

    }
}
