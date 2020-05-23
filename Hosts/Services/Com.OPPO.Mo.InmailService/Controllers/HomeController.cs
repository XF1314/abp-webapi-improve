using Com.OPPO.Mo.PermissionManagement;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.InmailService.Controllers
{
    public class HomeController : AbpController
    {
        protected IPermissionGrantRepository PermissionGrantRepository { get; }

        public HomeController(IPermissionGrantRepository permissionGrantRepository)
        {
            PermissionGrantRepository = permissionGrantRepository;
        }

        public ActionResult Index()
        {
            return Redirect("/swagger");
        }

        public ActionResult Sigin()
        {

            return new JsonResult("234");
        }
    }
}
