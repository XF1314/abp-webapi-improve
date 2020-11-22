using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Dtos
{

    public class PermissionsAndRolesDto 
    {
        /// <summary>
        /// 权限或角色名称，支持模糊查询，可不填写，不填写即返回所有
        /// </summary>
        public string Authority { get; set; }

        /// <summary>
        /// 获取权限类别，1获取角色，2获取权限
        /// </summary>
        [Required]
        public string PowerType { get; set; }

        /// <summary>
        /// 查询页码,从1开始
        /// </summary>
        [Required]
        public string PageIndex { get; set; }

        /// <summary>
        /// 分页大小
        /// </summary>
        [Required]
        public string PageSize { get; set; }

        /// <summary>
        /// 应用ID,ALL表示所有
        /// </summary>
        [Required]
        public string UpmAppId { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        [Required]
        public string UserId { get; set; }
    }
}
