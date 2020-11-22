using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Megvii.Response
{

    public class Page
    {
        /// <summary>
        /// 总数
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        public int Current { get; set; }
        /// <summary>
        /// 页条数
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int Total { get; set; }
    }

    public class BaseMegviiResponse
    {
        /// <summary>
        /// 返回码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 分页信息
        /// </summary>
        public Page Page { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Desc { get; set; }
    }

    public class BaseMegviiResponse<TData>: BaseMegviiResponse
    {
        /// <summary>
        /// 主数据
        /// </summary>
        public TData Data { get; set; }
    }


}
