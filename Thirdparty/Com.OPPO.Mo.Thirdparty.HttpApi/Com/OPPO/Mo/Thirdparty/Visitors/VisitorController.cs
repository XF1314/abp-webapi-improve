
using Com.OPPO.Mo.Thirdparty.Visitors.Dtos;
using Com.OPPO.Mo.Thirdparty.Visitors.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Thirdparty.Visitors
{

    /// <summary>
    /// 外来人员进入车间申请/保密协议/
    /// </summary>
    [Area("visitors")]
    [Route("api/mo/thirdparty/visitors")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class VisitorController : AbpController, IVisitorAppService
    {
        private readonly IVisitorAppService _outsidersAppService;

        public VisitorController(IVisitorAppService outsidersAppService)
        {
            _outsidersAppService = outsidersAppService;
        }

        /// <summary>
        /// 门禁道闸权限下发【第三方接口：/oppo/visitors/authercate_data_push】
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("authercate-data-push")]
        public async Task<Result> AuthercateDataPush(List<AuthercateDataDto> dto)
        {
            return await _outsidersAppService.AuthercateDataPush(dto);
        }

        /// <summary>
        /// 门禁类型视图【第三方接口：/oppo/visitors/get_mjtype】
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-accesscontrol-type-view")]
        public async Task<Result<List<Devices>>> GetAccessControlTypeView()
        {
            return await _outsidersAppService.GetAccessControlTypeView();
        }

        /// <summary>
        /// 门禁类型视图(新)【第三方接口：/oppo/visitors/get_mo_MJDetail】
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-accesscontrol-type-view-new")]
        public async Task<Result<List<Devices>>> GetAccessControlTypeViewNew()
        {
            return await _outsidersAppService.GetAccessControlTypeViewNew();
        }

    }
}
