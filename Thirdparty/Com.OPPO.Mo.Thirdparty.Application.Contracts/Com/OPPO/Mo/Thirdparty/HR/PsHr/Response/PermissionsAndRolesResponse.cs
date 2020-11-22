using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Response
{
    public class PermissionsAndRolesResponse
    {
        public List<Role> roles { get; set; }

        public List<Permission> perms { get; set; }
    }

    public class Role
    {
        /// <summary>
        /// 
        /// </summary>
        public DateTime lastModTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string roleDesc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool isRoot { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string roleId { get; set; }
        /// <summary>
        /// VPN系统
        /// </summary>
        public string appName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string appId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string roleName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime authTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string invalidTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string parentRoleCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string enabled { get; set; }
    }

    public class Permission
    {
        /// <summary>
        /// 远程桌面
        /// </summary>
        public string permDesc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime lastModTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool isRoot { get; set; }
        /// <summary>
        /// VPN系统
        /// </summary>
        public string appName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string parentPermCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string appId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string permId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime authTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime invalidTime { get; set; }
        /// <summary>
        /// 远程桌面
        /// </summary>
        public string permName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string enabled { get; set; }
    }

}
