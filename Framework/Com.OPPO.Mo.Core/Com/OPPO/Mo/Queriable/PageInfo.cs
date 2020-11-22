using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Queriable
{
    /// <summary>
    /// 分页信息
    /// </summary>
    public class PageInfo : IPageInfo
    {
        /// <summary>
        /// 偏移量
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 初始化 <see cref="PageInfo" /> 类的新实例。
        /// </summary>
        public PageInfo( int offset = 0, int count = 20)
        {
            Offset = offset;
            Count = count;
        }
    }

    /// <summary>
    /// 分页信息
    /// </summary>
    public interface IPageInfo 
    {
        /// <summary>
        /// 偏移量
        /// </summary>
        int Offset { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        int Count { get; set; }
    }
}
