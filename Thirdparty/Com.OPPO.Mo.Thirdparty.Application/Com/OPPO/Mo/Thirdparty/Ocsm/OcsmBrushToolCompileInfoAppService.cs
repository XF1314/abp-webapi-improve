using Com.OPPO.Mo.Thirdparty.Ocsm.Dtos;
using Com.OPPO.Mo.Thirdparty.Ocsm.Requests;
using Com.OPPO.Mo.Thirdparty.Ocsm.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.Ocsm
{
    /// <summary>
    /// Ocsm系统刷机编译信息应用服务
    /// </summary>
    [Authorize]
    public class OcsmBrushToolCompileInfoAppService : ThirdpartyAppServiceBase, IOcsmBrushToolCompileInfoAppService
    {
        private readonly IConfiguration _configuration;
        private readonly IOcsmBrushToolCompileInfoEsbService _ocsmBrushToolCompileInfoEsbService;
        private readonly IOcsmBrushToolCompileInfoWebApiService _ocsmBrushToolCompileInfoWebApiService;

        /// <inheritdoc/>
        public OcsmBrushToolCompileInfoAppService(
            IConfiguration configuration,
            IOcsmBrushToolCompileInfoEsbService ocsmBrushToolCompileInfoEsbService,
            IOcsmBrushToolCompileInfoWebApiService ocsmBrushToolCompileInfoWebApiService)
        {
            _configuration = configuration;
            _ocsmBrushToolCompileInfoEsbService = ocsmBrushToolCompileInfoEsbService;
            _ocsmBrushToolCompileInfoWebApiService = ocsmBrushToolCompileInfoWebApiService;
        }

        /// <inheritdoc/>
        public async Task<Result> AddDomesticBrushToolCompileInfo(OcsmBrushToolsCompileInfoAddInput ocsmBrushToolsCompileInfoAddInput)
        {
            if (string.IsNullOrWhiteSpace(ocsmBrushToolsCompileInfoAddInput.CompileInfo))
                return Result.FromError($"{ocsmBrushToolsCompileInfoAddInput.CompileInfo}不能为空。");
            else
            {
                //TODO:验证CompileInfo是否合格的Json格式
                var response = await _ocsmBrushToolCompileInfoEsbService.AddDomesticBrushToolCompileInfo(new OcsmBrushToolsCompileInfoAddRequest
                {
                    CompileInfo = ocsmBrushToolsCompileInfoAddInput.CompileInfo
                });

                if (response.IsOk)
                    return Result.Ok();
                else
                {
                    var message = $"【{response.Body?.BussinessCode}】{response.Body?.Message}";
                    Logger.LogError(message);
                    return Result.FromError(message);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result> AddExportBrushToolCompileInfo(OcsmBrushToolsCompileInfoAddInput ocsmBrushToolsCompileInfoAddInput)
        {
            if (string.IsNullOrWhiteSpace(ocsmBrushToolsCompileInfoAddInput.CompileInfo))
                return Result.FromError($"{ocsmBrushToolsCompileInfoAddInput.CompileInfo}不能为空。");
            else
            {
                //TODO:验证CompileInfo是否合格的Json格式
                var response = await _ocsmBrushToolCompileInfoEsbService.AddExportBrushToolCompileInfo(new OcsmBrushToolsCompileInfoAddRequest
                {
                    CompileInfo = ocsmBrushToolsCompileInfoAddInput.CompileInfo
                });

                if (response.IsOk)
                    return Result.Ok();
                else
                {
                    var message = $"【{response.Body?.BussinessCode}】{response.Body?.Message}";
                    Logger.LogError(message);
                    return Result.FromError(message);
                }
            }
        }

        /// <inheritdoc/>
        public async Task<Result> AddExportBrushToolCompileInfo_New(OcsmBrushToolsCompileInfoAddInput ocsmBrushToolsCompileInfoAddInput)
        {
            if (string.IsNullOrWhiteSpace(ocsmBrushToolsCompileInfoAddInput.CompileInfo))
                return Result.FromError($"{ocsmBrushToolsCompileInfoAddInput.CompileInfo}不能为空。");
            else
            {
                //TODO:验证CompileInfo是否合格的Json格式
                var encryptionKey = _configuration[ThirdpartySettingNames.OcsmEncryptionRijndaelKey];
                var encryptionIV = _configuration[ThirdpartySettingNames.OcsmEncryptionRijndaelIV];

                var encryptedBrushToolCompileInfo = EncryptCompileInfoByRijndael(encryptionKey, encryptionIV, ocsmBrushToolsCompileInfoAddInput.CompileInfo);
                var response = await _ocsmBrushToolCompileInfoWebApiService.AddExportBrushToolCompileInfo_New(new OcsmEncryptedBrushToolCompileInfoAddRequest
                {
                    EncryptedCompileInfo = encryptedBrushToolCompileInfo
                });

                if (response.IsOk)
                    return Result.Ok();
                else
                {
                    var message = $"【{response.Code}】{response.Message}->【{response.Body?.BussinessCode}】{response.Body?.Message}";
                    Logger.LogError(message);
                    return Result.FromError(message);
                }
            }
        }


        private string EncryptCompileInfoByRijndael(string key, string iv, string compileInfo)
        {
            var rijndaelManaged = new RijndaelManaged
            {
                Key = Encoding.UTF8.GetBytes(key),
                IV = Encoding.UTF8.GetBytes(iv),
                Mode = CipherMode.CBC
            };

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV), CryptoStreamMode.Write))
                using (var streamWriter = new StreamWriter(cryptoStream))
                    streamWriter.Write(compileInfo);

                return Convert.ToBase64String(memoryStream.ToArray());
            }
        }
    }
}

