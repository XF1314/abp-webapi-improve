using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;
using Com.OPPO.Mo.Thirdparty.Paas;
using Com.OPPO.Mo.Thirdparty.Paas.Requests;
using Microsoft.Extensions.Configuration;

namespace Com.OPPO.Mo.BpmService.Controllers
{
    /// <summary>
    /// 测试
    /// </summary>
    [Area("test")]
    [Route("api/mo/bpm/test")]
    public class TestController : AbpController
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// <see cref="TestController"/>
        /// </summary>
        public TestController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// 正则匹配
        /// </summary>
        /// <param name="string">字符串</param>
        /// <param name="pattern">模式串</param>
        /// <returns></returns>
        [HttpPost("regex")]
        public async Task<Result<string>> RegexMatchTest(string @string, string pattern)
        {
            var match = Regex.Match(@string.Replace(" ", ""), pattern, RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);
            if (!match.Success)
                return Result.FromCode<string>(ResultCode.NoData);
            else
            {
                return await Task.FromResult(Result.FromData(match.Value));
            }
        }

        /// <summary>
        /// 获取Paas平台访问Token
        /// </summary>
        /// <returns></returns>
        [HttpGet("paas/access-token")]
        public async Task<Result<string>> GetPaasAccessToken()
        {
            var paasAuthenticationWebApiService = ServiceProvider.GetRequiredService<IPaasAuthenticationWebApiService>();
            var paasAppLoginRequest = new PaasAppLoginRequest
            {
                AppTag = _configuration[PaasSettingNames.PaasAppTag],
                AppEncrptedSecret = _configuration[PaasSettingNames.PaasAppSecret]
            };
            var loginResponse = await paasAuthenticationWebApiService.AppLogin(paasAppLoginRequest, _configuration[PaasSettingNames.PaasTenantId]);
            if (loginResponse.IsOk)
                return Result.FromData(loginResponse.Payload.AccessToken);
            else
            {
                return Result.FromError<string>(loginResponse.Message);
            }
        }
    }
}
