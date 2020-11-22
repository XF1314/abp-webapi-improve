using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.MasterData
{
    public static class MasterDataPermissions
    {
        public const string GroupName = "MoMasterData";

        public static class InboxMail
        {
            public const string Default = GroupName + ".Inmail.InboxMails";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }
    }
}
