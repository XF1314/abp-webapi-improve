using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Visitors.Response
{
    public class NewAccessControlTypeViewResponse
    {
        /// <summary>
        /// 返回信息
        /// </summary>
        public NewAccessControlTypeViewBody response { get; set; }
    }

    public class NewAccessControlTypeViewBody
    {

        /// <summary>
        /// 返回数据
        /// </summary>
        public List<Devices> results { get; set; }
    }



}
