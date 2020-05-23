using Com.OPPO.Mo.Account.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Settings;

namespace Com.OPPO.Mo.Account.Settings
{
    public class AccountSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition(
                    AccountSettingNames.IsSelfRegistrationEnabled, 
                    "true", 
                    L("DisplayName:Mo.Account.IsSelfRegistrationEnabled"), 
                    L("Description:Mo.Account.IsSelfRegistrationEnabled"), isVisibleToClients : true)
            );

            context.Add(
                new SettingDefinition(
                    AccountSettingNames.EnableLocalLogin, 
                    "true", 
                    L("DisplayName:Mo.Account.EnableLocalLogin"), 
                    L("Description:Mo.Account.EnableLocalLogin"), isVisibleToClients : true)
            );
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AccountResource>(name);
        }
    }
}