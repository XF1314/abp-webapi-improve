using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Paas.Responses
{

    /// <summary>
    /// Paas平台数据Response
    /// </summary>
    public class PaasDataResponse<TData> : PaasBaseResponse
    {
        public PaasDataResponse()
        {
            Data = default;
        }

        public TData Data { get; set; }

    }
}
