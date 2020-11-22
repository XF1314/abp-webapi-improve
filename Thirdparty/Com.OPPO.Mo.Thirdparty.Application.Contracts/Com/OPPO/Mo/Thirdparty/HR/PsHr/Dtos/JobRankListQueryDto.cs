using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Dtos
{
    public class JobRankListQueryDto
    {
        /// <summary>
        /// 集合ID,必填
        /// </summary>
        [Required]
        public string SetId { get; set; }

        /// <summary>
        /// 岗位代码,非必填
        /// </summary>
        public string JobCode { get; set; }
    }
}
