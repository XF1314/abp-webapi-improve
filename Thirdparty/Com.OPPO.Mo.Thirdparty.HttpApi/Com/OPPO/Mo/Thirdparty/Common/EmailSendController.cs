using Com.OPPO.Mo.Thirdparty.Common.EmailSend;
using Com.OPPO.Mo.Thirdparty.Common.EmailSend.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Thirdparty.Common
{

    /// <summary>
    /// ps公用发送邮件接口服务
    /// </summary>
    [Area("common")]
    [Route("api/mo/thirdparty/ps/common")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class EmailSendController : AbpController, IEmailSendAppService
    {
        private readonly IEmailSendAppService _peopleSoftAppService;

        public EmailSendController(IEmailSendAppService peopleSoftAppService)
        {
            _peopleSoftAppService = peopleSoftAppService;
        }



        /// <summary>
        /// 邮件发送接口【ps接口： /oppo/common/email_send】
        /// </summary>
        /// <param name="model">邮件信息</param>
        /// <returns></returns>
        [HttpPost("email-send")]
        public async Task<Result> EmailSend([FromBody]EmailSendDto model)
        {
            return await _peopleSoftAppService.EmailSend(model);
        }
    }
}
