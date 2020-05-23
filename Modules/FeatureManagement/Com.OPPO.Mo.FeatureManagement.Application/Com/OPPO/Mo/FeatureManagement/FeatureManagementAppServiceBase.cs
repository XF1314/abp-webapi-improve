using Volo.Abp.Application.Services;
using Com.OPPO.Mo.FeatureManagement.Localization;

namespace Com.OPPO.Mo.FeatureManagement
{
    public abstract class FeatureManagementAppServiceBase : ApplicationService
    {
        protected FeatureManagementAppServiceBase()
        {
            ObjectMapperContext = typeof(MoFeatureManagementApplicationModule);
            LocalizationResource = typeof(MoFeatureManagementResource);
        }
    }
}