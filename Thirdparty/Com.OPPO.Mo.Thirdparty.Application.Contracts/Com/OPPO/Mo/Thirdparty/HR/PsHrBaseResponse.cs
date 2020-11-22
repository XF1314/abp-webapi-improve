using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Hr
{
    public class PsHrBaseResponse
    {
        public string code { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
       
    }

    public class PsHrBaseResponse<TData>: PsHrBaseResponse
    {
        public TData datas { get; set; }
    }
}
