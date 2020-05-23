using System.Collections.Generic;

namespace Com.OPPO.Mo.SettingManagement.Web.Pages.SettingManagement
{
    public class SettingManagementPageOptions
    {
        public List<ISettingPageContributor> Contributors { get; }

        public SettingManagementPageOptions()
        {
            Contributors = new List<ISettingPageContributor>();
        }
    }
}
