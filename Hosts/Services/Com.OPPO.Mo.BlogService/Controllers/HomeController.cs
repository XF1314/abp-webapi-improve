using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.BloggingService.Controllers
{
    public class HomeController :AbpController
    {
        public ActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}
