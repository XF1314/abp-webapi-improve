using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Response
{


    public class JobFuncs
    {
        /// <summary>
        /// 通道代码
        /// </summary>
        public string JobFunction { get; set; }
        /// <summary>
        /// 通道描述
        /// </summary>
        public string JobFuncDescr { get; set; }
    }

    public class JobFunctionListResponse<TData>
    {
        /// <summary>
        /// 行数
        /// </summary>
        public int totalRows { get; set; }
        /// <summary>
        /// 通道数据
        /// </summary>
        public TData jobFuncs { get; set; }
    }

}
