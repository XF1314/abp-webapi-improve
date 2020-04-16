using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace Com.OPPO.Mo.AuthServer
{
    public class BrandingProvider : IBrandingProvider, ISingletonDependency
    {
        public string AppName => "Mo Auth Server";
        public string LogoUrl => null;
    }
}
