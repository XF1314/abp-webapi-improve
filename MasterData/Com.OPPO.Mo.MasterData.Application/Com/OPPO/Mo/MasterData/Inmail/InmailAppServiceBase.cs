using Com.OPPO.Mo.MasterData.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.MasterData
{
    public class InmailAppServiceBase : ApplicationService
    {
        protected InmailAppServiceBase()
        {
            ObjectMapperContext = typeof(MoMasterDataApplicationModule);
            LocalizationResource = typeof(MasterDataResource);
        }
    }
}
