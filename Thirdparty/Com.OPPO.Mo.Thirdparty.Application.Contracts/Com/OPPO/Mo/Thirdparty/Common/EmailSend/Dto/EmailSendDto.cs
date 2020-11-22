using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Common.EmailSend.Dto
{
    public class EmailSendDto
    {
        /// <summary>
        /// 邮件正文
        /// </summary>
        [Required]
        public string MailContent { get; set; }
        /// <summary>
        /// 邮件标题
        /// </summary>
        [Required]
        public string MailTitle { get; set; }

        /// <summary>
        /// 收件人，多个以英文逗号隔开
        /// </summary>
        [Required]
        public string Addressee { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        public IFormFile Appendix { get; set; }

        /// <summary>
        /// 密送人，多个以英文逗号隔开
        /// </summary>
        public string SecretAgent { get; set; }
        /// <summary>
        /// 抄送人，多个以英文逗号隔开
        /// </summary>
        public string CCperson { get; set; }
       
        /// <summary>
        /// 返回格式，支持json/xml两种格式，默认为json格式
        /// </summary>
        public string ResponseType { get; set; }
    }
}
