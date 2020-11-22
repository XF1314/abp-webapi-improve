using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Values;

namespace Com.OPPO.Mo.Bpm
{
    /// <summary>
    /// 目标用户信息
    /// </summary>
    public class TargetUserInfo : ValueObject
    {
        /// <summary>
        /// 用户帐号
        /// </summary>
        [NotNull]
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

        /// <inheritdoc/>
        protected override IEnumerable<object> GetAtomicValues()
        {
            return new object[] { UserCode, UserCnName, UserEnName, UserDepartment, UserRole, UserPosition };
        }
    }
}
