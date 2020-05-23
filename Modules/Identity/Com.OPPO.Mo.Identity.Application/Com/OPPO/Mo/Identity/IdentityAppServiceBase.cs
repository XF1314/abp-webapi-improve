using Volo.Abp.Application.Services;
using Com.OPPO.Mo.Identity.Localization;

namespace Com.OPPO.Mo.Identity
{
    public abstract class IdentityAppServiceBase : ApplicationService
    {
        protected IdentityAppServiceBase()
        {
            ObjectMapperContext = typeof(MoIdentityApplicationModule);
            LocalizationResource = typeof(IdentityResource);
        }
    }
}
