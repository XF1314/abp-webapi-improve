using Volo.Abp.AspNetCore.Mvc;
using Com.OPPO.Mo.Blogging.Localization;

namespace Com.OPPO.Mo.Blogging.Web.Areas.Blog.Controllers
{
    public abstract class BloggingControllerBase : AbpController
    {
        protected BloggingControllerBase()
        {
            ObjectMapperContext = typeof(MoBloggingWebModule);
            LocalizationResource = typeof(BloggingResource);
        }
    }
}