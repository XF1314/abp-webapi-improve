using Com.OPPO.Mo.Thirdparty.Sms.Dtos;
using Com.OPPO.Mo.Thirdparty.Sms.Requests;
using Com.OPPO.Mo.Thirdparty.Sms.Responses;
using Com.OPPO.Mo.Thirdparty.Sms.Services;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.Sms
{
    /// <summary>
    /// 短信发送应用服务
    /// </summary>
    [Authorize]
    public class SmsAppService : ThirdpartyAppServiceBase, ISmsAppService
    {
        private readonly ISmsWebApiService _smsWebApiService;
        public SmsAppService(ISmsWebApiService smsAppService)
        {
            _smsWebApiService = smsAppService;
        }

        /// <summary>
        /// 短信发送(新)
        /// </summary>
        /// <param name="smsInput">短信发送实体信息</param>
        /// <returns></returns>
        public async Task<Result<SmsDto>> SingleSms(SmsInput smsInput)
        {
            var info = new SmsRequest
            {
                Mobile = smsInput.Mobile,
                MsgInfo = new SmsInfo
                {
                    MsgBody = new SmsContent
                    {
                        Content = smsInput.Content
                    },
                    MsgType = 1
                },               
            };

            var response = await _smsWebApiService.SingleSms(info);

            var res = ObjectMapper.Map<SmsResponse, SmsDto>(response);

            return Result.FromData(res);

        }
    }
}
