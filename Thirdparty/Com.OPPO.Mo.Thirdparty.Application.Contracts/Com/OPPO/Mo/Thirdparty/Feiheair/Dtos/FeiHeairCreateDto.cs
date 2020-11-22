using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Feiheair.Dtos
{
    /// <summary>
    /// 出差申请返回信息
    /// </summary>
    public class FeiHeairCreateDto
    {
        /// <summary>
        /// 错误代码(0表示成功，其它为失败)
        /// </summary>
        public int ErrCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrMsg { get; set; }
    }
}
