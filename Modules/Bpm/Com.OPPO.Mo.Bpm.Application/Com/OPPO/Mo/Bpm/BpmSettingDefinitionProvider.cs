using Com.OPPO.Mo.Bpm.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Localization;
using Volo.Abp.Settings;

namespace Com.OPPO.Mo.Bpm
{
   public  class BpmSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition(
                    BpmSettingNames.ActiontSoftWebApiHost,
                    "",
                    L("DisplayName:WebApiHost"),
                    L("Description:WebApiHost"), isVisibleToClients: true)
            );

            context.Add(
                new SettingDefinition(
                    BpmSettingNames.ActionSoftWebApiAccessKey,
                    "",
                    L("DisplayName:WebApiAccessKey"),
                    L("Description:WebApiAccessKey"), isVisibleToClients: true)
            );

            context.Add(
                new SettingDefinition(
                    BpmSettingNames.ActionSoftWebApiSignKey,
                    "",
                    L("DisplayName:WebApiSignKey"),
                    L("Description:WebApiSignKey"), isVisibleToClients: true)
            );
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<MoBpmResource>(name);
        }
    }
}