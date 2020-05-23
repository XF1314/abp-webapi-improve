using Volo.Abp.Collections;

namespace Com.OPPO.Mo.SettingManagement
{
    public class SettingManagementOptions
    {
        public ITypeList<ISettingManagementProvider> Providers { get; }

        public SettingManagementOptions()
        {
            Providers = new TypeList<ISettingManagementProvider>();
        }
    }
}
