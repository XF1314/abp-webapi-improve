using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Megvii.Dto
{
    public class AddPhotoRequestDto
    {
        /// <summary>
        /// 图片文件,必填
        /// </summary>
        [Required]
        public byte[] Photo { get; set; }
        /// <summary>
        /// subject_id,非必填
        /// </summary>
        public string SubjectId { get; set; }
        /// <summary>
        /// old_photo_id,非必填
        /// </summary>
        public string OldPhotoId { get; set; }
    }
}
