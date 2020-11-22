using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty
{
    /// <summary>
    /// 响应结果
    /// </summary>
    public interface IResponseResult
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        bool IsOk { get; }
    }
}
