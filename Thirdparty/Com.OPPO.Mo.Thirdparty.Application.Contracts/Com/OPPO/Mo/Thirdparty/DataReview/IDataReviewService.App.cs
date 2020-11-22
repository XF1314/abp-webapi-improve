using Com.OPPO.Mo.Thirdparty.DataReview.Request;
using Com.OPPO.Mo.Thirdparty.DataReview.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.DataReview
{

    /// <summary>
    /// 数据处理平台
    /// </summary>
    public interface IDataReviewAppService : IApplicationService
    {

        /// <summary>
        /// 更新单据状态
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<Result> UpdateStatus([JsonContent]UpdateStatusInfo request);


    }
}
