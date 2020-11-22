using Com.OPPO.Mo.Thirdparty.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Localization;
using Volo.Abp.Settings;

namespace Com.OPPO.Mo.Thirdparty
{
    public  class ThirdpartySettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition(
                    ThirdpartySettingNames.EsbHost,
                    "",
                    L("DisplayName:EsbHost"),
                    L("Description:EsbHost"), isVisibleToClients: true)
            );

            context.Add(
                new SettingDefinition(
                    ThirdpartySettingNames.EsbAppId,
                    "",
                    L("DisplayName:EsbAppId"),
                    L("Description:EsbAppId"), isVisibleToClients: true)
            );

            context.Add(
                new SettingDefinition(
                    ThirdpartySettingNames.EsbSignKey,
                    "",
                    L("DisplayName:EsbSignKey"),
                    L("Description:EsbSignKey"), isVisibleToClients: true)
            );
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<MoThirdpartyResource>(name);
        }
    }
}