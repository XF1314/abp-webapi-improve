using Com.OPPO.Mo.Inmail.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Com.OPPO.Mo.Inmail
{
    public class InmailPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var inmailGroup = context.AddGroup(InmailPermissions.GroupName, L("Permission:InmailManagement"));
            var inboxMailPermission = inmailGroup.AddPermission(InmailPermissions.InboxMail.Default, L("Permission:InboxMailManagement"));
            inboxMailPermission.AddChild(InmailPermissions.InboxMail.Create, L("Permission:Create"));
            inboxMailPermission.AddChild(InmailPermissions.InboxMail.Update, L("Permission:Edit"));
            inboxMailPermission.AddChild(InmailPermissions.InboxMail.Delete, L("Permission:Delete"));


        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<InmailResource>(name);
        }
    }
}
