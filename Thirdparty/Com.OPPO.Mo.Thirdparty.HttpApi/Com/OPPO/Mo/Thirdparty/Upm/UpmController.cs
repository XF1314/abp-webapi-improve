using Com.OPPO.Mo.Thirdparty.Upm.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Thirdparty.Upm
{
    /// <summary>
    /// oppo/upm
    /// </summary>
    [Area("ump")]
    [Route("api/mo/thirdparty/ps/ump")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class UpmController : AbpController, IUpmAppService
    {
        private readonly IUpmAppService _AppService;

        public UpmController(IUpmAppService AppService)
        {
            _AppService = AppService;
        }

        /// <summary>
        /// UPM权限变更通知【第三方接口：/oppo/upm/delivery/mq】
        /// </summary>
        /// <param name="authorityChangeDetail"></param>
        /// <returns></returns>
        [HttpPost("authority-change-to-upm")]
        public async Task<Result> AuthorityChangeToUPM(AuthorityChangeDto authorityChangeDetail)
        {
            return await _AppService.AuthorityChangeToUPM(authorityChangeDetail);
        }

    }
}
