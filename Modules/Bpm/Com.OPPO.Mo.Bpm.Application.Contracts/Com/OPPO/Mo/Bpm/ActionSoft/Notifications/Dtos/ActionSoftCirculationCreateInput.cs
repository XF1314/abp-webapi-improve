using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Notifications.Dtos
{
    /// <summary>
    /// ActionSoft传阅创建Input
    /// </summary>
    public class ActionSoftCirculationCreateInput
    {
        /// <summary>
        /// <see cref="ActionSoftCirculationCreateInput"/>
        /// </summary>
        public ActionSoftCirculationCreateInput()
        {
            ClaimUserCodes = new List<string>();
        }

        /// <summary>
        /// 【必填项】传阅标题
        /// </summary>
        [JsonRequired]
        public string Title { get; set; }

        /// <summary>
        ///【必填项】 PC端传阅链接
        /// </summary>
        [JsonRequired]
        public string PcLink { get; set; }

        /// <summary>
        /// 【必填项】移动端传阅链接
        /// </summary>
        [JsonRequired]
        public string MobileLink { get; set; }

        /// <summary>
        /// 【必填项】待阅人工号s
        /// </summary>
        [JsonRequired]
        public List<string> ClaimUserCodes { get; set; }


        /// <summary>
        /// 【必填项】操作人工号
        /// </summary>
        [JsonRequired]
        public string OperatorUserCode { get; set; }

    }
}
