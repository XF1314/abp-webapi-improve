using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Com.OPPO.Mo.Blogging.Web.Pages.Blog
{
    public abstract class BloggingPageModel : AbpPageModel
    {
        public BloggingPageModel()
        {
            ObjectMapperContext = typeof(MoBloggingWebModule);
        }
    }
}