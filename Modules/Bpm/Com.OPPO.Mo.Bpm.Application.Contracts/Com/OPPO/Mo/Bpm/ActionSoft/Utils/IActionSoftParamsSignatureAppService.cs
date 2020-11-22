using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Bpm.ActionSoft.Utils
{
    /// <summary>
    /// ActionSoft参数签名应用服务接口
    /// </summary>
    public interface IActionSoftParamsSignatureAppService : IApplicationService
    {
        /// <summary>
        /// 获取参数签名
        /// </summary>
        /// <param name="params">参数s</param>
        /// <returns></returns>
        Task<Result<string>> GetParamsSignature(Dictionary<string, string> @params);

    }
}
