using Com.OPPO.Mo.Thirdparty.Megvii.Request;
using Com.OPPO.Mo.Thirdparty.Megvii.Response;
using Com.OPPO.Mo.Thirdparty.Visitors.Dtos;
using Com.OPPO.Mo.Thirdparty.Visitors.Request;
using Com.OPPO.Mo.Thirdparty.Visitors.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.Visitors
{
    /// <summary>
    /// 外来人员进入车间申请
    /// </summary>
    public interface IVisitorAppService : IApplicationService
    {

        /// <summary>
        /// 门禁道闸权限下发
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<Result> AuthercateDataPush(List<AuthercateDataDto> query);

        /// <summary>
        /// 门禁类型视图【第三方接口：/oppo/visitors/get_mjtype】
        /// </summary>
        /// <returns></returns>
        Task<Result<List<Devices>>> GetAccessControlTypeView();

        /// <summary>
        /// 门禁类型视图【第三方接口：/oppo/visitors/get_mo_MJDetail】
        /// </summary>
        /// <returns></returns>
        Task<Result<List<Devices>>> GetAccessControlTypeViewNew();
    }
}
