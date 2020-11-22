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
    /// 流程实例归属
    /// </summary>
    [Area("bpm")]
    [Route("api/mo/bpm/process-instance-belong")]
    public class BpmProcessInstanceBelongController : AbpController
    {
        private readonly IBpmProcessInstanceBelongAppService _bpmProcessInstanceBelongAppService;

        /// <summary>
        /// <see cref="BpmProcessInstanceBelongController"/>
        /// </summary>
        public BpmProcessInstanceBelongController(IBpmProcessInstanceBelongAppService bpmProcessInstanceBelongAppService)
        {
            _bpmProcessInstanceBelongAppService = bpmProcessInstanceBelongAppService;
        }

        /// <summary>
        /// 授予流程实例归属
        /// </summary>
        /// <param name="processInstanceBelongGrantInput"><see cref="ProcessInstanceBelongGrantInput"/></param>
        /// <returns></returns>
        [HttpPost("grant")]
        public async Task<Result<ProcessInstanceBelongDto>> GrantProcessInstanceBelong([FromBody] ProcessInstanceBelongGrantInput processInstanceBelongGrantInput)
        {
            return await _bpmProcessInstanceBelongAppService.GrantProcessInstanceBelong(processInstanceBelongGrantInput.ProcessInstanceId, processInstanceBelongGrantInput.AppId);
        }

        /// <summary>
        /// 取消流程实例归属
        /// </summary>
        /// <param name="belongId">流程实例归属Id</param>
        /// <returns></returns>
        [HttpDelete("revoke-by-id")]
        public async Task<Result> RevokeProcessInstanceBelong(Guid belongId)
        {
            return await _bpmProcessInstanceBelongAppService.RevokeProcessInstanceBelong(belongId);
        }

        /// <summary>
        /// 获取流程实例归属
        /// </summary>
        /// <param name="belongId">流程实例归属Id</param>
        /// <returns></returns>
        [HttpGet("get-by-id")]
        public async Task<Result<ProcessInstanceBelongDto>> GetProcessInstanceBelong(Guid belongId)
        {
            return await _bpmProcessInstanceBelongAppService.GetProcessInstanceBelong(belongId);
        }

        /// <summary>
        /// 查询流程实例归属
        /// </summary>
        /// <param name="processInstanceBelongQueryInput"><see cref="ProcessInstanceBelongQueryInput"/></param>
        /// <returns></returns>
        [HttpPost("query")]
        public async Task<QueryResult<ProcessInstanceBelongDto>> QueryProcessInstanceBelong([FromBody] ProcessInstanceBelongQueryInput processInstanceBelongQueryInput)
        {
            return await _bpmProcessInstanceBelongAppService.QueryProcessInstanceBelong(processInstanceBelongQueryInput);
        }

        /// <summary>
        /// 分页查询流程实例归属
        /// </summary>
        /// <param name="processInstanceBelongPageQueryInput"><see cref="ProcessInstanceBelongPageQueryInput"/></param>
        /// <returns></returns>
        [HttpPost("page-query")]
        public async Task<PageQueryResult<ProcessInstanceBelongDto>> PageQueryProcessInstanceBelong([FromBody] ProcessInstanceBelongPageQueryInput processInstanceBelongPageQueryInput)
        {
            return await _bpmProcessInstanceBelongAppService.PageQueryProcessInstanceBelong(processInstanceBelongPageQueryInput);
        }
    }
}
