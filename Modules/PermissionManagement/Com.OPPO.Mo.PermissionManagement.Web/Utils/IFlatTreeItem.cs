﻿namespace Com.OPPO.Mo.PermissionManagement.Web.Utils
{
    public interface IFlatTreeItem
    {
        string Name { get; }

        string ParentName { get; }

        int Depth { get; set; }
    }
}