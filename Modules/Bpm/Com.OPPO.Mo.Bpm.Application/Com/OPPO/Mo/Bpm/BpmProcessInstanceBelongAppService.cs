using Com.OPPO.Mo.Bpm.Dtos;
using Com.OPPO.Mo.Queriable;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Com.OPPO.Mo.Bpm
{
    /// <summary>
    /// Bpm流程实例归属应用服务
    /// </summary>
    [Authorize]
    public class BpmProcessInstanceBelongAppService : BpmAppServiceBase, IBpmProcessInstanceBelongAppService
    {
        /// <inheritdoc/>
        public async Task<Result<ProcessInstanceBelongDto>> GrantProcessInstanceBelong(string processInstanceId, string appId)
        {
            var prototypeProcessInstanceBelongs = await ProcessInstanceBelongRepository.GetQueryable()
                .Where(x => x.ProcessInstanceId == processInstanceId)
                .ToDynamicListAsync<ProcessInstanceBelong>();
            if (!prototypeProcessInstanceBelongs.Any())
                return Result.FromError<ProcessInstanceBelongDto>($"系统中无【{processInstanceId}】对应的流程实例");
            else if (prototypeProcessInstanceBelongs.Any(x => x.AppId == appId))
                return Result.FromError<ProcessInstanceBelongDto>($"流程实例【{processInstanceId}】已经归属于应用【{appId}】");
            else
            {
                var prototypeProcessInstanceBelong = prototypeProcessInstanceBelongs.First();
                var processInstanceBelong = new ProcessInstanceBelong
                {
                    AppId = appId,
                    ProcessInstanceId = prototypeProcessInstanceBelong.ProcessInstanceId,
                    ProcessInstanceCode = prototypeProcessInstanceBelong.ProcessInstanceCode,
                    ProcessTitle = prototypeProcessInstanceBelong.ProcessTitle
                };

                processInstanceBelong = await ProcessInstanceBelongRepository.InsertAsync(processInstanceBelong);
                var processInstanceBelongDto = ObjectMapper.Map<ProcessInstanceBelong, ProcessInstanceBelongDto>(processInstanceBelong);

                return Result.FromData(processInstanceBelongDto);
            }
        }

        /// <inheritdoc/>
        public async Task<Result<ProcessInstanceBelongDto>> GetProcessInstanceBelong(Guid belongId)
        {
            var processInstanceBelong = await ProcessInstanceBelongRepository.GetAsync(belongId);
            var processInstanceBelongDto = ObjectMapper.Map<ProcessInstanceBelong, ProcessInstanceBelongDto>(processInstanceBelong);

            return Result.FromData(processInstanceBelongDto);
        }

        /// <inheritdoc/>
        public async Task<Result> RevokeProcessInstanceBelong(Guid belongId)
        {
            await ProcessInstanceBelongRepository.DeleteAsync(belongId);

            return Result.Ok();
        }

        /// <inheritdoc/>
        public async Task<QueryResult<ProcessInstanceBelongDto>> QueryProcessInstanceBelong(ProcessInstanceBelongQueryInput processInstanceBelongQueryInput)
        {
            var filter = new Query<ProcessInstanceBelong>().GetFilter();
            if (!string.IsNullOrWhiteSpace(processInstanceBelongQueryInput.ProcessInstanceId))
                filter = filter.And(x => x.ProcessInstanceId == processInstanceBelongQueryInput.ProcessInstanceId);
            if (!string.IsNullOrWhiteSpace(processInstanceBelongQueryInput.ProcessInstanceCode))
                filter = filter.And(x => x.ProcessInstanceCode == processInstanceBelongQueryInput.ProcessInstanceCode);
            if (!string.IsNullOrWhiteSpace(processInstanceBelongQueryInput.ProcessTitle))
                filter = filter.And(x => x.ProcessTitle.Contains(processInstanceBelongQueryInput.ProcessTitle));
            if (!string.IsNullOrWhiteSpace(processInstanceBelongQueryInput.AppId))
                filter = filter.And(x => x.AppId == processInstanceBelongQueryInput.AppId);
            if (processInstanceBelongQueryInput.IsDeleted.HasValue)
                filter = filter.And(x => x.IsDeleted == processInstanceBelongQueryInput.IsDeleted.Value);
            if (processInstanceBelongQueryInput.CreationTimeFrom.HasValue)
                filter = filter.And(x => x.CreationTime >= processInstanceBelongQueryInput.CreationTimeFrom.Value);
            if (processInstanceBelongQueryInput.CreationTimeTo.HasValue)
                filter = filter.And(x => x.CreationTime <= processInstanceBelongQueryInput.CreationTimeTo.Value);

            var processInstanceBelongs = await ProcessInstanceBelongRepository.GetQueryable().Where(filter).ToDynamicListAsync<ProcessInstanceBelong>();
            var processInstanceBelongDtos = ObjectMapper.Map<List<ProcessInstanceBelong>, List<ProcessInstanceBelongDto>>(processInstanceBelongs);

            return QueryResult.FromData(processInstanceBelongDtos);
        }

        /// <inheritdoc/>
        public async Task<PageQueryResult<ProcessInstanceBelongDto>> PageQueryProcessInstanceBelong(ProcessInstanceBelongPageQueryInput processInstanceBelongPageQueryInput)
        {
            var filter = new Query<ProcessInstanceBelong>().GetFilter();
            if (!string.IsNullOrWhiteSpace(processInstanceBelongPageQueryInput.ProcessInstanceId))
                filter = filter.And(x => x.ProcessInstanceId == processInstanceBelongPageQueryInput.ProcessInstanceId);
            if (!string.IsNullOrWhiteSpace(processInstanceBelongPageQueryInput.ProcessInstanceCode))
                filter = filter.And(x => x.ProcessInstanceCode == processInstanceBelongPageQueryInput.ProcessInstanceCode);
            if (!string.IsNullOrWhiteSpace(processInstanceBelongPageQueryInput.ProcessTitle))
                filter = filter.And(x => x.ProcessTitle.Contains(processInstanceBelongPageQueryInput.ProcessTitle));
            if (!string.IsNullOrWhiteSpace(processInstanceBelongPageQueryInput.AppId))
                filter = filter.And(x => x.AppId == processInstanceBelongPageQueryInput.AppId);
            if (processInstanceBelongPageQueryInput.IsDeleted.HasValue)
                filter = filter.And(x => x.IsDeleted == processInstanceBelongPageQueryInput.IsDeleted.Value);
            if (processInstanceBelongPageQueryInput.CreationTimeFrom.HasValue)
                filter = filter.And(x => x.CreationTime >= processInstanceBelongPageQueryInput.CreationTimeFrom.Value);
            if (processInstanceBelongPageQueryInput.CreationTimeTo.HasValue)
                filter = filter.And(x => x.CreationTime <= processInstanceBelongPageQueryInput.CreationTimeTo.Value);

            var totalCount = ProcessInstanceBelongRepository.GetQueryable().Where(filter).Count();
            var processInstanceBelongs = await ProcessInstanceBelongRepository.GetQueryable()
                .Where(filter).Skip(processInstanceBelongPageQueryInput.Offset).Take(processInstanceBelongPageQueryInput.Count)
                .ToDynamicListAsync<ProcessInstanceBelong>();
            var processInstanceBelongDtos = ObjectMapper.Map<List<ProcessInstanceBelong>, List<ProcessInstanceBelongDto>>(processInstanceBelongs);

            return PageQueryResult.FromData(processInstanceBelongDtos, totalCount, (IPageInfo)processInstanceBelongPageQueryInput);
        }

    }
}
