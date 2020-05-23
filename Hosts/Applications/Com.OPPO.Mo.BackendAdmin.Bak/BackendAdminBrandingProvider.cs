using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace BackendAdminApp.Host
{
    public class BackendAdminBrandingProvider : IBrandingProvider, ISingletonDependency
    {
        public string AppName => "Mo Backend Admin Web";
        public string LogoUrl => null;
    }
}
