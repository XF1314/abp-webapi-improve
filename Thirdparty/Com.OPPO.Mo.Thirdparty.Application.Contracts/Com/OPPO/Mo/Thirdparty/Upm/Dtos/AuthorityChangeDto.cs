using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Upm.Dtos
{

    public class FileMessageDto
    {
        /// <summary>
        /// 文件编号
        /// </summary>
        public string FileNumber { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 工号
        /// </summary>
        public List<string> UserIds { get; set; }
    }

    public class AuthorityChangeDto
    {
        /// <summary>
        /// mq类型,1
        /// </summary>
        [Required]
        public int MqType { get; set; }
        /// <summary>
        /// 组别，默认值：group_upm_mo_job_transfer
        /// </summary>
        [Required]
        public string ProduceGroup { get; set; }
        /// <summary>
        /// 标题，默认值：topic_upm_mo_job_transfer
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// 标签，默认值：tag_upm_mo_job_transfer
        /// </summary>
        [Required]
        public string Tag { get; set; }
        /// <summary>
        /// 文件信息
        /// </summary>
        public FileMessageDto FileMessage { get; set; }
    }


}
