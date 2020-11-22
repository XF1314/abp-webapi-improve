using Com.OPPO.Mo.Thirdparty.Wifi.Responses;
using System;

namespace Com.OPPO.Mo.Thirdparty.Wifi.Dtos
{
    /// <summary>
    /// Wifi 信息
    /// </summary>
    public class WifiRefDataRawDto
    {
        /// <summary>
        /// 用户编码
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 用户名（访客接口人电话）
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPassword { get; set; }

        /// <summary>
        /// 用户组编号
        /// </summary>
        public string UserGroupId { get; set; }

        /// <summary>
        /// 用户组
        /// </summary>
        public string UserGroupName { get; set; }

        /// <summary>
        /// 平台用户ID
        /// </summary>
        public string PlatUserId { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public string Certification { get; set; }

        /// <summary>
        /// ？
        /// </summary>
        public string BlackState { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        public string LdapState { get; set; }

        /// <summary>
        /// 是否允许在自助服务平台修改帐号密码
        /// </summary>
        public string IfSelfModifyPsd { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        public string IfPsdPolicy { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        public DateTime UserCreateTime { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        public string IfNeedChangeNext { get; set; }

        /// <summary>
        /// 最后使用时间
        /// </summary>
        public DateTime LastUsingTim { get; set; }

        /// <summary>
        /// 失效时间
        /// </summary>
        public DateTime InvalidTime { get; set; }

        /// <summary>
        /// 生效时间
        /// </summary>
        public DateTime ValidTimeStr { get; set; }

        /// <summary>
        /// 最大闲置时长
        /// </summary>
        public int IdleTimeout { get; set; }

        /// <summary>
        /// 在线数量限制
        /// </summary>
        public string OnlineLimit { get; set; }

        /// <summary>
        /// 在线状态
        /// </summary>
        public string OnlineState { get; set; }

        /// <summary>
        /// 用户申请服务列表
        /// </summary>
        public AppliedServiceInfoDto AppliedService { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        public string IfManageGuest { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        public string UserType { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        public string IfRegisterFreeOTP { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        public string IfEnableDelMAC { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        public string IfClearOnlineTerminal { get; set; }
    }

    public class AppliedServiceInfoDto
    {
        /// <summary>
        /// 服务模板编号
        /// </summary>
        public string ServiceTemplateId { get; set; }

        /// <summary>
        /// 服务模板名称
        /// </summary>
        public string ServiceTemplateName { get; set; }

        /// <summary>
        /// 服务后缀
        /// </summary>
        public string ServiceSuffix { get; set; }
    }
}
