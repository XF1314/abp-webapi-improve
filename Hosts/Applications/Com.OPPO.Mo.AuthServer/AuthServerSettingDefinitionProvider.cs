using Com.OPPO.Mo.Account.Settings;
using Volo.Abp.Settings;

namespace Com.OPPO.Mo.AuthServer
{
    public class AuthServerSettingDefinitionProvider: SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition(AccountSettingNames.EnableLocalLogin,defaultValue:"true", isEncrypted: false),
                new SettingDefinition(AccountSettingNames.IsSelfRegistrationEnabled, defaultValue: "true", isEncrypted: false)
            );
        }
    }
}
