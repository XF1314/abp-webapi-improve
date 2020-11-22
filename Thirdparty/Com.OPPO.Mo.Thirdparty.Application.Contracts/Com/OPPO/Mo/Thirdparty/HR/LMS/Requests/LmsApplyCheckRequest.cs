using System.Collections.Generic;

namespace Com.OPPO.Mo.Thirdparty.Hr.LMS.Requests
{
    /// <summary>
    /// 检查员工是否已提交申请实体信息
    /// </summary>
    public class LmsApplyCheckRequest
    {
        /// <summary>
        /// 申请工号
        /// </summary>
        public List<string> ApplyIdList { get; set; }
    }
}
