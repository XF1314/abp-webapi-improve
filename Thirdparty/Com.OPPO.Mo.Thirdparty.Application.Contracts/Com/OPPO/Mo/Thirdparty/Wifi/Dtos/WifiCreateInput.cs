using System;
using System.ComponentModel.DataAnnotations;

namespace Com.OPPO.Mo.Thirdparty.Wifi.Dtos
{
    /// <summary>
    /// wifi创建Input
    /// </summary>
    public class WifiCreateInput
    {
        /// <summary>
        /// 最大闲置时长
        /// </summary>   
        [Required]
        public int IdleTimeout { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        [Required]
        public string FullName { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        [Required]
        public string Certification { get; set; }

        /// <summary>
        /// 访问接口人电话
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// 是否允许在自助服务平台修改帐号密码
        /// </summary>
        [Required]
        public bool IfSelfModifyPsd { get; set; }

        /// <summary>
        /// 在线数量限制
        /// </summary>
        [Required]
        public int OnlineLimit { get; set; }

        /// <summary>
        /// 用户密码(手机号后6位)
        /// </summary>
        [Required]
        public string UserPassword { get; set; }

        /// <summary>
        /// 用户分组
        /// </summary>
        [Required]
        public int UserGroupId { get; set; }

        /// <summary>
        /// 用户申请服务列表
        /// </summary>
        public AppliedServiceInputInfo AppliedService { get; set; }

        /// <summary>
        /// 失效时间()
        /// </summary>
        [Required]
        public string InvalidTime { get; set; }
    }

    public class AppliedServiceInputInfo
    {
        /// <summary>
        /// 服务模板编号
        /// </summary>
        [Required]
        public int ServiceTemplateId { get; set; }

        /// <summary>
        /// 服务组编号
        /// </summary>
        [Required]
        public int ServiceGroupId { get; set; }

    }
}
