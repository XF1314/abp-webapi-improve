using Com.OPPO.Mo.Bpm.ActionSoft.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Bpm.ActionSoft
{
    /// <summary>
    /// ActionSoft工具
    /// </summary>
    [Area("actionsoft")]
    [Route("openapi/actionsoft/utility")]
    [RemoteService(Name = BpmRemoteServiceConsts.RemoteServiceName)]
    public class ActionSoftUtilityController : AbpController, IActionSoftParamsSignatureAppService
    {
        private readonly IActionSoftParamsSignatureAppService _actionSoftParamsSignatureAppService;

        /// <summary>
        /// <see cref="ActionSoftUtilityController"/>
        /// </summary>
        public ActionSoftUtilityController(IActionSoftParamsSignatureAppService actionSoftParamsSignatureAppService)
        {
            _actionSoftParamsSignatureAppService = actionSoftParamsSignatureAppService;
        }

        /// <summary>
        /// 获取参数签名
        /// </summary>
        /// <param name="params">参数s</param>
        /// <returns></returns>
        [HttpPost("get-params-signature")]
        public async Task<Result<string>> GetParamsSignature(Dictionary<string, string> @params)
        {
            return await _actionSoftParamsSignatureAppService.GetParamsSignature(@params);
        }
    }
}
