using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Queriable
{
    /// <summary>
    /// 分页查询
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public class PageQuery<TEntity> : Query<TEntity>, IPageInfo where TEntity : class
    {
        /// <summary>
        /// 偏移量
        /// </summary>
        [JsonRequired]
        public int Offset { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [JsonRequired]
        public int Count { get; set; }
    }
}
