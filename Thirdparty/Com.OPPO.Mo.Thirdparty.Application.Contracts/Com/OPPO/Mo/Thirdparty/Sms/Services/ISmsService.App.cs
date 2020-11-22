using Com.OPPO.Mo.Thirdparty.Sms.Dtos;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.Sms
{
    /// <summary>
    /// Sms 接口
    /// </summary>
    public interface ISmsAppService : IApplicationService
    {
        /// <summary>
        /// 短信发送(新)
        /// </summary>
        /// <param name="smsInput">短信发送实体信息</param>
        /// <returns></returns>
        Task<Result<SmsDto>> SingleSms(SmsInput smsInput);
    }
}
