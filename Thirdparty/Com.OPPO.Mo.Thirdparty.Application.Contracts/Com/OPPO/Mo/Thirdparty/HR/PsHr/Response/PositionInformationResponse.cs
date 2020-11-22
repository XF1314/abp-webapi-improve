using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Response
{
    public class PositionInformationResponse
    {
        /// <summary>
        /// 集合ID
        /// </summary>
        public string SetId { get; set; }

        /// <summary>
        /// 岗位代码
        /// </summary>
        public string JobCode { get; set; }

        /// <summary>
        /// 岗位描述
        /// </summary>
        public string JobDescription { get; set; }


        /// <summary>
        /// 岗位简单描述
        /// </summary>
        public string JobShortDescription { get; set; }

    }

}
