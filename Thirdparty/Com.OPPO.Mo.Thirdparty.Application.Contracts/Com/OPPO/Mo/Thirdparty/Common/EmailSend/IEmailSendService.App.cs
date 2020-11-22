using Com.OPPO.Mo.Thirdparty.Common.EmailSend.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.Common.EmailSend
{
    /// <summary>
    /// PeopleSoft邮件发送应用服务接口
    /// </summary>
    public interface IEmailSendAppService : IApplicationService
    {
        /// <summary>
        /// 邮件发送接口
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Result> EmailSend(EmailSendDto model);


    }
}
