using Com.OPPO.Mo.Thirdparty.Erp.Dtos;
using Com.OPPO.Mo.Thirdparty.Erp.ErpSrm;
using Com.OPPO.Mo.Thirdparty.Erp.ErpSrm.Dtos;
using Com.OPPO.Mo.Thirdparty.Erp.ErpSrm.Requests;
using Com.OPPO.Mo.Thirdparty.Erp.Requests;
using Com.OPPO.Mo.Thirdparty.Erp.Responses;
using Com.OPPO.Mo.Thirdparty.Erp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.Erp
{

    [Authorize]
    public class ErpSrmAppService : ThirdpartyAppServiceBase, IErpSrmAppService
    {
        private readonly IConfiguration _configuration;
        private readonly IErpSrmEsbService  _erpSrmEsbService;

        /// <summary>
        /// <see cref="MesExportSoftwareInfoAppService"/>
        /// </summary>
        public ErpSrmAppService(IConfiguration configuration,
            IErpSrmEsbService erpSrmEsbService)
        {
            _configuration = configuration;
            _erpSrmEsbService = erpSrmEsbService;
        }

        /// <summary>
        /// 获取验收单信息 【第三方接口：/erp/srm/srm_get_checkbill_info】
        /// </summary>
        /// <param name="OrganizationCode">组织代码,必填</param>
        /// <param name="ReceiptNumber">验收单号,必填</param>
        /// <param name="MaterialNumber">物料号,必填</param>
        /// <param name="Language">default: ZHS,可不填</param>
        /// <returns></returns>
        public async Task<Result<ErpSrmStockBody>> GetCheckBillInfo(string OrganizationCode, string ReceiptNumber, string MaterialNumber, string Language)
        {
            
            ErpSrmCheckBillInfoQueryRequest query = new ErpSrmCheckBillInfoQueryRequest
            {
                OrganizationCode = OrganizationCode,
                Language = Language,
                MaterialNumber = MaterialNumber,
                ReceiptNumber = ReceiptNumber
            };
            var response = await _erpSrmEsbService.GetCheckBillInfo(query);

            if (response.Response.Code == null)
            {
                var datas = ObjectMapper.Map<List<MtrlItemDto>, List<MtrlItem>>(response.Response.info);
                ErpSrmStockBody stockBody = new ErpSrmStockBody { RowCount = response.Response.total_results, DataList = datas };
                return Result.FromData(stockBody);
            }
            else
            {
                var message = $"【{response.Response.Code}】{response.Response.Message}";
                Logger.LogError(message);
                return Result.FromError<ErpSrmStockBody>(message);
            }
        }


        /// <summary>
        /// 根据料号获取库存信息 【第三方接口：/erp/srm/srm_mtrlno_stock】
        /// </summary>
        /// <param name="OrganizationCode">组织代码,必填</param>
        /// <param name="MaterialNumber">料号,必填</param>
        /// <param name="Language">default: ZHS,可不填</param>
        /// <returns></returns>
        public async Task<Result<ErpSrmStockBody>> GetMtrlnoStock(string OrganizationCode, string MaterialNumber, string Language)
        {
            
            ErpSrmMtrlnoStockQueryRequest query = new ErpSrmMtrlnoStockQueryRequest
            {
                OrganizationCode = OrganizationCode,
                Language = Language,
                MaterialNumber = MaterialNumber
            };
            var response = await _erpSrmEsbService.GetMtrlnoStock(query);

            if (response.Response.Code == null) {
                var datas = ObjectMapper.Map<List<MtrlItemDto>, List<MtrlItem>>(response.Response.mtrl);
                ErpSrmStockBody stockBody = new ErpSrmStockBody { RowCount = response.Response.total_results, DataList = datas};
                return Result.FromData(stockBody);
            }
            else
            {
                var message = $"【{response.Response.Code}】{response.Response.Message}";
                Logger.LogError(message);
                return Result.FromError<ErpSrmStockBody>(message);
            }
        }

        /// <summary>
        /// 采购风险申请单写入erp 【第三方接口：/erp/srm/srm_deliver_check_insert_batch_2】
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<Result> PurchaseOrderToErpPush(List<ErpPurchaseOrderDto> dto)
        {
            
            var query = ObjectMapper.Map<List<ErpPurchaseOrderDto>, List<ErpPurchaseOrder>>(dto);

            var response = await _erpSrmEsbService.PurchaseOrderToErpPush(new ErpPurchaseOrderPushRequest
            {
                Data = JsonConvert.SerializeObject(query)
            });

            //var res = ObjectMapper.Map<List<ErpDepartmentFlagInfo>, List<ErpDepartmentFlagDto>>(response.Body.Data);
            if (response.Body.BussinessCode == "0")
                return Result.Ok();
            else
            {
                var message = $"【{response.Body.BussinessCode}】{response.Body.Message}";
                Logger.LogWarning(message);
                return Result.FromError(message);
            }
        }

        /// <summary>
        /// 采购风险申请单写入erp1 【第三方接口：/erp/srm/srm_deliver_check_insert_batch_1】
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<Result> PurchaseOrderToErpPush1(List<PurchaseReportDto> dto)
        {

            var query = ObjectMapper.Map<List<PurchaseReportDto>, List<PurchaseReport>>(dto);

            var response = await _erpSrmEsbService.PurchaseOrderToErpPush1(new ErpPurchaseOrderPushRequest
            {
                Data = JsonConvert.SerializeObject(query)
            });

            //var res = ObjectMapper.Map<List<ErpDepartmentFlagInfo>, List<ErpDepartmentFlagDto>>(response.Body.Data);
            if (response.Body.BussinessCode == "0")
                return Result.Ok();
            else
            {
                var message = $"【{response.Body.BussinessCode}】{response.Body.Message}";
                Logger.LogWarning(message);
                return Result.FromError(message);
            }
        }


        /// <summary>
        /// 更新进货检验报告数据1 【第三方接口：/erp/srm/srm_deliver_status_update_1】
        /// </summary>
        /// <param name="DocId">文件编号,必填</param>
        /// <param name="Status">状态,必填</param>
        /// <returns></returns>
        public async Task<Result> DeliverStatusUpdate_1(string DocId, string Status)
        {
            

            var response = await _erpSrmEsbService.DeliverStatusUpdate_1(new ErpDeliverStatusUpdateARequest
            {
                DocId = DocId,
                Status = Status
            });

            if (response.Body.BussinessCode == "0")
                return Result.Ok();
            else
            {
                var message = $"【{response.Body.BussinessCode}】{response.Body.Message}";
                Logger.LogWarning(message);
                return Result.FromError(message);
            }
        }

        /// <summary>
        /// 更新进货检验报告数据2 【第三方接口：/erp/srm/srm_deliver_status_update_2】
        /// </summary>
        /// <param name="DocId">文件编号,必填</param>
        /// <param name="Status">状态,必填</param>
        /// <param name="IqcStatus">iqc状态,必填</param>
        /// <returns></returns>
        public async Task<Result> DeliverStatusUpdate_2(string DocId, string Status, string IqcStatus)
        {
            

            var response = await _erpSrmEsbService.DeliverStatusUpdate_2(new ErpDeliverStatusUpdateBRequest
            {
                DocId = DocId,
                IqcStatus = IqcStatus,
                Status = Status
            });

            if (response.Body.BussinessCode == "0")
                return Result.Ok();
            else
            {
                var message = $"【{response.Body.BussinessCode}】{response.Body.Message}";
                Logger.LogWarning(message);
                return Result.FromError(message);
            }
        }


        /// <summary>
        /// 信息更新 【第三方接口：/erp/srm/updateifreceivingreportrepeat】
        /// </summary>
        /// <param name="dtos">信息集合</param>
        /// <returns></returns>
        public async Task<Result> UpdateIfReceivingReportRepeat(List<UpdateIfreceivingDto> dtos)
        {
            var res = ObjectMapper.Map<List<UpdateIfreceivingDto>, List<UpdateIfreceiving>>(dtos);
            LinesRequest queryRequest = new LinesRequest { Data = JsonConvert.SerializeObject(res) };
            var response = await _erpSrmEsbService.UpdateIfReceivingReportRepeat(queryRequest);

            if (response.Body.BussinessCode == "0")
                return Result.Ok();
            else
            {
                var message = $"【{response.Body.BussinessCode}】{response.Body.Message}";
                Logger.LogWarning(message);
                return Result.FromError(message);
            }
        }


    }

}
