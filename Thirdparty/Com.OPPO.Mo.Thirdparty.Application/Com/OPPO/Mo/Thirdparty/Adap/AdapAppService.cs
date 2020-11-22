using Com.OPPO.Mo.Thirdparty.Adap.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.Adap
{

    [Authorize]
    public class AdapAppService : ThirdpartyAppServiceBase, IAdapAppService
    {
        private readonly IConfiguration _configuration;
        private readonly IAdapWebApiService _adapWebApiService;

        public AdapAppService(
            IConfiguration configuration,
            IAdapWebApiService  adapWebApiService)
        {
            _configuration = configuration;
            _adapWebApiService = adapWebApiService;
        }


        public async Task<Result> TravelInfoPush(TravelInfoDto queryDto)
        {
            var response = await _adapWebApiService.TravelInfoPush(queryDto);
            if (response.Code == 0)
                return Result.Ok(response.Body.Message);
            else
            {
                var message = $"【{response.Code}】{response.Message}";
                Logger.LogWarning(message);
                return Result.FromError(message);
            }
        }




    }


}
