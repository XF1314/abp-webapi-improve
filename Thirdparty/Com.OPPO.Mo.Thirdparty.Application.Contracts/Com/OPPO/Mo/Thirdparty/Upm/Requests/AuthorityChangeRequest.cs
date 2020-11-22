using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Upm.Requests
{
    public class AuthorityChangeRequest:BaseEsbRequest
    {
        /// <summary>
        /// 权限变更信息
        /// </summary>
        [JsonProperty("msg_detail")]
        public string AuthorityChangeDetail { get; set; }
    }

    public class FileMessage
    {
        /// <summary>
        /// 文件编号
        /// </summary>
        [JsonProperty("moFileNumber")]
        public string FileNumber { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [JsonProperty("state")]
        public int State { get; set; }
        /// <summary>
        /// 工号
        /// </summary>
        [JsonProperty("userIds")]
        public List<string> UserIds { get; set; }
    }

    public class AuthorityChangeDetail
    {
        /// <summary>
        /// mq类型,1
        /// </summary>
        [JsonProperty("mqType")]
        public int MqType { get; set; }
        /// <summary>
        /// 组别：group_upm_mo_job_transfer
        /// </summary>
        [JsonProperty("produceGroup")]
        public string ProduceGroup { get; set; }
        /// <summary>
        /// 标题：topic_upm_mo_job_transfer
        /// </summary>
        [JsonProperty("topic")]
        public string Title { get; set; }
        /// <summary>
        /// 标签：tag_upm_mo_job_transfer
        /// </summary>
        [JsonProperty("tag")]
        public string Tag { get; set; }
        /// <summary>
        /// 文件信息
        /// </summary>
        [JsonProperty("msg")]
        public FileMessage FileMessage { get; set; }
    }


}
