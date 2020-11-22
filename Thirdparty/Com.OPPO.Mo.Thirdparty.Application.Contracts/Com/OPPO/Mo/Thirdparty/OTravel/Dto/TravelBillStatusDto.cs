using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.OTravel.Dto
{
    public class TravelBillStatusDto
    {
        /// <summary>
        /// 来源Key，客户系统的流程单号
        /// </summary>
       [Required]
        public string sourceKey { get; set; }
        /// <summary>
        /// 出差单状态
        /// </summary>
        [Required] 
        public string currentStatus { get; set; }
    }
}
