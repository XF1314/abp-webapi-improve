using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Plm.Requests
{

    public class QueryParentInfoRequest : BaseEsbRequest
    {

        public string sourcePartNumber { get; set; }

        public string replacePartNumber { get; set; }
    }
}
