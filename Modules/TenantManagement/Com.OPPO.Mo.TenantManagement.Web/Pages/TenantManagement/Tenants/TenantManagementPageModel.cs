using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Com.OPPO.Mo.TenantManagement.Web.Pages.TenantManagement.Tenants
{
    public abstract class TenantManagementPageModel : AbpPageModel
    {
        public TenantManagementPageModel()
        {
            ObjectMapperContext = typeof(MoTenantManagementWebModule);
        }
    }
}