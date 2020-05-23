using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Com.OPPO.Mo.Identity.Web.Pages.Identity
{
    public abstract class IdentityPageModel : AbpPageModel
    {
        protected IdentityPageModel()
        {
            ObjectMapperContext = typeof(MoIdentityWebModule);
        }
    }
}
