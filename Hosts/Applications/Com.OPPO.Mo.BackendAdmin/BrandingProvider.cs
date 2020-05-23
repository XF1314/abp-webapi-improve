using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace Com.OPPO.Mo.BackendAdmin
{
    public class BrandingProvider : IBrandingProvider, ISingletonDependency
    {
        public string AppName => "Mo Backend Admin App";
        public string LogoUrl => null;
    }
}
