using AutoMapper.Configuration;
using Com.OPPO.Mo.Thirdparty.DataReview.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.DataReview
{

    [Authorize]
    public class DataReviewAppService : ThirdpartyAppServiceBase, IDataReviewAppService
    {
        private readonly IDataReviewWebApiService _DataReviewWebApiService;

        public DataReviewAppService(IDataReviewWebApiService DataReviewWebApiService)
        {
            _DataReviewWebApiService = DataReviewWebApiService;
        }


        public async Task<Result> UpdateStatus(UpdateStatusInfo queryDto)
        {
            var response = await _DataReviewWebApiService.UpdateStatus(queryDto);
            if (response.status == "201")
                return Result.Ok();
            else
            {
                var message = $"【{response.status}】{response.msg}";
                Logger.LogWarning(message);
                return Result.FromError(message);
            }
        }




    }
}
