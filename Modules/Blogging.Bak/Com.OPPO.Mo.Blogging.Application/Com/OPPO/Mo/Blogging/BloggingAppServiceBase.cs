using Volo.Abp.Application.Services;
using Com.OPPO.Mo.Blogging.Localization;

namespace Com.OPPO.Mo.Blogging
{
    public abstract class BloggingAppServiceBase : ApplicationService
    {
        protected BloggingAppServiceBase()
        {
            ObjectMapperContext = typeof(MoBloggingApplicationModule);
            LocalizationResource = typeof(BloggingResource);
        }
    }
}