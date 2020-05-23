using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.BackendAdmin.Controllers
{
    public class HomeController : AbpController
    {
        public ActionResult Index()
        {
            //return Redirect("/Identity/Users");
            return Redirect("/swagger");
        }
    }
}
