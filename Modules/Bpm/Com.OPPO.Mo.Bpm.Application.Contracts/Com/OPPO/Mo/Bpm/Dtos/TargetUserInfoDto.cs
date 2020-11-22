using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.Dtos
{
    /// <summary>
    /// 目标用户信息Dto
    /// </summary>
    public class TargetUserInfoDto
    {
        /// <summary>
        /// 【必填项】用户帐号（员工工号）
        /// </summary>
        [JsonRequired]
        public string UserCode { get; set; }

        /// <summary>
        /// 用户中文名字
        /// </summary>
        public string UserCnName { get; set; }

        /// <summary>
        /// 用户英文名字
        /// </summary>
        public string UserEnName { get; set; }

        /// <summary>
        /// 用户所属部门
        /// </summary>
        public string UserDepartment { get; set; }

        /// <summary>
        /// 用户角色
        /// </summary>
        public string UserRole { get; set; }

        /// <summary>
        /// 用户职位
        /// </summary>
        public string UserPosition { get; set; }
    }
}
