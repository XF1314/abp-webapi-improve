using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Inmail
{
    public static class InmailPermissions
    {
        public const string GroupName = "MoInmail";

        public static class InboxMail
        {
            public const string Default = GroupName + ".InboxMails";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }
    }
}
