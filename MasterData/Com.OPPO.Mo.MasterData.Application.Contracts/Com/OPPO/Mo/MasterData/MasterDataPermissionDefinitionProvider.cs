using Com.OPPO.Mo.MasterData.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Com.OPPO.Mo.MasterData
{
    public class MasterDataPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var inmailGroup = context.AddGroup(MasterDataPermissions.GroupName, L("Permission:InmailManagement"));
            var inboxMailPermission = inmailGroup.AddPermission(MasterDataPermissions.InboxMail.Default, L("Permission:InboxMailManagement"));
            inboxMailPermission.AddChild(MasterDataPermissions.InboxMail.Create, L("Permission:Create"));
            inboxMailPermission.AddChild(MasterDataPermissions.InboxMail.Update, L("Permission:Edit"));
            inboxMailPermission.AddChild(MasterDataPermissions.InboxMail.Delete, L("Permission:Delete"));


        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<MasterDataResource>(name);
        }
    }
}
