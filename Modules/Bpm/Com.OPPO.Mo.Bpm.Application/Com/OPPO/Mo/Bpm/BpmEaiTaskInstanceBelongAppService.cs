using Com.OPPO.Mo.Bpm.Dtos;
using Com.OPPO.Mo.Bpm.Repositories;
using Com.OPPO.Mo.Queriable;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;

namespace Com.OPPO.Mo.Bpm
{
    /// <summary>
    /// Bpm Eai任务实例归属应用服务
    /// </summary>
    [Authorize]
    public class BpmEaiTaskInstanceBelongAppService : BpmAppServiceBase, IBpmEaiTaskInstanceBelongAppService
    {
        private readonly IEaiTaskInstanceBelongRepository _eaiTaskInstanceBelongRepository;

        /// <summary>
        /// <see cref="BpmEaiTaskInstanceBelongAppService"/>
        /// </summary>
        public BpmEaiTaskInstanceBelongAppService(IEaiTaskInstanceBelongRepository eaiTaskInstanceBelongRepository)
        {
            _eaiTaskInstanceBelongRepository = eaiTaskInstanceBelongRepository;
        }

        /// <inheritdoc/>
        public async Task<Result<EaiTaskInstanceBelongDto>> GrantEaiTaskInstanceBelong(string eaiTaskInstanceId, string appId)
        {
            var prototypeEaiTaskInstanceBelongs = await _eaiTaskInstanceBelongRepository.GetQueryable()
                .Where(x => x.EaiTaskInstanceId == eaiTaskInstanceId)
                .ToDynamicArrayAsync<EaiTaskInstanceBelong>();
            if (!prototypeEaiTaskInstanceBelongs.Any())
                return Result.FromError<EaiTaskInstanceBelongDto>($"系统中无【{eaiTaskInstanceId}】对应的Eai任务");
            else if (prototypeEaiTaskInstanceBelongs.Any(x => x.AppId == appId))
                return Result.FromError<EaiTaskInstanceBelongDto>($"Eai任务【{eaiTaskInstanceId}】已经归属于应用【{appId}】");
            else
            {
                var prototypeEaiTaskInstanceBelong = prototypeEaiTaskInstanceBelongs.First();
                var eaiTaskInstanceBelong = new EaiTaskInstanceBelong
                {
                    AppId = appId,
                    EaiTaskInstanceId = eaiTaskInstanceId,
                    EaiTaskBizId = prototypeEaiTaskInstanceBelong.EaiTaskBizId,
                    EaiTaskTitle = prototypeEaiTaskInstanceBelong.EaiTaskTitle
                };

                eaiTaskInstanceBelong = await _eaiTaskInstanceBelongRepository.InsertAsync(eaiTaskInstanceBelong);
                var eaiTaskInstanceBelongDto = ObjectMapper.Map<EaiTaskInstanceBelong, EaiTaskInstanceBelongDto>(eaiTaskInstanceBelong);

                return Result.FromData(eaiTaskInstanceBelongDto);
            }
        }

        /// <inheritdoc/>

        public async Task<Result<EaiTaskInstanceBelongDto>> GetEaiTaskInstanceBelong(Guid belongId)
        {
            var eaiTaskInstanceBelong = await _eaiTaskInstanceBelongRepository.GetAsync(belongId);
            var eaiTaskInstanceBelongDto = ObjectMapper.Map<EaiTaskInstanceBelong, EaiTaskInstanceBelongDto>(eaiTaskInstanceBelong);

            return Result.FromData(eaiTaskInstanceBelongDto);
        }

        /// <inheritdoc/>
        public async Task<Result> RevokeEaiTaskInstanceBelong(Guid belongId)
        {
            await _eaiTaskInstanceBelongRepository.DeleteAsync(belongId);

            return Result.Ok();
        }

        /// <inheritdoc/>
        public async Task<QueryResult<EaiTaskInstanceBelongDto>> QueryEaiTaskInstanceBelong(EaiTaskInstanceBelongQueryInput eaiTaskInstanceBelongPageQueryInput)
        {
            var filter = new Query<EaiTaskInstanceBelong>().GetFilter();
            if (!string.IsNullOrWhiteSpace(eaiTaskInstanceBelongPageQueryInput.AppId))
                filter = filter.And(x => x.AppId == eaiTaskInstanceBelongPageQueryInput.AppId);
            if (!string.IsNullOrWhiteSpace(eaiTaskInstanceBelongPageQueryInput.EaiTaskInstanceId))
                filter = filter.And(x => x.EaiTaskInstanceId == eaiTaskInstanceBelongPageQueryInput.EaiTaskInstanceId);
            if (!string.IsNullOrWhiteSpace(eaiTaskInstanceBelongPageQueryInput.EaiTaskBizId))
                filter = filter.And(x => x.EaiTaskBizId == eaiTaskInstanceBelongPageQueryInput.EaiTaskBizId);
            if (!string.IsNullOrWhiteSpace(eaiTaskInstanceBelongPageQueryInput.EaiTaskTitle))
                filter = filter.And(x => x.EaiTaskTitle.Contains(eaiTaskInstanceBelongPageQueryInput.EaiTaskTitle));
            if (eaiTaskInstanceBelongPageQueryInput.CreationTimeFrom.HasValue)
                filter = filter.And(x => x.CreationTime >= eaiTaskInstanceBelongPageQueryInput.CreationTimeFrom.Value);
            if (eaiTaskInstanceBelongPageQueryInput.CreationTimeTo.HasValue)
                filter = filter.And(x => x.CreationTime <= eaiTaskInstanceBelongPageQueryInput.CreationTimeTo.Value);

            var eaiTaskInstanceBelongs = await _eaiTaskInstanceBelongRepository.GetQueryable().Where(filter).ToDynamicListAsync<EaiTaskInstanceBelong>();
            var eaiTaskInstanceBelongDtos = ObjectMapper.Map<List<EaiTaskInstanceBelong>, List<EaiTaskInstanceBelongDto>>(eaiTaskInstanceBelongs);

            return QueryResult.FromData(eaiTaskInstanceBelongDtos);
        }

        /// <inheritdoc/>
        public async Task<PageQueryResult<EaiTaskInstanceBelongDto>> PageQueryEaiTaskInstanceBelong(EaiTaskInstanceBelongPageQueryInput eaiTaskInstanceBelongPageQueryInput)
        {
            var filter = new Query<EaiTaskInstanceBelong>().GetFilter();
            if (!string.IsNullOrWhiteSpace(eaiTaskInstanceBelongPageQueryInput.AppId))
                filter = filter.And(x => x.AppId == eaiTaskInstanceBelongPageQueryInput.AppId);
            if (!string.IsNullOrWhiteSpace(eaiTaskInstanceBelongPageQueryInput.EaiTaskInstanceId))
                filter = filter.And(x => x.EaiTaskInstanceId == eaiTaskInstanceBelongPageQueryInput.EaiTaskInstanceId);
            if (!string.IsNullOrWhiteSpace(eaiTaskInstanceBelongPageQueryInput.EaiTaskBizId))
                filter = filter.And(x => x.EaiTaskBizId == eaiTaskInstanceBelongPageQueryInput.EaiTaskBizId);
            if (!string.IsNullOrWhiteSpace(eaiTaskInstanceBelongPageQueryInput.EaiTaskTitle))
                filter = filter.And(x => x.EaiTaskTitle.Contains(eaiTaskInstanceBelongPageQueryInput.EaiTaskTitle));
            if (eaiTaskInstanceBelongPageQueryInput.CreationTimeFrom.HasValue)
                filter = filter.And(x => x.CreationTime >= eaiTaskInstanceBelongPageQueryInput.CreationTimeFrom.Value);
            if (eaiTaskInstanceBelongPageQueryInput.CreationTimeTo.HasValue)
                filter = filter.And(x => x.CreationTime <= eaiTaskInstanceBelongPageQueryInput.CreationTimeTo.Value);

            var totalCount = _eaiTaskInstanceBelongRepository.GetQueryable().Where(filter).Count();
            var eaiTaskInstanceBelongs = await _eaiTaskInstanceBelongRepository.GetQueryable().Where(filter)
               .Skip(eaiTaskInstanceBelongPageQueryInput.Offset)
               .Take(eaiTaskInstanceBelongPageQueryInput.Count)
               .ToDynamicListAsync<EaiTaskInstanceBelong>();
            var eaiTaskInstanceBelongDtos = ObjectMapper.Map<List<EaiTaskInstanceBelong>, List<EaiTaskInstanceBelongDto>>(eaiTaskInstanceBelongs);

            return PageQueryResult.FromData(eaiTaskInstanceBelongDtos, totalCount, (IPageInfo)eaiTaskInstanceBelongPageQueryInput);
        }
    }
}
