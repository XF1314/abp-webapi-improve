using Com.OPPO.Mo.Bpm.Dtos;
using Com.OPPO.Mo.Queriable;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Bpm
{
    /// <summary>
    /// 业务对象归属
    /// </summary>
    [Area("bpm")]
    [Route("api/mo/bpm/business-object-belong")]
    public class BpmBusinessObjectBelongController : AbpController
    {
        private readonly IBpmBusinessObjectBelongAppService _businessObjectBelongAppService;

        /// <summary>
        /// <see cref="BpmBusinessObjectBelongController"/>
        /// </summary>
        public BpmBusinessObjectBelongController(IBpmBusinessObjectBelongAppService businessObjectBelongAppService)
        {
            _businessObjectBelongAppService = businessObjectBelongAppService;
        }

        /// <summary>
        /// 授予业务对象归属
        /// </summary>
        /// <param name="businessObjectBelongGrantInput"><see cref="BusinessObjectBelongGrantInput"/></param>
        /// <returns></returns>
        [HttpPost("grant")]
        public async Task<Result<BusinessObjectBelongDto>> GrantBusinessObjectBelong([FromBody] BusinessObjectBelongGrantInput businessObjectBelongGrantInput)
        {
            return await _businessObjectBelongAppService.GrantBusinessObjectBelong(businessObjectBelongGrantInput.BusinessObjectId, businessObjectBelongGrantInput.AppId);
        }

        /// <summary>
        /// 获取业务对象归属
        /// </summary>
        /// <param name="belongId">业务对象归属Id</param>
        /// <returns></returns>
        [HttpGet("get-by-id")]
        public async Task<Result<BusinessObjectBelongDto>> GetBusinessObjectBelong(Guid belongId)
        {
            return await _businessObjectBelongAppService.GetBusinessObjectBelong(belongId);
        }

        /// <summary>
        /// 删除业务对象归属
        /// </summary>
        /// <param name="belongId">业务对象归属Id</param>
        /// <returns></returns>
        [HttpDelete("delete-by-id")]
        public async Task<Result> DeleteBusinessObjectBelong(Guid belongId)
        {
            return await _businessObjectBelongAppService.DeleteBusinessObjectBelong(belongId);
        }

        /// <summary>
        /// 查询业务对象归属
        /// </summary>
        /// <param name="businessObjectBelongQueryInput"><see cref="BusinessObjectBelongQueryInput"/></param>
        /// <returns></returns>
        [HttpPost("query")]
        public async Task<Result<List<BusinessObjectBelongDto>>> QueryBusinessObjectBelong( [FromForm] BusinessObjectBelongQueryInput businessObjectBelongQueryInput)
        {
            return await _businessObjectBelongAppService.QueryBusinessObjectBelong(businessObjectBelongQueryInput);
        }

        /// <summary>
        /// 分页查询业务对象归属
        /// </summary>
        /// <param name="businessObjectBelongPageQueryInput"><see cref="BusinessObjectBelongPageQueryInput"/></param>
        /// <returns></returns>
        [HttpPost("page-query")]
        public async Task<PageQueryResult<BusinessObjectBelongDto>> PageQueryBusinessObjectBelong([FromForm] BusinessObjectBelongPageQueryInput businessObjectBelongPageQueryInput)
        {
            return await _businessObjectBelongAppService.PageQueryBusinessObjectBelong(businessObjectBelongPageQueryInput);
        }
    }
}
