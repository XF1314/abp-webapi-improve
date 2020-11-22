
using Com.OPPO.Mo.Thirdparty.Common.EmailSend;
using Com.OPPO.Mo.Thirdparty.Common.EmailSend.Dto;
using Com.OPPO.Mo.Thirdparty.Common.EmailSend.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.Common
{

    [Authorize]
    public class EmailSendAppService : ThirdpartyAppServiceBase, IEmailSendAppService
    {
        private readonly IConfiguration _configuration;
        private readonly IEmailSendWebApiService _EsbService;

        public EmailSendAppService(
            IConfiguration configuration,
            IEmailSendWebApiService peopleSoftLeaveEsbService)
        {
            _configuration = configuration;
            _EsbService = peopleSoftLeaveEsbService;
        }


        public async Task<Result> EmailSend(EmailSendDto model)
        {
            var request = ObjectMapper.Map<EmailSendDto, EmailSendRequest>(model);

            var response = await _EsbService.EmailSend(request);

            if (response.IsOk)
                return Result.Ok(response.Body.Message);
            else
            {
                var message = $"【{response.Body.BussinessCode}】{response.Body.Message}";
                Logger.LogWarning(message);
                return Result.FromError(message);
            }
        }

    }
}
