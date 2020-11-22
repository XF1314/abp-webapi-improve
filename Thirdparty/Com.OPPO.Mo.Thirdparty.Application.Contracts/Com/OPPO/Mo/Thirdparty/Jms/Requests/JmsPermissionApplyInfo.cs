using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Jms.Requests
{
    /// <summary>
    /// 跳板机权限申请信息
    /// </summary>
    public class JmsPermissionApplyInfo
    {
        /// <summary>
        /// <see cref="JmsPermissionApplyInfo"/>
        /// </summary>
        public JmsPermissionApplyInfo()
        {
            IsTemp = "True";
        }

        /// <summary>
        /// 【必填项】<see cref="JmsRole"/>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public JmsRole Role { get; set; }

        /// <summary>
        /// 【必填项】<see cref="JmsEnvironment"/>
        /// </summary>
        [JsonProperty("env_tag")]
        [JsonConverter(typeof(StringEnumConverter))]
        public JmsEnvironment Environment { get; set; }

        /// <summary>
        /// 【必填项】<see cref="JmsTermType"/>
        /// </summary>
        [JsonProperty("term_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public JmsTermType TermType { get; set; }

        /// <summary>
        /// 【必填项】时间From
        /// </summary>
        [JsonIgnore]
        public DateTime TimeFrom { get; set; }

        /// <summary>
        /// 【必填项】时间To
        /// </summary>
        [JsonIgnore]
        public DateTime TimeTo { get; set; }

        /// <summary>
        /// 时间Range
        /// </summary>
        [JsonProperty("time_range")]
        public List<string> TimeRange => new List<string> { TimeFrom.ToString("yyyy-MM-dd"), TimeTo.ToString("yyyy-MM-dd") };

        /// <summary>
        /// 【必填项】业务s
        /// </summary>
        public List<string> Businesses { get; set; }

        /// <summary>
        /// 【必填项】是否欧盟机器
        /// </summary>
        [JsonIgnore]
        public bool IsEuMachine { get; set; }

        /// <summary>
        /// 是否欧盟机器
        /// </summary>
        [JsonProperty("is_eu_asset")]
        public string IsEuropeMachine => IsEuMachine ? "1" : "0";

        /// <summary>
        /// 是否临时
        /// </summary>
        [JsonProperty("is_tmp")]
        public string IsTemp { get; private set; }

        /// <summary>
        /// 主机s
        /// </summary>
        public List<string> Hosts { get; set; }

        /// <summary>
        /// 原因
        /// </summary>
        public string Reason { get; set; }

    }

    /// <summary>
    /// 跳板机环境
    /// </summary>
    public enum JmsEnvironment
    {
        /// <summary>
        /// 生产环境
        /// </summary>
        [Description("生产环境")]
        product = 1,

        /// <summary>
        /// 测试环境
        /// </summary>
        [Description("测试环境")]
        test = 2
    }

    /// <summary>
    /// 跳板机角色
    /// </summary>
    public enum JmsRole
    {
        /// <summary>
        /// 管理员
        /// </summary>
        [Description("管理员")]
        administrator = 1,

        /// <summary>
        /// 基本权限
        /// </summary>
        [Description("基本权限")]
        privileger = 2,

        /// <summary>
        /// 普通用户
        /// </summary>
        [Description("普通用户")]
        common_user
    }

    /// <summary>
    /// 跳板机期限类型
    /// </summary>
    public enum JmsTermType
    {
        /// <summary>
        /// 短期
        /// </summary>
        [Description("短期")]
        @short = 1,

        /// <summary>
        /// 长期
        /// </summary>
        [Description("长期")]
        @long = 2
    }
}
