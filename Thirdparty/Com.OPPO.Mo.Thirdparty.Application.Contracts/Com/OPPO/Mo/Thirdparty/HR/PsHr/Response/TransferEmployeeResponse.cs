using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Response
{
    public class TransferEmployeeResponse
    {
        /// <summary>
        /// 绩效标识
        /// </summary>
        public string RateFlag { get; set; }
        

        /// <summary>
        /// 转正标识
        /// </summary>
        public string ProbationFlag { get; set; }
        
        /// <summary>
        /// 职族
        /// </summary>
        public string ClanId { get; set; }
        
    }
}
