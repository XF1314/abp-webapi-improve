using System.Threading.Tasks;

namespace Com.OPPO.Mo.Identity.Web.Pages.Identity.Roles
{
    public class IndexModel : IdentityPageModel
    {
        public virtual Task OnGetAsync()
        {
            return Task.CompletedTask;
        }

        public virtual Task OnPostAsync()
        {
            return Task.CompletedTask;
        }
    }
}