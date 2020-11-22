using System.ComponentModel.DataAnnotations;

namespace Com.OPPO.Mo.Thirdparty.Sms.Dtos
{
    /// <summary>
    /// 短息发送实体信息类
    /// </summary>
    public class SmsInput
    {
        /// <summary>
        /// 电话号码
        /// </summary>
        [Required]
        public string Mobile { get; set; }

        /// <summary>
        /// 消息体
        /// </summary>
        [Required]
        public string Content { get; set; }
    }
}
