using Com.OPPO.Mo.Thirdparty.Erp.Dtos;
using Com.OPPO.Mo.Thirdparty.Erp.ErpAssets;
using Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Dtos;
using Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Requests;
using Com.OPPO.Mo.Thirdparty.Erp.ErpAssets.Responses;
using Com.OPPO.Mo.Thirdparty.Erp.Requests;
using Com.OPPO.Mo.Thirdparty.Erp.Responses;
using Com.OPPO.Mo.Thirdparty.Erp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.Erp
{

    [Authorize]
    public class ErpAssetsAppService : ThirdpartyAppServiceBase, IErpAssetsAppService
    {
        /// <summary>
        /// 根据文件编号查询采购单信息 【第三方接口：/erp/assets/po_list】
        /// </summary>
        /// <param name="docId">文件编号,必填</param>
        /// <param name="language">语言</param>
        /// <returns></returns>
        public async Task<Result<List<PoLinesInfo>>> QueryPurchaseOrderByDocId(string docId, string language)
        { 
            var service = ServiceProvider.GetRequiredService<IErpAssetsService>();

            var response = await service.QueryPurchaseOrderByDocId(new QueryPurchaseOrderRequest
            {
                DocId = docId,
                Language = language
            });

            if (response.Response.Code == "0")
            {
                var datas = ObjectMapper.Map<List<PoLinesInfoDto>, List<PoLinesInfo>>(response.Response.Datas);
                return Result.FromData(datas);
            }           
            else
            {
                var message = $"【{response.Response.Code}】{response.Response.Message}";
                Logger.LogWarning(message);
                return Result.FromError<List<PoLinesInfo>>(message);
            }
        }

        /// <summary>
        /// 创建PO,设备请购,工装夹治具 【第三方接口：/erp/assets/create_po】
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<Result<List<PoLineBase>>> CreatePo(List<CreatePoInfoDto> dto)
        {
            var service = ServiceProvider.GetRequiredService<IErpAssetsService>();
            var query = ObjectMapper.Map<List<CreatePoInfoDto>, List<CreatePoInfo>>(dto);
            var response = await service.CreatePo(new PoLinesRequest
            {
                PoLines = JsonConvert.SerializeObject(query)
            });

            if (response.Response.Code == "0")
            {
                var datas = ObjectMapper.Map<List<PoLineBaseDto>, List<PoLineBase>>(response.Response.Datas);
                return Result.FromData(datas);
            }
            else
            {
                var message = $"【{response.Response.Code}】{response.Response.Message}";
                Logger.LogWarning(message);
                return Result.FromError<List<PoLineBase>>(message);
            }
        }

        /// <summary>
        /// PO入仓确认 【第三方接口：/erp/assets/po_deliver】
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<Result<PoLine>> PoWarehousingConfirm(PoWarehousingDto dto)
        {
            var service = ServiceProvider.GetRequiredService<IErpAssetsService>();
            var query = ObjectMapper.Map<PoWarehousingDto, PoWarehousing>(dto);
            var response = await service.PoWarehousingConfirm(new PoLinesRequest
            {
                PoLines = JsonConvert.SerializeObject(query)
            });

            if (response.Response.Code == "0")
            {
                var data = ObjectMapper.Map<PoLineDto, PoLine>(response.Response.Data);
                return Result.FromData(data);
            }
            else
            {
                var message = $"【{response.Response.Code}】{response.Response.Message}";
                Logger.LogWarning(message);
                return Result.FromError<PoLine>(message);
            }
        }

        /// <summary>
        /// 供应商税率获取 【第三方接口：/erp/assets/vender_tax_get】
        /// </summary>
        /// <param name="orgCode">组织代码,必填</param>
        /// <param name="vendorCode ">供应商代码,必填</param>
        /// <param name="language">语言,非必填</param>
        /// <returns></returns>
        public async Task<Result<VenderTax>> GetVenderTax(string orgCode, string vendorCode, string language)
        {
            var service = ServiceProvider.GetRequiredService<IErpAssetsService>();

            var response = await service.GetVenderTax(new QueryVenderTaxRequest
            {
                VendorCode = vendorCode,OrgCode = orgCode,Language = language
            });

            if (response.Response.Data != null)
            {
                var data = ObjectMapper.Map<VenderTaxDto, VenderTax>(response.Response.Data);
                return Result.FromData(data);
            }
            else
            {
                var message = $"【{response.Response.Code}】{response.Response.Message}";
                Logger.LogWarning(message);
                return Result.FromError<VenderTax>(message);
            }
        }

        /// <summary>
        /// 创建PO,设备请购,工装夹治具 【第三方接口：/erp/assets/create_po_line】
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<Result<List<PoLineRet>>> CreatePoLine(List<CreatePoDto> dto)
        {
            var service = ServiceProvider.GetRequiredService<IErpAssetsService>();
            var query = ObjectMapper.Map<List<CreatePoDto>, List<CreatePo>>(dto);
            var response = await service.CreatePoLine(new PoLinesRequest
            {
                PoLines = JsonConvert.SerializeObject(query)
            });

            if (response.Response.Code == "0")
            {
                var datas = ObjectMapper.Map<List<PoLineRetDto>, List<PoLineRet>>(response.Response.Datas);
                return Result.FromData(datas);
            }
            else
            {
                var message = $"【{response.Response.Code}】{response.Response.Message}";
                Logger.LogWarning(message);
                return Result.FromError<List<PoLineRet>>(message);
            }
        }


        /// <summary>
        /// 普通设备请购获取最新单价 【第三方接口：/erp/assets/bbk_po_from_oa】
        /// </summary>
        /// <param name="itemCode">资产代码,必填</param>
        /// <param name="vendorCode ">供应商代码,必填</param>
        /// <param name="language">语言,非必填</param>
        /// <returns></returns>
        public async Task<Result<bbkInfo>> GetLatestUnitPrice(string itemCode, string vendorCode, string language)
        {
            var service = ServiceProvider.GetRequiredService<IErpAssetsService>();

            var response = await service.GetLatestUnitPrice(new QueryLatestUnitPriceRequest
            {
                VendorCode = vendorCode,
                ItemCode = itemCode,
                Language = language
            });

            if (response.Response.bbk != null)
            {
                var data = ObjectMapper.Map<bbkInfoDto, bbkInfo>(response.Response.bbk);
                return Result.FromData(data);
            }
            else
            {
                var message = $"【{response.Response.Code}】{response.Response.Message}";
                Logger.LogWarning(message);
                return Result.FromError<bbkInfo>(message);
            }
        }

        /// <summary>
        /// 根据文件编号查询采购单信息 【第三方接口：/erp/assets/po_list_fun】
        /// </summary>
        /// <param name="docId">文件编号,非必填</param>
        /// <param name="poNumber">采购单号,非必填</param>
        /// <param name="language">语言,非必填</param>
        /// <returns></returns>
        public async Task<Result<List<PurchaseOrder>>> GetPoListByDocId(string docId, string poNumber, string language)
        {
            var service = ServiceProvider.GetRequiredService<IErpAssetsService>();

            var response = await service.GetPoListByDocId(new QueryPoListRequest
            {
                DocId = docId,
                PoNumber = poNumber,
                Language = language
            });

            if (response.Response.Code == "0")
            {
                List<PurchaseOrderDto> list = JsonConvert.DeserializeObject<List<PurchaseOrderDto>>(response.Response.data);
                var data = ObjectMapper.Map<List<PurchaseOrderDto>, List<PurchaseOrder>>(list);
                return Result.FromData(data);
            }
            else
            {
                var message = $"【{response.Response.Code}】{response.Response.Message}";
                Logger.LogWarning(message);
                return Result.FromError<List<PurchaseOrder>>(message);
            }
        }


        /// <summary>
        /// 删除下单临时表数据接口 【第三方接口：/erp/assets/po_delete】
        /// </summary>
        /// <param name="seqId">序号,必填</param>
        /// <param name="responseType">返回格式，支持json/xml两种格式，默认为json格式,可不填</param>
        /// <returns></returns>
        public async Task<Result> DeletePoBySeqId(string seqId, string responseType)
        {
            var service = ServiceProvider.GetRequiredService<IErpAssetsService>();

            var response = await service.DeletePoBySeqId(new DeletePoRequest
            {
                SeqId = seqId,
                ResponseType = responseType
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
        /// 紧急设备请购推送接口 【第三方接口：/erp/assets/equipment_purchase】
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<Result> EquipmentPurchasePush(List<EquipmentPurchaseDto> dto)
        {
            var service = ServiceProvider.GetRequiredService<IErpAssetsService>();
            var query = ObjectMapper.Map<List<EquipmentPurchaseDto>, List<EquipmentPurchase>>(dto);
            var response = await service.EquipmentPurchasePush(new LinesRequest
            {
                Data = JsonConvert.SerializeObject(query)
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


    }

}
