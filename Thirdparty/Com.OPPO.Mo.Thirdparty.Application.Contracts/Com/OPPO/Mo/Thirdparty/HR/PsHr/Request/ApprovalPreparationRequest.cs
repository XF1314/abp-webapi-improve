using Com.OPPO.Mo.Thirdparty.Hr.PsHr.Dtos;
using Com.OPPO.Mo.Thirdparty.HR.PsHr.Request;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Request
{

    public class ApprovalPreparationRequest : PsHrBaseRequest
    {
        /// <summary>
        /// 文件单号
        /// </summary>
        [JsonProperty("fileid")]
        public string FileId { get; set; }

        /// <summary>
        /// A/I()
        /// </summary>
        [JsonProperty("action")] 
        public string Action { get; set; }


        /// <summary>
        /// 01(社招)/02(内聘)
        /// </summary>
        [JsonProperty("type")] 
        public string RecruitmentType { get; set; }


        /// <summary>
        /// 编制信息
        /// </summary>
        [JsonProperty("data")] 
        public List<DepartmentEmploy> Datas { get; set; }
    }

   
}
