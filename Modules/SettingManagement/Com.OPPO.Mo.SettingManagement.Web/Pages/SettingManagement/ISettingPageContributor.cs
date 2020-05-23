using System.Threading.Tasks;

namespace Com.OPPO.Mo.SettingManagement.Web.Pages.SettingManagement
{
    public interface ISettingPageContributor
    {
        Task ConfigureAsync(SettingPageCreationContext context);

        Task<bool> CheckPermissionsAsync(SettingPageCreationContext context);
    }
}