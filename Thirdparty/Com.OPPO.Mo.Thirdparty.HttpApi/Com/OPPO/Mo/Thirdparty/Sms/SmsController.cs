using Com.OPPO.Mo.Thirdparty.Sms.Dtos;
using Com.OPPO.Mo.Thirdparty.Sms;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Thirdparty.SMS
{
    /// <summary>
    /// Sms 资源
    /// </summary>
    [Area("sms")]
    [Route("api/mo/thirdparty/sms")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class SmsController : AbpController, ISmsAppService
    {
        private readonly ISmsAppService _smsAppService;

        public SmsController(ISmsAppService smsAppService)
        {
            _smsAppService = smsAppService;
        }

        /// <summary>
        /// 短信发送 【第三方接口：/gate/api/single_sms】
        /// </summary>
        /// <param name="smsInput">实体信息</param>
        /// <returns></returns>
        [HttpPost("single-sms")] 
        public async Task<Result<SmsDto>> SingleSms(SmsInput smsInput)
        {
            return await _smsAppService.SingleSms(smsInput);
        }
    }
}
