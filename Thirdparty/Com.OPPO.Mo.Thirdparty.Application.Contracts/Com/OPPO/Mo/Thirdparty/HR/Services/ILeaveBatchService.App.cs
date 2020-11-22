using Com.OPPO.Mo.Thirdparty.Hr.Public.Responses;
using Com.OPPO.Mo.Thirdparty.Hr.Responses;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.Hr.Services
{
    public interface ILeaveBatchAppService: IApplicationService
    {
        Task<Result> LeaveBatchPush(BatchLeavePushInfo LeaveBatchPushInput);
        Task<Result> LeaveBatchVisitorsPush(BatchLeavePushInfo LeaveBatchPushInput);
    }
}
