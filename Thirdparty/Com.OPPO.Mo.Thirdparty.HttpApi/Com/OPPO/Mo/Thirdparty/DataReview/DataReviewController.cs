using Com.OPPO.Mo.Thirdparty.DataReview.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Thirdparty.DataReview
{

    /// <summary>
    /// 数据处理平台
    /// </summary>
    [Area("datareview")]
    [Route("api/mo/thirdparty/datareview")]
    [RemoteService(Name = ThirdpartyRemoteServiceConsts.RemoteServiceName)]
    public class DataReviewController : AbpController, IDataReviewAppService
    {
        private readonly IDataReviewAppService _DataReviewAppService;

        public DataReviewController(IDataReviewAppService DataReviewAppService)
        {
            _DataReviewAppService = DataReviewAppService;
        }

        /// <summary>
        /// 更新单据状态【第三方接口：/api/data-review/update-status】
        /// </summary>
        /// <param name="queryDto"></param>
        /// <returns></returns>
        [HttpPost("update-status")]
        public async Task<Result> UpdateStatus(UpdateStatusInfo queryDto)
        {
            return await _DataReviewAppService.UpdateStatus(queryDto);
        }


    }
}
