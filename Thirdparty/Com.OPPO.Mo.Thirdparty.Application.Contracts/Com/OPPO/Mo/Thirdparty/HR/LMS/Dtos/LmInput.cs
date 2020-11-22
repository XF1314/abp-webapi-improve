using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Com.OPPO.Mo.Thirdparty.Hr.LMS.Dtos
{
    /// <summary>
    /// 更新离职信息请求类
    /// </summary>
    public class LmInput
    {
        /// <summary>
        /// 推送 json
        /// 格式：{\"UserAccount\":\"80251553\",\"Name\":\"陈思怡（80251553）\",\"Sex\":\"女\",\"Department\":\"IT管理部\",\"Job\":\"软件工程师助理\",\"Rank\":\"7级\",\"Achievements\":\"A级、B级\",\"Telephone\":\"13603211122\",\"Mailbox\":\"siyi.chen@oppo.com\",\"ReasonsForLeaving\":\"员工退出（享自由）\",\"EntryTime\":\"2019-01-20\",\"LastWorkingTime\":\"2019-10-20\",\"ServiceMonth\":\"9\",\"HandoverPerson_Account\":\"80059212\",\"HandoverPerson_Name\":\"曾达樟（80059212）\",\"TelOfHandoverPerson\":\"13728317116\",\"Remarks\":\"备注\",\"DynT_List\":[]}
        /// </summary>
        [Required]
        public string DataJson { get; set; }

        /// <summary>
        /// 文件编号
        /// </summary>
        [Required]
        public string FormInstanceCode { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        [Required]
        public string UserAccount { get; set; }

        
    }
}
