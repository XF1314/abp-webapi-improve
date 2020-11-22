using Com.OPPO.Mo.Thirdparty.Erp.Dtos;
using Com.OPPO.Mo.Thirdparty.Plm;
using Com.OPPO.Mo.Thirdparty.Plm.Dtos;
using Com.OPPO.Mo.Thirdparty.Plm.Requests;
using Com.OPPO.Mo.Thirdparty.Plm.Responses;
using Com.OPPO.Mo.Thirdparty.Erp.Requests;
using Com.OPPO.Mo.Thirdparty.Erp.Responses;
using Com.OPPO.Mo.Thirdparty.Erp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.Plm
{
    /// <summary>
    /// 物料代用申请/
    /// </summary>
    [Authorize]
    public class PlmAppService : ThirdpartyAppServiceBase, IPlmAppService
    {
        /// <summary>
        /// 从ERP查询物料是否是制造件 【第三方接口：/oppo/plm/erp/erp_make_item】
        /// </summary>
        /// <param name="orgCode">组织代码,必填</param>
        /// <param name="itemCode">物料号,必填</param>
        /// <returns></returns>
        public async Task<Result<ItemMake>> QueryItemInfoToERP(string orgCode, string itemCode)
        { 
            var service = ServiceProvider.GetRequiredService<IPlmEsbService>();

            var response = await service.QueryItemInfoToERP(new QueryItemInfoRequest
            {
                OrgCode = orgCode,
                ItemCode = itemCode
            });
    
            if (response != null) {
                  var datas = ObjectMapper.Map<ItemMakeDto,ItemMake>(response[0]);
                return Result.FromData(datas);
            }
            else
            {
                var message = $"【{response}】";
                Logger.LogWarning(message);
                return Result.FromError<ItemMake>(message);
            }
        }

        /// <summary>
        /// 根据sourcePartNumber获取PLM中BOM结构父项信息 【第三方接口：/oppo/plm/plm_parent_partinfo_list】
        /// </summary>
        /// <param name="sourcePartNumber">,必填</param>
        /// <param name="replacePartNumber">,必填</param>
        /// <returns></returns>
        public async Task<Result<List<ParentPartinforResponse>>> GetPlmParentPartinfoList(string sourcePartNumber, string replacePartNumber)
        {
            var service = ServiceProvider.GetRequiredService<IPlmEsbService>();

            var response = await service.GetPlmParentPartinfoList(new QueryParentInfoRequest
            {
                sourcePartNumber = sourcePartNumber,
                replacePartNumber = replacePartNumber
            });

            if (response.Response.Code == "SUCCESS")
                return Result.FromData(response.Response.Data);
            else
            {
                var message = $"【{response.Response.Code}】{response.Response.Message}";
                Logger.LogWarning(message);
                return Result.FromError<List<ParentPartinforResponse>>(message);
            }

        }

        /// <summary>
        /// 抛物料替代建立/失效到PLM【第三方接口：/oppo/plm/plm_comsub_insert】
        /// </summary>
        /// <param name="subs"></param>
        /// <returns></returns>
        public async Task<Result<List<SubstitutesResponse>>> InsertSubsInfoToPLM(List<SubstitutesDto> subs)
        {
            var service = ServiceProvider.GetRequiredService<IPlmEsbService>();

            var response = await service.InsertSubsInfoToPLM(new InsertSubsInfoRequest
            {
                Data = JsonConvert.SerializeObject(subs)
            });
            if (response.Response.Code == "SUCCESS")
                return Result.FromData(response.Response.Data);
            else
            {
                var message = $"【{response.Response.Code}】{response.Response.Message}";
                Logger.LogWarning(message);
                return Result.FromError<List<SubstitutesResponse>>(message);
            }
        }


        /// <summary>
        /// 抛物料替代建立/失效到ERP【第三方接口：/oppo/plm/erp/erp_comsub_insert】
        /// </summary>
        /// <param name="subs"></param>
        /// <returns></returns>
        public async Task<Result> InsertSubsInfoToERP(List<SubstitutesDto> subs)
        {
            var service = ServiceProvider.GetRequiredService<IPlmEsbService>();

            var response = await service.InsertSubsInfoToERP(new InsertSubsInfoRequest
            {
                Data = JsonConvert.SerializeObject(subs)
            });

            if (response.Body.BussinessCode == "0")
                return Result.Ok(response.Body.Message);
            else
            {
                var message = $"【{response.Body.BussinessCode}】{response.Body.Message}";
                Logger.LogWarning(message);
                return Result.FromError(message);
            }
        }


        /// <summary>
        /// 从ERP查询替代料新增/失效/主次料调整信息【第三方接口：/oppo/plm/erp/erp_comsub_list】
        /// </summary>
        /// <param name="docNumber">文件编号</param>
        /// <returns></returns>
        public async Task<Result<List<ComsubResponse>>> QuerySubsInfoToERP(string docNumber)
        {
            var service = ServiceProvider.GetRequiredService<IPlmEsbService>();

            var response = await service.QuerySubsInfoToERP(new QueryComSubRequest
            {
                DocNumber = docNumber
            });
            if (response != null)
            {
                var datas = ObjectMapper.Map<List<SubstitutesResponseDto>, List<ComsubResponse>>(response);
                return Result.FromData(datas);
            }             
            else
            {
                var message = $"【】{response}";
                Logger.LogWarning(message);
                return Result.FromError<List<ComsubResponse>>(message);
            }
        }

    }

}
