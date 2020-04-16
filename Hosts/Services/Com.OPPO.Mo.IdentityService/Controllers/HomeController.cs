using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.IdentityService.Controllers
{
    public class HomeController : AbpController
    {
        public ActionResult Index()
        {
            return Redirect("/swagger");
        }

        public ActionResult Sigin()
        {

            return new JsonResult("123");
        }
    }
}
