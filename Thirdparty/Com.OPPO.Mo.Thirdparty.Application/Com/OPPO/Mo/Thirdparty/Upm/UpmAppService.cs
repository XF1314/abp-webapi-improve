using Com.OPPO.Mo.Thirdparty.Upm.Dtos;
using Com.OPPO.Mo.Thirdparty.Upm.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.Upm
{

    [Authorize]
    public class UpmAppService : ThirdpartyAppServiceBase, IUpmAppService
    {
        private readonly IConfiguration _configuration;
        private readonly IUpmEsbService _EsbService;

        public UpmAppService(
            IConfiguration configuration,
            IUpmEsbService EsbService)
        {
            _configuration = configuration;
            _EsbService = EsbService;
        }

        /// <summary>
        /// UPM权限变更通知【第三方接口：/oppo/upm/delivery/mq】
        /// </summary>
        /// <param name="authorityChangeDto"></param>
        /// <returns></returns>
        public async Task<Result> AuthorityChangeToUPM(AuthorityChangeDto authorityChangeDetail)
        {
            var model = ObjectMapper.Map<AuthorityChangeDto, AuthorityChangeDetail>(authorityChangeDetail);
            AuthorityChangeRequest query = new AuthorityChangeRequest
            {
                AuthorityChangeDetail = JsonConvert.SerializeObject(model)
            };
            var response = await _EsbService.AuthorityChangeToUPM(query);
            if (response.success == "true")
                return Result.Ok(response.message);
            else
            {
                var message = $"【{response.resultCode}】{response.cause}";
                Logger.LogWarning(message);
                return Result.FromError(message);
            }
        }
    }
    }
