using Volo.Abp.Application.Services;
using Com.OPPO.Mo.TenantManagement.Localization;

namespace Com.OPPO.Mo.TenantManagement
{
    public abstract class TenantManagementAppServiceBase : ApplicationService
    {
        protected TenantManagementAppServiceBase()
        {
            ObjectMapperContext = typeof(MoTenantManagementApplicationModule);
            LocalizationResource = typeof(MoTenantManagementResource);
        }
    }
}