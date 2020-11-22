using Com.OPPO.Mo.Thirdparty.Common.EmailSend.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.Common.EmailSend
{

    /// <summary>
    /// PeopleSoft加班申请Esb服务接口
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.EsbHost)]
    public interface IEmailSendWebApiService : IHttpApi
    {
        /// <summary>
        /// 邮件发送接口
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("/oppo/common/email_send")]
        Task<EsbResponse> EmailSend([JsonMulitpartText]EmailSendRequest request);


    }

}
