using Com.OPPO.Mo.Inmail.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Inmail
{
    public class InmailAppServiceBase : ApplicationService
    {
        protected InmailAppServiceBase()
        {
            ObjectMapperContext = typeof(MoInmailApplicationModule);
            LocalizationResource = typeof(InmailResource);
        }
    }
}
