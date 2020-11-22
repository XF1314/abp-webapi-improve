using Com.OPPO.Mo.Bpm.Dtos;
using Com.OPPO.Mo.Bpm.Repositories;
using Com.OPPO.Mo.Queriable;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Runtime;
using Microsoft.AspNetCore.Authorization;

namespace Com.OPPO.Mo.Bpm
{
    /// <summary>
    /// Bpm任务回调配置应用服务
    /// </summary>
    [Authorize]
    public class BpmTaskCallbackConfigurationAppService : BpmAppServiceBase, IBpmTaskCallbackConfigurationAppService
    {
        private readonly ITaskCallbackConfigurationRepository _taskCallbackConfigurationRepository;

        /// <summary>
        /// <see cref="BpmTaskCallbackConfigurationAppService"/>
        /// </summary>
        public BpmTaskCallbackConfigurationAppService(ITaskCallbackConfigurationRepository taskCallbackConfigurationRepository)
        {
            _taskCallbackConfigurationRepository = taskCallbackConfigurationRepository;
        }

        /// <inheritdoc/>
        public async Task<Result<TaskCallbackConfigurationDto>> AddTaskCallbackConfiguration(TaskCallbackConfigurationAddInput taskCallbackConfigurationAddInput)
        {
            if (_taskCallbackConfigurationRepository.GetQueryable().Any(x => x.AppId == taskCallbackConfigurationAddInput.AppId
                        && x.ProcessDefinitionId == taskCallbackConfigurationAddInput.ProcessDefinitionId
                        && x.TaskDefinitionId == taskCallbackConfigurationAddInput.TaskDefinitionId
                        && x.TaskEventName == taskCallbackConfigurationAddInput.TaskEventName
                        && x.Action == taskCallbackConfigurationAddInput.Action.ToString()))
                return Result.FromError<TaskCallbackConfigurationDto>($"系统中已经存在" +
                    $"应用【{taskCallbackConfigurationAddInput.AppId}】," +
                    $"流程【{taskCallbackConfigurationAddInput.ProcessDefinitionId}】，" +
                    $"节点【{taskCallbackConfigurationAddInput.TaskDefinitionId}】，" +
                    $"事件【{taskCallbackConfigurationAddInput.TaskEventName}】," +
                    $"审批动作【{taskCallbackConfigurationAddInput.Action}】对应的回调配置");
            else
            {
                var taskCallbackConfiguration = ObjectMapper.Map<TaskCallbackConfigurationAddInput, TaskCallbackConfiguration>(taskCallbackConfigurationAddInput);
                taskCallbackConfiguration = await _taskCallbackConfigurationRepository.InsertAsync(taskCallbackConfiguration);
                var taskCallbackConfigurationDto = ObjectMapper.Map<TaskCallbackConfiguration, TaskCallbackConfigurationDto>(taskCallbackConfiguration);

                return Result.FromData(taskCallbackConfigurationDto);
            }
        }

        /// inheritdoc/>
        public async Task<Result<List<TaskCallbackConfigurationDto>>> BatchUpsertTaskCallbackConfiguration(TaskCallbackConfigurationBatchUpsertInput taskCallbackConfigurationBatchUpsertInput)
        {
            if (!taskCallbackConfigurationBatchUpsertInput.TaskDefinitions.Any())
                return Result.FromCode<List<TaskCallbackConfigurationDto>>(ResultCode.InvalidParams, $"参数【{taskCallbackConfigurationBatchUpsertInput.TaskDefinitions}】不能为空");

            var existedTaskCallbackConfigurations = await _taskCallbackConfigurationRepository.GetQueryable()
                .Where(x => x.AppId == taskCallbackConfigurationBatchUpsertInput.AppId
                && x.Action == taskCallbackConfigurationBatchUpsertInput.Action.ToString()
                && x.ProcessDefinitionId == taskCallbackConfigurationBatchUpsertInput.ProcessDefinitionId
                && taskCallbackConfigurationBatchUpsertInput.TaskEventName == taskCallbackConfigurationBatchUpsertInput.TaskEventName
                && !x.IsDeleted)
                .ToDynamicListAsync<TaskCallbackConfiguration>();
            var taskCallbackConfigurationUpsertTask = new List<Task<TaskCallbackConfiguration>>();
            taskCallbackConfigurationBatchUpsertInput.TaskDefinitions.ToList().ForEach(x =>
            {
                var existedTaskCallbackConfiguration = existedTaskCallbackConfigurations.FirstOrDefault(y => y.TaskDefinitionId == x.Key);
                if (existedTaskCallbackConfiguration is null)
                    taskCallbackConfigurationUpsertTask.Add(_taskCallbackConfigurationRepository.InsertAsync(new TaskCallbackConfiguration
                    {
                        AppId = taskCallbackConfigurationBatchUpsertInput.AppId,
                        AppName = taskCallbackConfigurationBatchUpsertInput.AppName,
                        ProcessDefinitionId = taskCallbackConfigurationBatchUpsertInput.ProcessDefinitionId,
                        ProcessName = taskCallbackConfigurationBatchUpsertInput.ProcessName,
                        TaskDefinitionId = x.Key,
                        TaskName = x.Value,
                        TaskEventName = taskCallbackConfigurationBatchUpsertInput.TaskEventName,
                        Action = taskCallbackConfigurationBatchUpsertInput.Action.ToString(),
                        IsNeedPaasToken = taskCallbackConfigurationBatchUpsertInput.IsNeedPaasToken,
                        ParamsPaths = taskCallbackConfigurationBatchUpsertInput.ParamsPaths,
                        SuccessAssertions = taskCallbackConfigurationBatchUpsertInput.SuccessAssertions,
                        CallbackUrl = taskCallbackConfigurationBatchUpsertInput.CallbackUrl,
                        Headers = taskCallbackConfigurationBatchUpsertInput.Headers,
                        Cipher = taskCallbackConfigurationBatchUpsertInput.Cipher
                    }));
                else
                {
                    existedTaskCallbackConfiguration.AppName = taskCallbackConfigurationBatchUpsertInput.AppName;
                    existedTaskCallbackConfiguration.ProcessName = taskCallbackConfigurationBatchUpsertInput.ProcessName;
                    existedTaskCallbackConfiguration.TaskName = x.Value;
                    existedTaskCallbackConfiguration.ParamsPaths = taskCallbackConfigurationBatchUpsertInput.ParamsPaths;
                    existedTaskCallbackConfiguration.SuccessAssertions = taskCallbackConfigurationBatchUpsertInput.SuccessAssertions;
                    existedTaskCallbackConfiguration.CallbackUrl = taskCallbackConfigurationBatchUpsertInput.CallbackUrl;
                    existedTaskCallbackConfiguration.Headers = taskCallbackConfigurationBatchUpsertInput.Headers;
                    existedTaskCallbackConfiguration.Cipher = taskCallbackConfigurationBatchUpsertInput.Cipher;
                    existedTaskCallbackConfiguration.IsNeedPaasToken = taskCallbackConfigurationBatchUpsertInput.IsNeedPaasToken;
                    existedTaskCallbackConfiguration.IsValid = true;
                    taskCallbackConfigurationUpsertTask.Add(_taskCallbackConfigurationRepository.UpdateAsync(existedTaskCallbackConfiguration));
                }
            });

            var upsertedTaskCallbackConfigurations = await Task.WhenAll(taskCallbackConfigurationUpsertTask.ToArray());
            var taskCallbackConfigurationDtos = ObjectMapper.Map<List<TaskCallbackConfiguration>, List<TaskCallbackConfigurationDto>>(upsertedTaskCallbackConfigurations.ToList());

            return Result.FromData(taskCallbackConfigurationDtos);
        }

        /// inheritdoc/>
        public async Task<Result<TaskCallbackConfigurationDto>> InvalidateTaskCallbackConfiguration(Guid configurationId)
        {
            var taskCallbackConfiguration = await _taskCallbackConfigurationRepository.FindAsync(configurationId);
            if (taskCallbackConfiguration is null)
                return Result.FromCode<TaskCallbackConfigurationDto>(ResultCode.Fail, $"系统中无【{configurationId}】对应的任务回调配置记录");
            else
            {
                taskCallbackConfiguration.IsValid = false;
                taskCallbackConfiguration = await _taskCallbackConfigurationRepository.UpdateAsync(taskCallbackConfiguration);
                var taskCallbackConfigurationDto = ObjectMapper.Map<TaskCallbackConfiguration, TaskCallbackConfigurationDto>(taskCallbackConfiguration);

                return Result.FromData(taskCallbackConfigurationDto);
            }
        }

        /// inheritdoc/>
        public async Task<Result<TaskCallbackConfigurationDto>> ValidateTaskCallbackConfiguration(Guid configurationId)
        {
            var taskCallbackConfiguration = await _taskCallbackConfigurationRepository.FindAsync(configurationId);
            if (taskCallbackConfiguration is null)
                return Result.FromCode<TaskCallbackConfigurationDto>(ResultCode.Fail, $"系统中无【{configurationId}】对应的任务回调配置记录");
            else
            {
                taskCallbackConfiguration.IsValid = true;
                taskCallbackConfiguration = await _taskCallbackConfigurationRepository.UpdateAsync(taskCallbackConfiguration);
                var taskCallbackConfigurationDto = ObjectMapper.Map<TaskCallbackConfiguration, TaskCallbackConfigurationDto>(taskCallbackConfiguration);

                return Result.FromData(taskCallbackConfigurationDto);
            }
        }

        /// inheritdoc/>
        public async Task<Result> DeleteTaskCallbackConfiguration(Guid configurationId)
        {
            await _taskCallbackConfigurationRepository.DeleteAsync(configurationId);

            return Result.Ok();
        }

        /// inheritdoc/>
        public async Task<Result<TaskCallbackConfigurationDto>> GetTaskCallbackConfiguration(Guid configurationId)
        {
            var taskCallbackConfiguration = await _taskCallbackConfigurationRepository.FindAsync(configurationId);
            if (taskCallbackConfiguration is null)
                return Result.FromCode<TaskCallbackConfigurationDto>(ResultCode.Fail, $"系统中无【{configurationId}】对应的任务回调配置记录");
            else
            {
                var taskCallbackConfigurationDto = ObjectMapper.Map<TaskCallbackConfiguration, TaskCallbackConfigurationDto>(taskCallbackConfiguration);

                return Result.FromData(taskCallbackConfigurationDto);
            }
        }

        /// inheritdoc/>
        public async Task<Result<List<TaskCallbackConfigurationDto>>> GetAllTaskCallbackConfigruation()
        {
            var taskCallbackConfigurations = await _taskCallbackConfigurationRepository.GetListAsync();
            var taskCallbackConfigurationDtos = ObjectMapper.Map<List<TaskCallbackConfiguration>, List<TaskCallbackConfigurationDto>>(taskCallbackConfigurations);

            return Result.FromData(taskCallbackConfigurationDtos);
        }

        /// <inheritdoc/>
        public async Task<QueryResult<TaskCallbackConfigurationDto>> QueryTaskCallbackConfiguration(TaskCallbackConfigurationQueryInput taskCallbackConfigurationQueryInput)
        {
            var filter = new Query<TaskCallbackConfiguration>().GetFilter();
            if (!string.IsNullOrWhiteSpace(taskCallbackConfigurationQueryInput.AppId))
                filter = filter.And(x => x.AppId == taskCallbackConfigurationQueryInput.AppId);
            if (!string.IsNullOrWhiteSpace(taskCallbackConfigurationQueryInput.ProcessDefinitionId))
                filter = filter.And(x => x.ProcessDefinitionId == taskCallbackConfigurationQueryInput.ProcessDefinitionId);
            if (!string.IsNullOrWhiteSpace(taskCallbackConfigurationQueryInput.ProcessName))
                filter = filter.And(x => x.ProcessName.Contains(taskCallbackConfigurationQueryInput.ProcessName));
            if (!string.IsNullOrWhiteSpace(taskCallbackConfigurationQueryInput.TaskEventName))
                filter = filter.And(x => x.TaskEventName.Contains(taskCallbackConfigurationQueryInput.TaskEventName));
            if (!string.IsNullOrWhiteSpace(taskCallbackConfigurationQueryInput.TaskDefinitionId))
                filter = filter.And(x => x.TaskDefinitionId == taskCallbackConfigurationQueryInput.TaskDefinitionId);
            if (!string.IsNullOrWhiteSpace(taskCallbackConfigurationQueryInput.CallbackUrl))
                filter = filter.And(x => x.CallbackUrl.Contains(taskCallbackConfigurationQueryInput.CallbackUrl));
            if (taskCallbackConfigurationQueryInput.IsValid.HasValue)
                filter = filter.And(x => x.IsValid == taskCallbackConfigurationQueryInput.IsValid.Value);

            var taskCallbackConfigurations = await _taskCallbackConfigurationRepository.GetQueryable().Where(filter).ToDynamicListAsync<TaskCallbackConfiguration>();
            var taskCallbackConfigurationDtos = ObjectMapper.Map<List<TaskCallbackConfiguration>, List<TaskCallbackConfigurationDto>>(taskCallbackConfigurations);
            return QueryResult.FromData(taskCallbackConfigurationDtos);
        }

    }
}
