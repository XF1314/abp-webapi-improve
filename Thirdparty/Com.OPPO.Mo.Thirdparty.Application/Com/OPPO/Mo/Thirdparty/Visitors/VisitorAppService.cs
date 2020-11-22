using Com.OPPO.Mo.Thirdparty.Megvii.Request;
using Com.OPPO.Mo.Thirdparty.Megvii.Response;
using Com.OPPO.Mo.Thirdparty.Visitors.Dtos;
using Com.OPPO.Mo.Thirdparty.Visitors.Request;
using Com.OPPO.Mo.Thirdparty.Visitors.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.Visitors
{
    [Authorize]
    public class VisitorAppService: ThirdpartyAppServiceBase, IVisitorAppService
    {
        private readonly Lazy<IConfiguration> _lazyconfiguration;
        private readonly IConfiguration _configuration;
   
        private readonly IVisitorsApiService  _VisitorsApiService;

        public VisitorAppService(Lazy<IConfiguration> lazyconfiguration,
            IConfiguration configuration
           , IVisitorsApiService VisitorsApiService)
        {
            _lazyconfiguration = lazyconfiguration;
            _configuration = configuration;
               _VisitorsApiService = VisitorsApiService;
        }

        /// <summary>
        /// 门禁道闸权限下发
        /// </summary>
        /// <param name="authercateDataDto"></param>
        /// <returns></returns>
        public async Task<Result> AuthercateDataPush(List<AuthercateDataDto> authercateDataDto)
        {

            AuthercateDataPush query = new AuthercateDataPush
            {
                Data = JsonConvert.SerializeObject(authercateDataDto)
            };
            var response = await _VisitorsApiService.AuthercateDataPush(query);
            if (response.IsOk)
                return Result.Ok();
            else
            {
                var message = $"【{response.Body.BussinessCode}】{response.Body.Message}";
                Logger.LogWarning(message);
                return Result.FromError
                    
                    (message);
            }
        }


        /// <summary>
        /// 门禁类型视图【第三方接口：/oppo/visitors/get_mjtype】
        /// </summary>
        /// <returns></returns>
        public async Task<Result<List<Devices>>> GetAccessControlTypeView()
        {

            var response = await _VisitorsApiService.GetAccessControlTypeView(new BaseEsbRequest());
            if (response.response!=null)
                return Result.FromData(response.response.devices);
            else
            {
                var message = $"【{response}】";
                Logger.LogWarning(message);
                return Result.FromError<List<Devices>>(message);
            }
        }

        /// <summary>
        /// 门禁类型视图(新)【第三方接口：/oppo/visitors/get_mo_MJDetail】
        /// </summary>
        /// <returns></returns>
        public async Task<Result<List<Devices>>> GetAccessControlTypeViewNew()
        {

            var response = await _VisitorsApiService.GetAccessControlTypeViewNew(new BaseEsbRequest());
            if (response.response != null)
                return Result.FromData(response.response.results);
            else
            {
                var message = $"【{response}】";
                Logger.LogWarning(message);
                return Result.FromError<List<Devices>>(message);
            }
        }
    }
}
