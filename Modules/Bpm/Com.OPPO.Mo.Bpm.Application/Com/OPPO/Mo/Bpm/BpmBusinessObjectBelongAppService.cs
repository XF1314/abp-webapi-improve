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
    /// Bpm业务对象归属应用服务
    /// </summary>
    [Authorize]
    public class BpmBusinessObjectBelongAppService : BpmAppServiceBase, IBpmBusinessObjectBelongAppService
    {
        private readonly IBusinessObjectBelongRepository _businessObjectBelongRepository;

        /// <summary>
        /// <see cref="BpmBusinessObjectBelongAppService"/>
        /// </summary>
        public BpmBusinessObjectBelongAppService(IBusinessObjectBelongRepository businessObjectBelongRepository)
        {
            _businessObjectBelongRepository = businessObjectBelongRepository;
        }

        /// <inheritdoc/>
        public async Task<Result<BusinessObjectBelongDto>> GrantBusinessObjectBelong(string businessObjectId, string appId)
        {
            var prototypeBusinessObjectBelongs = await _businessObjectBelongRepository.GetQueryable()
                .Where(x => x.BusinessObjectId == businessObjectId)
                .ToDynamicListAsync<BusinessObjectBelong>();
            if (!prototypeBusinessObjectBelongs.Any())
                return Result.FromError<BusinessObjectBelongDto>($"系统中无【{businessObjectId}】对应的业务对象");
            else if (prototypeBusinessObjectBelongs.Any(x => x.AppId == appId))
                return Result.FromError<BusinessObjectBelongDto>($"业务对象【{businessObjectId}】已经归属于应用【{appId}】");
            else
            {
                var prototypeBusinessObjectBelong = prototypeBusinessObjectBelongs.First();
                var businessObjectBelong = new BusinessObjectBelong
                {
                    BusinessObjectId = businessObjectId,
                    BusinessObjectTableName = prototypeBusinessObjectBelong.BusinessObjectTableName,
                    ProcessInstanceId = prototypeBusinessObjectBelong.ProcessInstanceId,
                    AppId = appId
                };
                businessObjectBelong = await _businessObjectBelongRepository.InsertAsync(businessObjectBelong);
                var businessObjectBelongDto = ObjectMapper.Map<BusinessObjectBelong, BusinessObjectBelongDto>(businessObjectBelong);

                return Result.FromData(businessObjectBelongDto);
            }
        }

        /// <inheritdoc/>
        public async Task<Result<BusinessObjectBelongDto>> GetBusinessObjectBelong(Guid belongId)
        {
            var businessObjectBelong = await _businessObjectBelongRepository.GetAsync(belongId);
            if (businessObjectBelong is null)
                return Result.FromCode<BusinessObjectBelongDto>(ResultCode.NoData, $"系统中无【{belongId}】对应的业务对象归属");
            else
            {
                var businessObjectBelongDto = ObjectMapper.Map<BusinessObjectBelong, BusinessObjectBelongDto>(businessObjectBelong);
                return Result.FromData(businessObjectBelongDto);
            }
        }

        /// <inheritdoc/>
        public async Task<Result> DeleteBusinessObjectBelong(Guid belongId)
        {
            await _businessObjectBelongRepository.DeleteAsync(belongId);
            return Result.Ok();
        }

        /// <inheritdoc/>

        public async Task<Result<List<BusinessObjectBelongDto>>> QueryBusinessObjectBelong(BusinessObjectBelongQueryInput businessObjectBelongQueryInput)
        {
            var filter = new Query<BusinessObjectBelong>().GetFilter();
            if (!string.IsNullOrWhiteSpace(businessObjectBelongQueryInput.AppId))
                filter = filter.And(x => x.AppId == businessObjectBelongQueryInput.AppId);
            if (!string.IsNullOrWhiteSpace(businessObjectBelongQueryInput.BusinessObjectId))
                filter = filter.And(x => x.BusinessObjectId == businessObjectBelongQueryInput.BusinessObjectId);
            if (!string.IsNullOrWhiteSpace(businessObjectBelongQueryInput.BusinessObjectTableName))
                filter = filter.And(x => x.BusinessObjectTableName.Contains(businessObjectBelongQueryInput.BusinessObjectTableName));
            if (!string.IsNullOrWhiteSpace(businessObjectBelongQueryInput.ProcessInstanceId))
                filter = filter.And(x => x.ProcessInstanceId == businessObjectBelongQueryInput.ProcessInstanceId);
            if (businessObjectBelongQueryInput.CreationTimeFrom.HasValue)
                filter = filter.And(x => x.CreationTime >= businessObjectBelongQueryInput.CreationTimeFrom);
            if (businessObjectBelongQueryInput.CreationTimeTo.HasValue)
                filter = filter.And(x => x.CreationTime <= businessObjectBelongQueryInput.CreationTimeTo);

            var businessObjectBelongDtos = await _businessObjectBelongRepository.GetQueryable().Where(filter).ToDynamicListAsync<BusinessObjectBelongDto>();
            return Result.FromData(businessObjectBelongDtos);
        }

        /// <inheritdoc/>

        public async Task<PageQueryResult<BusinessObjectBelongDto>> PageQueryBusinessObjectBelong(BusinessObjectBelongPageQueryInput businessObjectBelongPageQueryInput)
        {
            var filter = new Query<BusinessObjectBelong>().GetFilter();
            if (!string.IsNullOrWhiteSpace(businessObjectBelongPageQueryInput.AppId))
                filter = filter.And(x => x.AppId == businessObjectBelongPageQueryInput.AppId);
            if (!string.IsNullOrWhiteSpace(businessObjectBelongPageQueryInput.BusinessObjectId))
                filter = filter.And(x => x.BusinessObjectId == businessObjectBelongPageQueryInput.BusinessObjectId);
            if (!string.IsNullOrWhiteSpace(businessObjectBelongPageQueryInput.BusinessObjectTableName))
                filter = filter.And(x => x.BusinessObjectTableName.Contains(businessObjectBelongPageQueryInput.BusinessObjectTableName));
            if (!string.IsNullOrWhiteSpace(businessObjectBelongPageQueryInput.ProcessInstanceId))
                filter = filter.And(x => x.ProcessInstanceId == businessObjectBelongPageQueryInput.ProcessInstanceId);
            if (businessObjectBelongPageQueryInput.CreationTimeFrom.HasValue)
                filter = filter.And(x => x.CreationTime >= businessObjectBelongPageQueryInput.CreationTimeFrom);
            if (businessObjectBelongPageQueryInput.CreationTimeTo.HasValue)
                filter = filter.And(x => x.CreationTime <= businessObjectBelongPageQueryInput.CreationTimeTo);

            var totalCount = _businessObjectBelongRepository.GetQueryable().Where(filter).Count(filter);
            var businessObjectBelongDtos =await _businessObjectBelongRepository.GetQueryable()
                .Where(filter).Skip(businessObjectBelongPageQueryInput.Offset)
                .Take(businessObjectBelongPageQueryInput.Count)
                .ToDynamicListAsync<BusinessObjectBelongDto>();

            return PageQueryResult.FromData(businessObjectBelongDtos, totalCount, (IPageInfo)businessObjectBelongPageQueryInput);
        }
    }
}
