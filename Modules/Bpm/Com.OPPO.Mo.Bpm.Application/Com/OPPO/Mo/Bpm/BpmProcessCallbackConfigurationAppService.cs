using Com.OPPO.Mo.Bpm.Dtos;
using Com.OPPO.Mo.Bpm.Repositories;
using Com.OPPO.Mo.Queriable;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Bpm
{
    /// <summary>
    /// Bpm流程回调配置应用服务
    /// </summary>
    [Authorize]
    public class BpmProcessCallbackConfigurationAppService : BpmAppServiceBase, IBpmProcessCallbackConfigurationAppService
    {

        private readonly IProcessCallbackConfigurationRepository _processCallbackConfigurationRepository;

        /// <summary>
        /// <see cref="BpmProcessCallbackConfigurationAppService"/>
        /// </summary>
        public BpmProcessCallbackConfigurationAppService(IProcessCallbackConfigurationRepository processCallbackConfigurationRepository)
        {
            _processCallbackConfigurationRepository = processCallbackConfigurationRepository;
        }


        /// <inheritdoc/>
        public async Task<Result<ProcessCallbackConfigurationDto>> AddProcessCallbackConfiguration(ProcessCallbackConfigurationAddInput processCallbackConfigurationAddInput)
        {
            if (_processCallbackConfigurationRepository.GetQueryable()
                .Any(x => x.AppId == processCallbackConfigurationAddInput.AppId
                && x.ProcessDefinitionId == processCallbackConfigurationAddInput.ProcessDefinitionId
                && x.ProcessEventName == processCallbackConfigurationAddInput.ProcessEventName
                && x.CallbackUrl == processCallbackConfigurationAddInput.CallbackUrl))
                return Result.FromError<ProcessCallbackConfigurationDto>($"系统中已经存在" +
                    $"应用【{processCallbackConfigurationAddInput.AppId}】，" +
                    $"流程【{processCallbackConfigurationAddInput.ProcessDefinitionId}】，" +
                    $"事件【{processCallbackConfigurationAddInput.ProcessEventName}】对应的回调配置记录");
            else
            {
                var processCallbackConfiguration = ObjectMapper.Map<ProcessCallbackConfigurationAddInput, ProcessCallbackConfiguration>(processCallbackConfigurationAddInput);
                processCallbackConfiguration = await _processCallbackConfigurationRepository.InsertAsync(processCallbackConfiguration);
                var processCallbackConfigurationDto = ObjectMapper.Map<ProcessCallbackConfiguration, ProcessCallbackConfigurationDto>(processCallbackConfiguration);

                return Result.FromData(processCallbackConfigurationDto);
            }
        }

        /// <inheritdoc/>
        public async Task<Result<List<ProcessCallbackConfigurationDto>>> BatchUpsertProcessCallbackConfiguration(ProcessCallbackConfigurationBatchUpsertInput processCallbackConfigurationBatchUpsertInput)
        {
            if (!processCallbackConfigurationBatchUpsertInput.ProcessEventNames.Any())
                return Result.FromCode<List<ProcessCallbackConfigurationDto>>(ResultCode.InvalidParams, $"参数【{processCallbackConfigurationBatchUpsertInput.ProcessEventNames}】不能为空");

            var existedProcessCallbackConfigurations = await _processCallbackConfigurationRepository.GetQueryable()
                .Where(x => x.AppId == processCallbackConfigurationBatchUpsertInput.AppId
                && x.ProcessDefinitionId == processCallbackConfigurationBatchUpsertInput.ProcessDefinitionId)
                .ToDynamicListAsync<ProcessCallbackConfiguration>();
            var processCallbackConfigurationUpsertTasks = new List<Task<ProcessCallbackConfiguration>>();
            processCallbackConfigurationBatchUpsertInput.ProcessEventNames.ForEach(x =>
            {
                var existedProcessCallbackConfiguration = existedProcessCallbackConfigurations.FirstOrDefault(y => y.ProcessEventName == x);
                if (existedProcessCallbackConfiguration is null)
                    processCallbackConfigurationUpsertTasks.Add(_processCallbackConfigurationRepository.InsertAsync(new ProcessCallbackConfiguration
                    {
                        AppId = processCallbackConfigurationBatchUpsertInput.AppId,
                        AppName = processCallbackConfigurationBatchUpsertInput.AppName,
                        ProcessDefinitionId = processCallbackConfigurationBatchUpsertInput.ProcessDefinitionId,
                        ProcessName = processCallbackConfigurationBatchUpsertInput.ProcessName,
                        ProcessEventName = x,
                        ParamsPaths = processCallbackConfigurationBatchUpsertInput.ParamsPaths,
                        SuccessAssertions = processCallbackConfigurationBatchUpsertInput.SuccessAssertions,
                        CallbackUrl = processCallbackConfigurationBatchUpsertInput.CallbackUrl,
                        IsNeedPaasToken = processCallbackConfigurationBatchUpsertInput.IsNeedPaasToken,
                        Headers = processCallbackConfigurationBatchUpsertInput.Headers,
                        Cipher = processCallbackConfigurationBatchUpsertInput.Cipher
                    }));
                else
                {
                    existedProcessCallbackConfiguration.AppName = processCallbackConfigurationBatchUpsertInput.AppName;
                    existedProcessCallbackConfiguration.ProcessName = processCallbackConfigurationBatchUpsertInput.ProcessName;
                    existedProcessCallbackConfiguration.ParamsPaths = processCallbackConfigurationBatchUpsertInput.ParamsPaths;
                    existedProcessCallbackConfiguration.SuccessAssertions = processCallbackConfigurationBatchUpsertInput.SuccessAssertions;
                    existedProcessCallbackConfiguration.CallbackUrl = processCallbackConfigurationBatchUpsertInput.CallbackUrl;
                    existedProcessCallbackConfiguration.Headers = processCallbackConfigurationBatchUpsertInput.Headers;
                    existedProcessCallbackConfiguration.IsNeedPaasToken = processCallbackConfigurationBatchUpsertInput.IsNeedPaasToken;
                    existedProcessCallbackConfiguration.Cipher = processCallbackConfigurationBatchUpsertInput.Cipher;
                    existedProcessCallbackConfiguration.IsValid = true;
                    processCallbackConfigurationUpsertTasks.Add(_processCallbackConfigurationRepository.UpdateAsync(existedProcessCallbackConfiguration));
                }
            });

            var upsertedProcessCallbackConfigurations = await Task.WhenAll(processCallbackConfigurationUpsertTasks.ToArray());
            var processCallbackConfigurationDtos = ObjectMapper.Map<List<ProcessCallbackConfiguration>, List<ProcessCallbackConfigurationDto>>(upsertedProcessCallbackConfigurations.ToList());

            return Result.FromData(processCallbackConfigurationDtos);
        }

        /// <inheritdoc/>
        public async Task<Result<ProcessCallbackConfigurationDto>> InvalidateProcessCallbackConfiguration(Guid configurationId)
        {
            var processCallbackConfiguration = await _processCallbackConfigurationRepository.FindAsync(configurationId);
            if (processCallbackConfiguration is null)
                return Result.FromCode<ProcessCallbackConfigurationDto>(ResultCode.Fail, $"系统中无【{configurationId}】对应的流程回调配置记录");
            else
            {
                processCallbackConfiguration.IsValid = false;
                processCallbackConfiguration = await _processCallbackConfigurationRepository.UpdateAsync(processCallbackConfiguration);
                var processCallbackConfigurationDto = ObjectMapper.Map<ProcessCallbackConfiguration, ProcessCallbackConfigurationDto>(processCallbackConfiguration);

                return Result.FromData(processCallbackConfigurationDto);
            }
        }

        /// <inheritdoc/>
        public async Task<Result<ProcessCallbackConfigurationDto>> ValidateProcessCallbackConfiguration(Guid configurationId)
        {
            var processCallbackConfiguration = await _processCallbackConfigurationRepository.FindAsync(configurationId);
            if (processCallbackConfiguration is null)
                return Result.FromCode<ProcessCallbackConfigurationDto>(ResultCode.Fail, $"系统中无【{configurationId}】对应的流程回调配置记录");
            else
            {
                processCallbackConfiguration.IsValid = true;
                processCallbackConfiguration = await _processCallbackConfigurationRepository.UpdateAsync(processCallbackConfiguration);
                var processCallbackConfigurationDto = ObjectMapper.Map<ProcessCallbackConfiguration, ProcessCallbackConfigurationDto>(processCallbackConfiguration);

                return Result.FromData(processCallbackConfigurationDto);
            }
        }

        /// <inheritdoc/>
        public async Task<Result> DeleteProcessCallbackConfiguration(Guid configurationId)
        {
            await _processCallbackConfigurationRepository.DeleteAsync(configurationId);

            return Result.Ok();
        }

        /// <inheritdoc/>
        public async Task<Result<ProcessCallbackConfigurationDto>> GetProcessCallbackConfiguration(Guid configurationId)
        {
            var processCallbackConfiguration = await _processCallbackConfigurationRepository.GetAsync(configurationId);
            if (processCallbackConfiguration is null)
                return Result.FromCode<ProcessCallbackConfigurationDto>(ResultCode.NoData, $"系统中无【{configurationId}】对应的流程回调配置");
            else
            {
                var processCallbackConfigurationDto = ObjectMapper.Map<ProcessCallbackConfiguration, ProcessCallbackConfigurationDto>(processCallbackConfiguration);
                return Result.FromData(processCallbackConfigurationDto);
            }
        }

        /// inheritdoc/>
        public async Task<Result<List<ProcessCallbackConfigurationDto>>> GetAllProcessCallbackConfigruation()
        {
            var processCallbackConfigurations = await _processCallbackConfigurationRepository.GetListAsync();
            var processCallbackConfigurationDtos = ObjectMapper.Map<List<ProcessCallbackConfiguration>, List<ProcessCallbackConfigurationDto>>(processCallbackConfigurations);

            return Result.FromData(processCallbackConfigurationDtos);
        }

        /// <inheritdoc/>
        public async Task<QueryResult<ProcessCallbackConfigurationDto>> QueryProcessCallbackConfiguration(ProcessCallbackConfigurationQueryInput processCallbackConfigurationQueryInput)
        {
            var filter = new Query<ProcessCallbackConfiguration>().GetFilter();
            if (!string.IsNullOrWhiteSpace(processCallbackConfigurationQueryInput.AppId))
                filter = filter.And(x => x.AppId == processCallbackConfigurationQueryInput.AppId);
            if (!string.IsNullOrWhiteSpace(processCallbackConfigurationQueryInput.ProcessDefinitionId))
                filter = filter.And(x => x.ProcessDefinitionId == processCallbackConfigurationQueryInput.ProcessDefinitionId);
            if (!string.IsNullOrWhiteSpace(processCallbackConfigurationQueryInput.ProcessName))
                filter = filter.And(x => x.ProcessName.Contains(processCallbackConfigurationQueryInput.ProcessName));
            if (!string.IsNullOrWhiteSpace(processCallbackConfigurationQueryInput.ProcessEventName))
                filter = filter.And(x => x.ProcessEventName.Contains(processCallbackConfigurationQueryInput.ProcessEventName));
            if (!string.IsNullOrWhiteSpace(processCallbackConfigurationQueryInput.CallbackUrl))
                filter = filter.And(x => x.CallbackUrl.Contains(processCallbackConfigurationQueryInput.CallbackUrl));
            if (processCallbackConfigurationQueryInput.IsValid.HasValue)
                filter = filter.And(x => x.IsValid == processCallbackConfigurationQueryInput.IsValid.Value);

            var processCallbackConfigurations = await _processCallbackConfigurationRepository.GetQueryable().Where(filter).ToDynamicListAsync<ProcessCallbackConfiguration>();
            var processCallbackConfigurationDtos = ObjectMapper.Map<List<ProcessCallbackConfiguration>, List<ProcessCallbackConfigurationDto>>(processCallbackConfigurations);
            return QueryResult.FromData(processCallbackConfigurationDtos);
        }
    }
}
