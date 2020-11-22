using Com.OPPO.Mo.Thirdparty.Plm.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Plm.Responses
{
    public class SubstitutesResponse: SubstitutesDto
    {
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ProcessResult { get; set; }
        /// <summary>
        /// --2 为成功，3为失败，7为失效，1 为处理中
        /// </summary>
        public string ProcessFlag { get; set; }
        /// <summary>
        /// ERP默认sysdate
        /// </summary>
        public string CreationDate { get; set; }
    }
}
