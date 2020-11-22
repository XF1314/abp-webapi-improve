﻿using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.InternalGateway.Controllers
{
    public class HomeController :AbpController
    {
        public ActionResult Index()
        {
             return Redirect("/swagger");
        }
    }
}
