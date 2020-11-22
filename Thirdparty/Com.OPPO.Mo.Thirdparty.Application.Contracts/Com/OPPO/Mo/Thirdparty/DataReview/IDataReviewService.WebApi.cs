using Com.OPPO.Mo.Thirdparty.DataReview.Request;
using Com.OPPO.Mo.Thirdparty.DataReview.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace Com.OPPO.Mo.Thirdparty.DataReview
{

    /// <summary>
    /// 数据处理平台
    /// </summary>
    [AutoReturn(EnsureSuccessStatusCode = false)]
    [TraceFilter(OutputTarget = OutputTarget.Console)]
    [ConfigurableHttpHost(ThirdpartySettingNames.DataReviewWebApiHost)]
    public interface IDataReviewWebApiService : IHttpApi
    {

        /// <summary>
        /// 更新单据状态
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("/api/data-review/update-status")]
        Task<UpdateStatusResponse> UpdateStatus([JsonContent]UpdateStatusInfo request);


    }
}
