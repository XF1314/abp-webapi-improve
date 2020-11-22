using Com.OPPO.Mo.Thirdparty.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty
{
     public class ThirdpartyAppServiceBase : ApplicationService
    {
        protected ThirdpartyAppServiceBase()
        {
            ObjectMapperContext = typeof(MoThirdpartyApplicationModule);
            LocalizationResource = typeof(MoThirdpartyResource);
        }
    }
}