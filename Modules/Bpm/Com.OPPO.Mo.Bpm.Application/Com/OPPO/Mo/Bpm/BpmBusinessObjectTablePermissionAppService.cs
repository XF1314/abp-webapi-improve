using Com.OPPO.Mo.Bpm.Dtos;
using Com.OPPO.Mo.Bpm.Repositories;
using Com.OPPO.Mo.Queriable;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Bpm
{
    /// <summary>
    /// Bpm业务对象表权限应用服务
    /// </summary>
    [Authorize]
    public class BpmBusinessObjectTablePermissionAppService : BpmAppServiceBase, IBpmBusinessObjectTablePermissionAppService
    {
        private readonly IBusinessObjectTablePermissionRepository _businessObjectTablePermissionRepository;

        /// <summary>
        /// <see cref="BpmBusinessObjectTablePermissionAppService"/>
        /// </summary>
        public BpmBusinessObjectTablePermissionAppService(IBusinessObjectTablePermissionRepository businessObjectSetPermissionRepository)
        {
            _businessObjectTablePermissionRepository = businessObjectSetPermissionRepository;
        }

        /// <inheritdoc/>
        public async Task<Result<BusinessObjectTablePermissionDto>> GrantBusinessObjectTablePermission(BusinessObjectTablePermissionGrantInput businessObjectTablePermissionGrantInput)
        {
            var businessObjectTablePermission = await _businessObjectTablePermissionRepository.GetBusinessObjectTablePermission(businessObjectTablePermissionGrantInput.AppId, businessObjectTablePermissionGrantInput.BusinessObjectTableName);
            if (businessObjectTablePermission != null)
            {
                businessObjectTablePermission.IsValid = true;
                businessObjectTablePermission = await _businessObjectTablePermissionRepository.UpdateAsync(businessObjectTablePermission);
            }
            else
            {
                businessObjectTablePermission = ObjectMapper.Map<BusinessObjectTablePermissionGrantInput, BusinessObjectTablePermission>(businessObjectTablePermissionGrantInput);
                businessObjectTablePermission = await _businessObjectTablePermissionRepository.InsertAsync(businessObjectTablePermission);
            }

            return Result.Ok(ObjectMapper.Map<BusinessObjectTablePermission, BusinessObjectTablePermissionDto>(businessObjectTablePermission));
        }

        /// <inheritdoc/>
        public async Task<Result<List<BusinessObjectTablePermissionDto>>> BatchGrantBusinessObjectTablePermission(BusinessObjectTablePermissionBatchGrantInput objectTablePermissionBatchGrantInput)
        {
            if (!objectTablePermissionBatchGrantInput.BusinessObjectTableNames.Any())
                return Result.FromCode<List<BusinessObjectTablePermissionDto>>(ResultCode.InvalidParams, $"参数【{objectTablePermissionBatchGrantInput.BusinessObjectTableNames}】不能为空");

            var existedBusinessObjectTablePermissions = await _businessObjectTablePermissionRepository.GetQueryable()
                .Where(x => x.AppId == objectTablePermissionBatchGrantInput.AppId && objectTablePermissionBatchGrantInput.BusinessObjectTableNames.Contains(x.BusinessObjectTableName))
                .ToDynamicListAsync<BusinessObjectTablePermission>();
            var businessObjectTablePermissionUpsertTask = new List<Task<BusinessObjectTablePermission>>();
            objectTablePermissionBatchGrantInput.BusinessObjectTableNames.ForEach(x =>
            {
                var existedBusinessObjectTablePermission = existedBusinessObjectTablePermissions.FirstOrDefault(y => y.BusinessObjectTableName == x);
                if (existedBusinessObjectTablePermission is null)
                    businessObjectTablePermissionUpsertTask.Add(_businessObjectTablePermissionRepository.InsertAsync(new BusinessObjectTablePermission
                    {
                        AppId = objectTablePermissionBatchGrantInput.AppId,
                        AppName = objectTablePermissionBatchGrantInput.AppName,
                        BusinessObjectTableName = x
                    }));
                else
                {
                    existedBusinessObjectTablePermission.AppName = objectTablePermissionBatchGrantInput.AppName;
                    existedBusinessObjectTablePermission.IsValid = true;
                    businessObjectTablePermissionUpsertTask.Add(_businessObjectTablePermissionRepository.UpdateAsync(existedBusinessObjectTablePermission));
                }
            });

            var upsertedBusinessObjectTablePermissions = await Task.WhenAll(businessObjectTablePermissionUpsertTask.ToArray());
            var businessObjectTablePermissionDtos = ObjectMapper.Map<List<BusinessObjectTablePermission>, List<BusinessObjectTablePermissionDto>>(upsertedBusinessObjectTablePermissions.ToList());

            return Result.FromData(businessObjectTablePermissionDtos);
        }

        /// <inheritdoc/>
        public async Task<Result<BusinessObjectTablePermissionDto>> InvalidateBusinessObjectTablePermission(string appId, string businessObjectTableName)
        {
            var businessObjectTablePermission = _businessObjectTablePermissionRepository.GetQueryable().Where(x => x.AppId == appId && x.BusinessObjectTableName == businessObjectTableName).FirstOrDefault();
            if (businessObjectTablePermission is null)
                return Result.FromCode<BusinessObjectTablePermissionDto>(ResultCode.Fail, $"系统中无应用【{appId}】,业务对象表【{businessObjectTableName}】对应的业务对象表权限配置记录");
            else
            {
                businessObjectTablePermission.IsValid = false;
                businessObjectTablePermission = await _businessObjectTablePermissionRepository.UpdateAsync(businessObjectTablePermission);
                var businessObjectTablePermissionDto = ObjectMapper.Map<BusinessObjectTablePermission, BusinessObjectTablePermissionDto>(businessObjectTablePermission);

                return Result.FromData(businessObjectTablePermissionDto);
            }
        }

        /// inheritdoc/>
        public async Task<Result<BusinessObjectTablePermissionDto>> InvalidateBusinessObjectTablePermission(Guid permissionId)
        {
            var businessObjectTablePermission = await _businessObjectTablePermissionRepository.FindAsync(permissionId);
            if (businessObjectTablePermission is null)
                return Result.FromCode<BusinessObjectTablePermissionDto>(ResultCode.Fail, $"系统中无【{permissionId}】对应的业务对象表权限配置记录");
            else
            {
                businessObjectTablePermission.IsValid = false;
                businessObjectTablePermission = await _businessObjectTablePermissionRepository.UpdateAsync(businessObjectTablePermission);
                var businessObjectTablePermissionDto = ObjectMapper.Map<BusinessObjectTablePermission, BusinessObjectTablePermissionDto>(businessObjectTablePermission);

                return Result.FromData(businessObjectTablePermissionDto);
            }
        }

        /// inheritdoc/>
        public async Task<Result<BusinessObjectTablePermissionDto>> ValidateBusinessObjectTablePermission(Guid permissionId)
        {
            var businessObjectTablePermission = await _businessObjectTablePermissionRepository.FindAsync(permissionId);
            if (businessObjectTablePermission is null)
                return Result.FromCode<BusinessObjectTablePermissionDto>(ResultCode.Fail, $"系统中无【{permissionId}】对应的业务对象表权限配置记录");
            else
            {
                businessObjectTablePermission.IsValid = true;
                businessObjectTablePermission = await _businessObjectTablePermissionRepository.UpdateAsync(businessObjectTablePermission);
                var businessObjectTablePermissionDto = ObjectMapper.Map<BusinessObjectTablePermission, BusinessObjectTablePermissionDto>(businessObjectTablePermission);

                return Result.FromData(businessObjectTablePermissionDto);
            }
        }

        /// <inheritdoc/>
        public async Task<Result<BusinessObjectTablePermissionDto>> ValidateBusinessObjectTablePermission(string appId, string businessObjectTableName)
        {
            var businessObjectTablePermission = _businessObjectTablePermissionRepository.GetQueryable().Where(x => x.AppId == appId && x.BusinessObjectTableName == businessObjectTableName).FirstOrDefault();
            if (businessObjectTablePermission is null)
                return Result.FromCode<BusinessObjectTablePermissionDto>(ResultCode.Fail, $"系统中无应用【{appId}】,业务对象表【{businessObjectTableName}】对应的业务对象表权限配置记录");
            else
            {
                businessObjectTablePermission.IsValid = true;
                businessObjectTablePermission = await _businessObjectTablePermissionRepository.UpdateAsync(businessObjectTablePermission);
                var businessObjectTablePermissionDto = ObjectMapper.Map<BusinessObjectTablePermission, BusinessObjectTablePermissionDto>(businessObjectTablePermission);

                return Result.FromData(businessObjectTablePermissionDto);
            }
        }

        /// <inheritdoc/>
        public async Task<Result> RevokeBusinessObjectTablePermission(Guid permissionId)
        {
            await _businessObjectTablePermissionRepository.DeleteAsync(permissionId);
            return Result.Ok();
        }

        /// <inheritdoc/>
        public async Task<Result<BusinessObjectTablePermissionDto>> GetBusinessObjectTablePermission(Guid permissionId)
        {
            var businessObjectTablePermission = await _businessObjectTablePermissionRepository.GetAsync(permissionId);
            if (businessObjectTablePermission is null)
                return Result.FromCode<BusinessObjectTablePermissionDto>(ResultCode.NoData);
            else
            {
                var businessObjectTablePermissionDto = ObjectMapper.Map<BusinessObjectTablePermission, BusinessObjectTablePermissionDto>(businessObjectTablePermission);
                return Result.FromData(businessObjectTablePermissionDto);
            }
        }

        /// <inheritdoc/>
        public async Task<Result<List<BusinessObjectTablePermissionDto>>> QueryBusinessObjectTablePermission(BusinessObjectTablePermissionQueryInput businessObjectTablePermissionQueryInput)
        {
            var filter = new Query<BusinessObjectTablePermission>().GetFilter();
            if (!string.IsNullOrWhiteSpace(businessObjectTablePermissionQueryInput.AppId))
                filter.And(x => x.AppId == businessObjectTablePermissionQueryInput.AppId);
            if (!string.IsNullOrWhiteSpace(businessObjectTablePermissionQueryInput.BusinessObjectTableName))
                filter.And(x => x.BusinessObjectTableName == businessObjectTablePermissionQueryInput.BusinessObjectTableName);
            if (businessObjectTablePermissionQueryInput.IsValid.HasValue)
                filter.And(x => x.IsValid == businessObjectTablePermissionQueryInput.IsValid.Value);

            var businessObjectTablePermissions = await _businessObjectTablePermissionRepository.GetQueryable().Where(filter).ToDynamicListAsync<BusinessObjectTablePermission>();
            var businessObjectTablePermissionDtos = ObjectMapper.Map<List<BusinessObjectTablePermission>, List<BusinessObjectTablePermissionDto>>(businessObjectTablePermissions);

            return Result.FromData(businessObjectTablePermissionDtos);
        }

        /// <inheritdoc/>
        public async Task<Result<List<BusinessObjectTablePermissionDto>>> GetAllBusinessObjectTablePermission()
        {
            var businessObjectSetPermissions = await _businessObjectTablePermissionRepository.GetListAsync();
            var businessObjectSetPermissionDtos = ObjectMapper.Map<List<BusinessObjectTablePermission>, List<BusinessObjectTablePermissionDto>>(businessObjectSetPermissions);

            return Result.FromData(businessObjectSetPermissionDtos);
        }
    }
}
