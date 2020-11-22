using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Response
{
    public class SubJobFunction
    {
        /// <summary>
        /// 通道代码
        /// </summary>
        public string JobFunction { get; set; }
        /// <summary>
        /// 领域代码
        /// </summary>
        public string SubJobFunc { get; set; }
        /// <summary>
        /// 领域描述
        /// </summary>
        public string SubJobFuncDescr { get; set; }
    }

    public class SubJobFuncResponse<TData>
    {
        /// <summary>
        /// 行数
        /// </summary>
        public int totalRows { get; set; }
        /// <summary>
        /// 通道数据
        /// </summary>
        public TData subJobFuncs { get; set; }
    }

}
