using Com.OPPO.Mo.Thirdparty.Erp;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Common.EmailSend.Request
{
    public class EmailSendRequest: BaseEsbRespTypeRequest
    {
        /// <summary>
        /// 附件
        /// </summary>
        [JsonProperty("attatchment")]
        public IFormFile Appendix { get; set; }

        /// <summary>
        /// 密送人，多个以英文逗号隔开
        /// </summary>
        [JsonProperty("blind_copy_to")]
        public string SecretAgent { get; set; }
        /// <summary>
        /// 抄送人，多个以英文逗号隔开
        /// </summary>
        [JsonProperty("copy_to")]
        public string CCperson { get; set; }
        /// <summary>
        /// 邮件正文
        /// </summary>
        [JsonProperty("mail_content")]
        public string MailContent { get; set; }
        /// <summary>
        /// 邮件标题
        /// </summary>
        [JsonProperty("mail_title")]
        public string MailTitle { get; set; }

        /// <summary>
        /// 收件人，多个以英文逗号隔开
        /// </summary>
        [JsonProperty("mail_to")]
        public string Addressee { get; set; }

    }
}
