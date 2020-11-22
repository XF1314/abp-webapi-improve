using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Dtos
{


    public class PositionInformationQueryDto
    {
        /// <summary>
        /// 集合ID,非必填
        /// </summary>
        public string SetId { get; set; }

        /// <summary>
        /// 通道,非必填
        /// </summary>
        public string JobFunction { get; set; }

        /// <summary>
        /// 专业领域,非必填
        /// </summary>
        public string JobSubFunc { get; set; }

        /// <summary>
        /// 职族,非必填
        /// </summary>
        public string ClanId { get; set; }
    }
}
