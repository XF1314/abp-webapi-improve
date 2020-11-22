using Com.OPPO.Mo.Thirdparty.OnePlus.PS;
using Com.OPPO.Mo.Thirdparty.OnePlus.PS.Dtos;
using Com.OPPO.Mo.Thirdparty.OnePlus.PS.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Thirdparty.OnePlus
{
    /// <summary>
    /// 一加 PS 服务实现类
    /// </summary>
    [Authorize]
    public　class OnePlusPsAppService : ThirdpartyAppServiceBase,IOnePlusPsAppService
    {
        private readonly IOnePlusPsEsbService _onePlusPsEsbService;

        public OnePlusPsAppService(IOnePlusPsEsbService onePlusPsEsbService)
        {
            _onePlusPsEsbService = onePlusPsEsbService;
        }

        /// <summary>
        /// 法定节假日加班数据推送
        /// </summary>
        /// <param name="holidayOTDto"></param>
        /// <returns></returns>
        public async Task<Result> AddPublicHoildayOTInfo(OnePlusHolidayOTDto holidayOTDto) 
        {
            var oTDataInfo = new OTDataInfo()
            {
                EmpId = holidayOTDto.EmpId,
                BeginDt = holidayOTDto.BeginDt,
                EndDt = holidayOTDto.EndDt,
                BeginTime = holidayOTDto.BeginTime,
                EndTime = holidayOTDto.EndTime,
                COt3Days = holidayOTDto.COt3Days
            };
            var holidayOTInfoAddRequest = new OnePlusHolidayOTInfoAddRequest();
            holidayOTInfoAddRequest.lines = "[" + JsonConvert.SerializeObject(oTDataInfo) + "]"; 

            var response = await _onePlusPsEsbService.AddPublicHoildayOTInfo(holidayOTInfoAddRequest);
            if (response.Body.BussinessCode == "1")
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
