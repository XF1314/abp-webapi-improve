using Newtonsoft.Json;
using System;

namespace Com.OPPO.Mo.Thirdparty.Wifi.Requests
{
    /// <summary>
    /// Wifi创建Request
    /// </summary>
    public class WifiCreateRequest
    {
        /// <summary>
        /// 最大闲置时长
        /// </summary>
        [JsonProperty("idleTimeout")]
        public int IdleTimeout { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        [JsonProperty("fullName")]
        public string FullName { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        [JsonProperty("certification")]
        public string Certification { get; set; }

        /// <summary>
        /// 访问接口人电话
        /// </summary>
        [JsonProperty("userName")]
        public string UserName { get; set; }

        /// <summary>
        /// 是否允许在自助服务平台修改帐号密码
        /// </summary>
        [JsonProperty("ifSelfModifyPsd")]
        public bool IfSelfModifyPsd { get; set; }

        /// <summary>
        /// 在线数量限制
        /// </summary>
        [JsonProperty("onlineLimit")]
        public int OnlineLimit { get; set; }

        /// <summary>
        /// 用户密码(手机号后6位)
        /// </summary>
        [JsonProperty("userPassword")]
        public string UserPassword { get; set; }

        /// <summary>
        /// 用户分组
        /// </summary>
        [JsonProperty("userGroupId")]
        public int UserGroupId { get; set; }

        /// <summary>
        /// 用户申请服务列表
        /// </summary>
        [JsonProperty("appliedService")]
        public AppliedServiceRequestInfo appliedService { get; set; }

        /// <summary>
        /// 失效时间
        /// </summary>
        [JsonProperty("invalidTime")]
        public string InvalidTime { get; set; }
    }

    public class AppliedServiceRequestInfo
    {
        /// <summary>
        /// 服务模板编号
        /// </summary>
        [JsonProperty("serviceTemplateId")]
        public int ServiceTemplateId { get; set; }

        /// <summary>
        /// 服务组编号
        /// </summary>
        [JsonProperty("serviceGroupId")]
        public int ServiceGroupId { get; set; }

    }

}
