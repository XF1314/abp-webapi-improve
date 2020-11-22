using Newtonsoft.Json;
using System;

namespace Com.OPPO.Mo.Thirdparty.Wifi.Responses
{
    /// <summary>
    /// H3C 信息
    /// </summary>
    public class WifiRefDataRawInfo
    {
        /// <summary>
        /// 用户编码
        /// </summary>
        [JsonProperty("userId")]
        public string UserId { get; set; }

        /// <summary>
        /// 用户名（访客接口人电话）
        /// </summary>
        [JsonProperty("userName")]
        public string Phone { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        [JsonProperty("userPassword")] 
        public string UserPassword { get; set; }

        /// <summary>
        /// 用户组编号
        /// </summary>
        [JsonProperty("userGroupId")] 
        public string UserGroupId { get; set; }

        /// <summary>
        /// 用户组
        /// </summary>
        [JsonProperty("userGroupName")] 
        public string UserGroupName { get; set; }

        /// <summary>
        /// 平台用户ID
        /// </summary>
        [JsonProperty("platUserId")] 
        public string PlatUserId { get; set; }

        /// <summary>
        /// 全称
        /// </summary>
        [JsonProperty("fullName")] 
        public string FullName { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        [JsonProperty("certification")] 
        public string Certification { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("blackState")] 
        public string BlackState { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [JsonProperty("status")] 
        public string Status { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("ldapState")] 
        public string LdapState { get; set; }

        /// <summary>
        /// 是否允许在自助服务平台修改帐号密码
        /// </summary>
        [JsonProperty("ifSelfModifyPsd")] 
        public string IfSelfModifyPsd { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("ifPsdPolicy")] 
        public string IfPsdPolicy { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("userCreateTime")] 
        public DateTime UserCreateTime { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("ifNeedChangeNext")] 
        public string IfNeedChangeNext { get; set; }

        /// <summary>
        /// 最后使用时间
        /// </summary>
        [JsonProperty("lastUsingTim")] 
        public DateTime LastUsingTim { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("invalidTime")] 
        public DateTime InvalidTime { get; set; }

        /// <summary>
        /// 有效时间
        /// </summary>
        [JsonProperty("validTimeStr")] 
        public string ValidTimeStr { get; set; }

        /// <summary>
        /// 空闲时间
        /// </summary>
        [JsonProperty("idleTimeout")] 
        public string IdleTimeout { get; set; }

        /// <summary>
        /// 在线数量限制
        /// </summary>
        [JsonProperty("onlineLimit")] 
        public string OnlineLimit { get; set; }

        /// <summary>
        /// 在线状态
        /// </summary>
        [JsonProperty("onlineState")] 
        public string OnlineState { get; set; }

        /// <summary>
        /// 用户申请服务列表
        /// </summary>
        [JsonProperty("appliedService")] 
        public AppliedServiceInfo AppliedService { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("ifManageGuest")] 
        public string IfManageGuest { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        [JsonProperty("userType")] 
        public string UserType { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("ifRegisterFreeOTP")] 
        public string IfRegisterFreeOTP { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("ifEnableDelMAC")] 
        public string IfEnableDelMAC { get; set; }

        /// <summary>
        /// ?
        /// </summary>
        [JsonProperty("ifClearOnlineTerminal")] 
        public string IfClearOnlineTerminal { get; set; }
    }

    public class AppliedServiceInfo
    {
        /// <summary>
        /// 服务模板编号
        /// </summary>
        [JsonProperty("serviceTemplateId")]
        public string ServiceTemplateId { get; set; }

        /// <summary>
        /// 服务模板名称
        /// </summary>
        [JsonProperty("serviceTemplateName")]
        public string ServiceTemplateName { get; set; }

        /// <summary>
        /// 服务后缀
        /// </summary>
        [JsonProperty("serviceSuffix")]
        public string ServiceSuffix { get; set; }
    }
}
