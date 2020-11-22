using Com.OPPO.Mo.Thirdparty.Adap.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.Adap
{

    /// <summary>
    /// 数字行政接口服务
    /// </summary>
    public interface IAdapAppService : IApplicationService
    {

        /// <summary>
        /// 推送出差申请数据到数字行政
        /// </summary>
        /// <param name="queryDto"></param>
        /// <returns></returns>
        Task<Result> TravelInfoPush(TravelInfoDto queryDto);


    }

}
