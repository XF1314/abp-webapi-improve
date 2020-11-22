using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Paas.Responses
{
    /// <summary>
    /// Paas平台Payload响应
    /// </summary>
    /// <typeparam name="TPayload"></typeparam>
    public class PaasPayloadResponse<TPayload> : PaasBaseResponse
    {
        public PaasPayloadResponse()
        {
            Payload = default;
        }

        public TPayload Payload { get; set; }
    }
}
