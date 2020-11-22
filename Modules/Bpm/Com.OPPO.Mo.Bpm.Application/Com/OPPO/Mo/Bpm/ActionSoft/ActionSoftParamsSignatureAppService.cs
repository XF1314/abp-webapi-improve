using Com.OPPO.Mo.Bpm.ActionSoft.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Bpm.ActionSoft
{
    /// <summary>
    /// ActionSoft参数签名应用服务
    /// </summary>
    [Authorize]
    public class ActionSoftParamsSignatureAppService : BpmAppServiceBase, IActionSoftParamsSignatureAppService
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// <see cref="ActionSoftParamsSignatureAppService"/>
        /// </summary>
        public ActionSoftParamsSignatureAppService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <inheritdoc/>
        public async Task<Result<string>> GetParamsSignature(Dictionary<string, string> @params)
        {
            if (@params is null || !@params.Any())
                return Result.FromError<string>($"{@params}不能为空");
            else
            {
                var signatureKey = _configuration[BpmSettingNames.ActionSoftWebApiSignKey];
                var stringBuilder = new StringBuilder();
                stringBuilder.Append(signatureKey);

                foreach (var param in @params.OrderBy(t => t.Key))
                {
                    stringBuilder.AppendFormat("{0}{1}", param.Key, param.Value);
                }

                return await Task.FromResult(Result.FromData(stringBuilder.ToString().HmacMd5Digest(signatureKey)));
            }
        }

    }
}
