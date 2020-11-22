using Com.OPPO.Mo.Thirdparty.HR.PsHr.Request;
using System.Collections.Generic;

namespace Com.OPPO.Mo.Thirdparty.Hr.PsHr.Request
{
    public class SalaryDockRequest : PsHrBaseRequest
    {
        public List<SalaryInfo> data { get ; set ; }
    }
}
