using Com.OPPO.Mo.Thirdparty.Jms.Requests;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Jms.Dtos
{
    /// <summary>
    /// 跳板机权限新增 input
    /// </summary>
    public class JmsPermissionAddInput
    {
        /// <summary>
        /// 【必填项】<see cref="JmsUserDto"/>
        /// </summary>
        [Required]
        public JmsUserDto User { get; set; }

        /// <summary>
        /// 【必填项】<see cref="JmsPermissionApplyDto"/>
        /// </summary>
        [Required]
        public JmsPermissionApplyDto ApplyInfo { get; set; }
    }

    /// <summary>
    /// 跳板机权限申请Dto
    /// </summary>
    public class JmsPermissionApplyDto
    {
        /// <summary>
        /// 【必填项】<see cref="JmsRole"/>
        /// </summary>
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public JmsRole Role { get; set; }

        /// <summary>
        /// 【必填项】<see cref="JmsTermType"/>
        /// </summary>
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public JmsTermType TermType { get; set; }

        /// <summary>
        /// 【必填项】<see cref="JmsEnvironment"/>
        /// </summary>
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public JmsEnvironment Environment { get; set; }

        /// <summary>
        /// 【必填项】时间From
        /// </summary>
        [Required]
        public DateTime TimeFrom { get; set; }

        /// <summary>
        /// 【必填项】时间To
        /// </summary>
        [Required]
        public DateTime TimeTo { get; set; }

        /// <summary>
        /// 【必填项】业务s
        /// </summary>
        [Required]
        public List<string> Businesses { get; set; }

        /// <summary>
        /// 主机s
        /// </summary>
        public List<string> Hosts { get; set; }

        /// <summary>
        /// 原因
        /// </summary>
        public string Reason { get; set; }
    }
}
