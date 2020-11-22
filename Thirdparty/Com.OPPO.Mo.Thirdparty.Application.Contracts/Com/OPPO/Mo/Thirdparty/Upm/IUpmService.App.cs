using Com.OPPO.Mo.Thirdparty.Upm.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.Upm
{

    /// <summary>
    /// oppo/upm
    /// </summary>
    public interface IUpmAppService : IApplicationService
    {
        /// <summary>
        /// UPM权限变更通知【第三方接口：/oppo/upm/delivery/mq】
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<Result> AuthorityChangeToUPM(AuthorityChangeDto dto);
    }
}
