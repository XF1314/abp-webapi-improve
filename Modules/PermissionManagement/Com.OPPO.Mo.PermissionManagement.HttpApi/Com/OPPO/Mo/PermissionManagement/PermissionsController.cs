using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.PermissionManagement.HttpApi
{
    [Area("mo")]
    [RemoteService(Name = PermissionManagementRemoteServiceConsts.RemoteServiceName)]
    public class PermissionsController : AbpController, IPermissionAppService
    {
        protected IPermissionAppService PermissionAppService { get; }

        public PermissionsController(IPermissionAppService permissionAppService)
        {
            PermissionAppService = permissionAppService;
        }

        public virtual Task<GetPermissionListResultDto> GetAsync(string providerName, string providerKey)
        {
            return PermissionAppService.GetAsync(providerName, providerKey);
        }

        public virtual Task UpdateAsync(string providerName, string providerKey, UpdatePermissionsDto input)
        {
            return PermissionAppService.UpdateAsync(providerName, providerKey, input);
        }
    }
}
