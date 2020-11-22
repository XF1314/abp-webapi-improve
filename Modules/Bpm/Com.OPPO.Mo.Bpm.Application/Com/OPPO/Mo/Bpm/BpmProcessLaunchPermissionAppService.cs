using Com.OPPO.Mo.Bpm.Dtos;
using Com.OPPO.Mo.Bpm.Repositories;
using Com.OPPO.Mo.Queriable;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Com.OPPO.Mo.Bpm
{
    /// <summary>
    /// Bpm流程发起权限应用服务
    /// </summary>
    [Authorize]
    public class BpmProcessLaunchPermissionAppService : BpmAppServiceBase, IBpmProcessLaunchPermissionAppService
    {
        private readonly IProcessLaunchPermissionRepository _processLaunchPermissionRepository;

        /// <summary>
        /// <see cref="BpmProcessLaunchPermissionAppService"/>
        /// </summary>
        public BpmProcessLaunchPermissionAppService(IProcessLaunchPermissionRepository processLaunchPermissionRepository)
        {
            _processLaunchPermissionRepository = processLaunchPermissionRepository;
        }

        /// <inheritdoc/>
        public async Task<Result<ProcessLaunchPermissionDto>> GrantProcessLaunchPermission(ProcessLaunchPermissionGrantInput processLaunchPermissionGrantInput)
        {
            var processLaunchPermission = await _processLaunchPermissionRepository.GetProcessLaunchPermission(processLaunchPermissionGrantInput.AppId, processLaunchPermissionGrantInput.ProcessDefinitionId);
            if (processLaunchPermission != null)
            {
                processLaunchPermission.IsValid = true;
                await _processLaunchPermissionRepository.UpdateAsync(processLaunchPermission);
            }
            else
            {
                processLaunchPermission = ObjectMapper.Map<ProcessLaunchPermissionGrantInput, ProcessLaunchPermission>(processLaunchPermissionGrantInput);
                processLaunchPermission = await _processLaunchPermissionRepository.InsertAsync(processLaunchPermission);
            }

            return Result.Ok(ObjectMapper.Map<ProcessLaunchPermission, ProcessLaunchPermissionDto>(processLaunchPermission));

        }

        /// <inheritdoc/>
        public async Task<Result<List<ProcessLaunchPermissionDto>>> BatchGrantProcessLaunchPermission(ProcessLaunchPermissionBatchGrantInput processLaunchPermissionBatchGrantInput)
        {
            if (!processLaunchPermissionBatchGrantInput.ProcesseDefinitions.Any())
                return Result.FromCode<List<ProcessLaunchPermissionDto>>(ResultCode.InvalidParams, $"参数【{nameof(processLaunchPermissionBatchGrantInput.ProcesseDefinitions)}】不能为空");

            var filter = new Query<ProcessLaunchPermission>().GetFilter();
            filter = filter.And(x => x.AppId == processLaunchPermissionBatchGrantInput.AppId && processLaunchPermissionBatchGrantInput.ProcesseDefinitions.Keys.Contains(x.ProcessDefinitionId));
            var existedProcessLaunchPermissions = await _processLaunchPermissionRepository.GetQueryable().Where(filter).ToDynamicListAsync<ProcessLaunchPermission>();
            var processLaunchPermissionUpsertTasks = new List<Task<ProcessLaunchPermission>>();
            processLaunchPermissionBatchGrantInput.ProcesseDefinitions.ToList().ForEach(x =>
            {
                var existedProcessLaunchPermission = existedProcessLaunchPermissions.FirstOrDefault(y => y.ProcessDefinitionId == x.Key);
                if (existedProcessLaunchPermission is null)
                    processLaunchPermissionUpsertTasks.Add(_processLaunchPermissionRepository.InsertAsync(new ProcessLaunchPermission
                    {
                        ProcessDefinitionId = x.Key,
                        ProcessName = x.Value,
                        AppId = processLaunchPermissionBatchGrantInput.AppId,
                        AppName = processLaunchPermissionBatchGrantInput.AppName
                    }));
                else
                {
                    existedProcessLaunchPermission.IsValid = true;
                    existedProcessLaunchPermission.ProcessName = x.Value;
                    existedProcessLaunchPermission.AppName = processLaunchPermissionBatchGrantInput.AppName;
                    processLaunchPermissionUpsertTasks.Add(_processLaunchPermissionRepository.UpdateAsync(existedProcessLaunchPermission));
                }
            });

            var upsertedProcessLaunchPermissions = await Task.WhenAll(processLaunchPermissionUpsertTasks.ToArray());
            var processLaunchPermissionDtos = ObjectMapper.Map<List<ProcessLaunchPermission>, List<ProcessLaunchPermissionDto>>(upsertedProcessLaunchPermissions.ToList());

            return Result.FromData(processLaunchPermissionDtos);
        }

        /// <inheritdoc/>
        public async Task<Result<ProcessLaunchPermissionDto>> InvalidateProcessLaunchPermission(string appId, string processDefinitionId)
        {
            var processLaunchPermission = _processLaunchPermissionRepository.GetQueryable().Where(x => x.AppId == appId && x.ProcessDefinitionId == processDefinitionId).FirstOrDefault();
            if (processLaunchPermission is null)
                return Result.FromCode<ProcessLaunchPermissionDto>(ResultCode.Fail, $"系统中无应用【{appId}】,流程【{processDefinitionId}】对应的流程发起权限配置记录");
            else
            {
                processLaunchPermission.IsValid = false;
                processLaunchPermission = await _processLaunchPermissionRepository.UpdateAsync(processLaunchPermission);
                var processLaunchPermissionDto = ObjectMapper.Map<ProcessLaunchPermission, ProcessLaunchPermissionDto>(processLaunchPermission);

                return Result.FromData(processLaunchPermissionDto);
            }
        }

        /// <inheridoc/>
        public async Task<Result<ProcessLaunchPermissionDto>> InvalidateProcessLaunchPermission(Guid permissionId)
        {
            var processLaunchPermission = await _processLaunchPermissionRepository.FindAsync(permissionId);
            if (processLaunchPermission is null)
                return Result.FromCode<ProcessLaunchPermissionDto>(ResultCode.Fail, $"系统中无【{permissionId}】对应的流程发起权限配置记录");
            else
            {
                processLaunchPermission.IsValid = false;
                processLaunchPermission = await _processLaunchPermissionRepository.UpdateAsync(processLaunchPermission);
                var processLaunchPermissionDto = ObjectMapper.Map<ProcessLaunchPermission, ProcessLaunchPermissionDto>(processLaunchPermission);

                return Result.FromData(processLaunchPermissionDto);
            }
        }

        /// <inheritdoc/>
        public async Task<Result<ProcessLaunchPermissionDto>> ValidateProcessLaunchPermission(string appId, string processDefinitionId)
        {
            var processLaunchPermission = _processLaunchPermissionRepository.GetQueryable().Where(x => x.AppId == appId && x.ProcessDefinitionId == processDefinitionId).FirstOrDefault();
            if (processLaunchPermission is null)
                return Result.FromCode<ProcessLaunchPermissionDto>(ResultCode.Fail, $"系统中无应用【{appId}】,流程【{processDefinitionId}】对应的流程发起权限配置记录");
            else
            {
                processLaunchPermission.IsValid = true;
                processLaunchPermission = await _processLaunchPermissionRepository.UpdateAsync(processLaunchPermission);
                var processLaunchPermissionDto = ObjectMapper.Map<ProcessLaunchPermission, ProcessLaunchPermissionDto>(processLaunchPermission);

                return Result.FromData(processLaunchPermissionDto);
            }
        }

        /// <inheridoc/>
        public async Task<Result<ProcessLaunchPermissionDto>> ValidateProcessLaunchPermission(Guid permissionId)
        {
            var processLaunchPermission = await _processLaunchPermissionRepository.FindAsync(permissionId);
            if (processLaunchPermission is null)
                return Result.FromCode<ProcessLaunchPermissionDto>(ResultCode.Fail, $"系统中【{permissionId}】对应的流程发起权限配置记录");
            else
            {
                processLaunchPermission.IsValid = true;
                processLaunchPermission = await _processLaunchPermissionRepository.UpdateAsync(processLaunchPermission);
                var processLaunchPermissionDto = ObjectMapper.Map<ProcessLaunchPermission, ProcessLaunchPermissionDto>(processLaunchPermission);

                return Result.FromData(processLaunchPermissionDto);
            }
        }

        /// <inheritdoc/>
        public async Task<Result> RevokeProcessLaunchPermission(Guid permissionId)
        {
            await _processLaunchPermissionRepository.DeleteAsync(permissionId);

            return Result.Ok();
        }

        /// <inheridoc/>
        public async Task<Result<List<ProcessLaunchPermissionDto>>> QueryProcessLaunchPermission(ProcessLaunchPermissionQueryInput processLaunchPermissionQueryInput)
        {
            var filter = new Query<ProcessLaunchPermission>().GetFilter();
            if (!string.IsNullOrWhiteSpace(processLaunchPermissionQueryInput.AppId))
              filter =  filter.And(x => x.AppId == processLaunchPermissionQueryInput.AppId);
            if (!string.IsNullOrWhiteSpace(processLaunchPermissionQueryInput.ProcessDefinitionId))
                filter= filter.And(x => x.ProcessDefinitionId == processLaunchPermissionQueryInput.ProcessDefinitionId);
            if (processLaunchPermissionQueryInput.IsValid.HasValue)
                filter= filter.And(x => x.IsValid == processLaunchPermissionQueryInput.IsValid.Value);

            var processLaunchPermissions = await _processLaunchPermissionRepository.GetQueryable().Where(filter).ToDynamicListAsync<ProcessLaunchPermission>();
            var processLaunchPermissionDtos = ObjectMapper.Map<List<ProcessLaunchPermission>, List<ProcessLaunchPermissionDto>>(processLaunchPermissions);

            return Result.FromData(processLaunchPermissionDtos);
        }

        /// <inheritdoc/>
        public async Task<Result<List<ProcessLaunchPermissionDto>>> GetAllProcessLaunchPermission()
        {
            var processLaunchPermissions = await _processLaunchPermissionRepository.GetListAsync();
            var processLaunchPermissionDtos = ObjectMapper.Map<List<ProcessLaunchPermission>, List<ProcessLaunchPermissionDto>>(processLaunchPermissions);

            return Result.FromData(processLaunchPermissionDtos);
        }

        /// <inheritdoc/>
        public async Task<Result<ProcessLaunchPermissionDto>> GetProcessLaunchPermission(Guid permissionId)
        {
            var processLauchPermission = await _processLaunchPermissionRepository.GetAsync(permissionId);
            if (processLauchPermission is null)
                return Result.FromCode<ProcessLaunchPermissionDto>(ResultCode.NoData);
            else
            {
                var processLauchPermissionDto = ObjectMapper.Map<ProcessLaunchPermission, ProcessLaunchPermissionDto>(processLauchPermission);
                return Result.FromData(processLauchPermissionDto);
            }
        }
    }
}
