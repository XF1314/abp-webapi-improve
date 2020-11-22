using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Organiztion.Requests
{
    /// <summary>
    /// ActionSoft根据员工工号获取员工姓名Request
    /// </summary>
    public class ActionSoftUserNamesGetByUserCodesRequest : BaseActionSoftWebApiRequest
    {
        /// <summary>
        /// <see cref="ActionSoftUserNamesGetByUserCodesRequest"/>
        /// </summary>
        public ActionSoftUserNamesGetByUserCodesRequest() : base(ActionSoftOrganiztionCommands.UserNameGetByUserCode)
        {
            UserCodes = new List<string>();
        }

        /// <summary>
        /// 【必填项】员工工号s
        /// </summary>
        [JsonIgnore]
        public List<string> UserCodes { get; set; }

        /// <summary>
        /// 【必填项】员工工号s
        /// </summary>
        [JsonProperty("uids")]
        private string userCodes => string.Join(Split, UserCodes);

        /// <summary>
        /// 【必填项】分隔符
        /// </summary>
        [JsonRequired]
        public string Split { get; set; }
    }
}
