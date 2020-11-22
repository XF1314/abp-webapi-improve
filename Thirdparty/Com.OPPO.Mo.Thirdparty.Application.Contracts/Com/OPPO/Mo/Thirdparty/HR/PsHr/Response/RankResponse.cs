using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Response
{
    public class RankResponse
    {
        /// <summary>
        /// 集合ID
        /// </summary>
        public string SetId { get; set; }


        /// <summary>
        /// 职级代码
        /// </summary>
        public string RankCode { get; set; }

        /// <summary>
        ///  职级描述
        /// </summary>
        public string RankDescription { get; set; }


        /// <summary>
        ///  职级简单描述
        /// </summary>
        public string RankShortDescription { get; set; }

    }

}
