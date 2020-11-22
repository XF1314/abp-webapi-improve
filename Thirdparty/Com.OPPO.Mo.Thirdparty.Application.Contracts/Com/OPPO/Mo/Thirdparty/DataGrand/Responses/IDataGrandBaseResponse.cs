using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataGrand.Responses
{
    /// <summary>
    /// 达观搜索响应模型接口
    /// </summary>
    public interface IDataGrandBaseResponse
    {
        /// <summary>
        /// 响应状态
        /// </summary>
        DataGrandResponseStatus Status { get; set; }

        /// <summary>
        /// 本次请求Id（用于追踪问题）
        /// </summary>
        string RequestId { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        bool IsOk { get; }
    }
}
