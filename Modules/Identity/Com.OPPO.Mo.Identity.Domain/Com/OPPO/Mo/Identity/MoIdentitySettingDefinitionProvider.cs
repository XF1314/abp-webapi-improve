using Com.OPPO.Mo.Identity.Localization;
using Com.OPPO.Mo.Identity.Settings;
using Volo.Abp.Localization;
using Volo.Abp.Settings;

namespace Com.OPPO.Mo.Identity
{
    public class MoIdentitySettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition(
                    IdentitySettingNames.Password.RequiredLength, 
                    6.ToString(), 
                    L("DisplayName:Mo.Identity.Password.RequiredLength"), 
                    L("Description:Mo.Identity.Password.RequiredLength"), 
                    true),

                new SettingDefinition(
                    IdentitySettingNames.Password.RequiredUniqueChars, 
                    1.ToString(), 
                    L("DisplayName:Mo.Identity.Password.RequiredUniqueChars"), 
                    L("Description:Mo.Identity.Password.RequiredUniqueChars"), 
                    true),

                new SettingDefinition(
                    IdentitySettingNames.Password.RequireNonAlphanumeric, 
                    true.ToString(), 
                    L("DisplayName:Mo.Identity.Password.RequireNonAlphanumeric"), 
                    L("Description:Mo.Identity.Password.RequireNonAlphanumeric"), 
                    true),

                new SettingDefinition(
                    IdentitySettingNames.Password.RequireLowercase, 
                    true.ToString(), L("DisplayName:Mo.Identity.Password.RequireLowercase"), 
                    L("Description:Mo.Identity.Password.RequireLowercase"), 
                    true),

                new SettingDefinition(
                    IdentitySettingNames.Password.RequireUppercase, 
                    true.ToString(), L("DisplayName:Mo.Identity.Password.RequireUppercase"), 
                    L("Description:Mo.Identity.Password.RequireUppercase"), 
                    true),

                new SettingDefinition(
                    IdentitySettingNames.Password.RequireDigit, 
                    true.ToString(), L("DisplayName:Mo.Identity.Password.RequireDigit"), 
                    L("Description:Mo.Identity.Password.RequireDigit"), 
                    true),

                new SettingDefinition(
                    IdentitySettingNames.Lockout.AllowedForNewUsers, 
                    true.ToString(), L("DisplayName:Mo.Identity.Lockout.AllowedForNewUsers"), 
                    L("Description:Mo.Identity.Lockout.AllowedForNewUsers"), 
                    true),
                    
                new SettingDefinition(
                    IdentitySettingNames.Lockout.LockoutDuration, 
                    (5*60).ToString(), L("DisplayName:Mo.Identity.Lockout.LockoutDuration"), 
                    L("Description:Mo.Identity.Lockout.LockoutDuration"), 
                    true),

                new SettingDefinition(
                    IdentitySettingNames.Lockout.MaxFailedAccessAttempts, 
                    5.ToString(), L("DisplayName:Mo.Identity.Lockout.MaxFailedAccessAttempts"), 
                    L("Description:Mo.Identity.Lockout.MaxFailedAccessAttempts"), 
                    true),

                new SettingDefinition(
                    IdentitySettingNames.SignIn.RequireConfirmedEmail, 
                    false.ToString(), L("DisplayName:Mo.Identity.SignIn.RequireConfirmedEmail"), 
                    L("Description:Mo.Identity.SignIn.RequireConfirmedEmail"), 
                    true),
                new SettingDefinition(
                    IdentitySettingNames.SignIn.EnablePhoneNumberConfirmation, 
                    true.ToString(), L("DisplayName:Mo.Identity.SignIn.EnablePhoneNumberConfirmation"), 
                    L("Description:Mo.Identity.SignIn.EnablePhoneNumberConfirmation"), 
                    true),
                new SettingDefinition(
                    IdentitySettingNames.SignIn.RequireConfirmedPhoneNumber, 
                    false.ToString(), L("DisplayName:Mo.Identity.SignIn.RequireConfirmedPhoneNumber"), 
                    L("Description:Mo.Identity.SignIn.RequireConfirmedPhoneNumber"), 
                    true),

                new SettingDefinition(
                    IdentitySettingNames.User.IsUserNameUpdateEnabled, 
                    true.ToString(), L("DisplayName:Mo.Identity.User.IsUserNameUpdateEnabled"), 
                    L("Description:Mo.Identity.User.IsUserNameUpdateEnabled"), 
                    true),

                new SettingDefinition(
                    IdentitySettingNames.User.IsEmailUpdateEnabled, 
                    true.ToString(), L("DisplayName:Mo.Identity.User.IsEmailUpdateEnabled"), 
                    L("Description:Mo.Identity.User.IsEmailUpdateEnabled"), 
                    true)
            );
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<IdentityResource>(name);
        }
    }
}
