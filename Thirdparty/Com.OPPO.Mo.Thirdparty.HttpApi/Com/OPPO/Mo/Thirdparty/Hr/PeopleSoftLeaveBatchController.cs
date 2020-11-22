using Com.OPPO.Mo.Thirdparty.Hr.Public.Responses;
using Com.OPPO.Mo.Thirdparty.Hr.Responses;
using Com.OPPO.Mo.Thirdparty.Hr.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Thirdparty.Hr.PeopleSoft.LeaveBatch
{
    [Area("hr")]
    [Route("api/mo/thirdparty/hr/leave-batch")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class PeopleSoftLeaveBatchController : AbpController, ILeaveBatchAppService
    {
        private readonly ILeaveBatchAppService _leaveBatchAPPService;
        public PeopleSoftLeaveBatchController(ILeaveBatchAppService leaveBatchAppService)
        {
            _leaveBatchAPPService = leaveBatchAppService;
        }
        /// <summary>
        /// 员工批量请假申请，请假结束数据推送ps
        /// </summary>
        /// <param name="LeaveBatchPushInput">请假信息详情</param>
        /// <returns></returns>
        [HttpPost]
        [Route("ps-push")]
        public async Task<Result> LeaveBatchPush([FromBody] BatchLeavePushInfo LeaveBatchPushInput)
        {
            return await _leaveBatchAPPService.LeaveBatchPush(LeaveBatchPushInput);
        }
        /// <summary>
        /// 员工批量请假申请，请假结束数据推送一卡通
        /// </summary>
        /// <param name="LeaveBatchPushInput">请假信息详情</param>
        /// <returns></returns>
        [HttpPost]
        [Route("visitors-push")]
        public async Task<Result> LeaveBatchVisitorsPush([FromBody] BatchLeavePushInfo LeaveBatchPushInput)
        {
            return await _leaveBatchAPPService.LeaveBatchVisitorsPush(LeaveBatchPushInput);
        }
    }
}
