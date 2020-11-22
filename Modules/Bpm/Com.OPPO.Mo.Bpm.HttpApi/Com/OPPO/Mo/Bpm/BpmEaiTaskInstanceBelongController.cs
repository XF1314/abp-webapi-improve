using Com.OPPO.Mo.Bpm.Dtos;
using Com.OPPO.Mo.Queriable;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Bpm
{
    /// <summary>
    /// Eai任务实例归属
    /// </summary>
    [Area("bpm")]
    [Route("api/mo/bpm/eai-task-instance-belong")]
    public class BpmEaiTaskInstanceBelongController : AbpController
    {
        private readonly IBpmEaiTaskInstanceBelongAppService _bpmEaiTaskInstanceBelongAppService;

        /// <summary>
        /// <see cref="BpmEaiTaskInstanceBelongController"/>
        /// </summary>
        public BpmEaiTaskInstanceBelongController(IBpmEaiTaskInstanceBelongAppService bpmEaiTaskInstanceBelongAppService)
        {
            _bpmEaiTaskInstanceBelongAppService = bpmEaiTaskInstanceBelongAppService;
        }

        /// <summary>
        /// 授予Eai任务实例归属
        /// </summary>
        /// <param name="eaiTaskInstanceBelongGrantInput"><see cref="EaiTaskInstanceBelongGrantInput"/></param>
        /// <returns></returns>
        [HttpPost("grant")]
        public async Task<Result<EaiTaskInstanceBelongDto>> GrantEaiTaskInstanceBelong([FromBody] EaiTaskInstanceBelongGrantInput eaiTaskInstanceBelongGrantInput)
        {
            return await _bpmEaiTaskInstanceBelongAppService.GrantEaiTaskInstanceBelong(eaiTaskInstanceBelongGrantInput.EaiTaskInstanceId, eaiTaskInstanceBelongGrantInput.AppId);
        }

        /// <summary>
        /// 获取Eai任务实例归属
        /// </summary>
        /// <param name="belongId">Eai任务实例归属Id</param>
        /// <returns></returns>
        [HttpGet("get-by-id")]
        public async Task<Result<EaiTaskInstanceBelongDto>> GetEaiTaskInstanceBelong(Guid belongId)
        {
            return await _bpmEaiTaskInstanceBelongAppService.GetEaiTaskInstanceBelong(belongId);
        }

        /// <summary>
        /// 查询Eai任务实例归属
        /// </summary>
        /// <param name="eaiTaskInstanceBelongQueryInput"><see cref="EaiTaskInstanceBelongQueryInput"/></param>
        /// <returns></returns>
        [HttpPost("query")]
        public async Task<QueryResult<EaiTaskInstanceBelongDto>> QueryEaiTaskInstanceBelong([FromBody] EaiTaskInstanceBelongQueryInput eaiTaskInstanceBelongQueryInput)
        {
            return await _bpmEaiTaskInstanceBelongAppService.QueryEaiTaskInstanceBelong(eaiTaskInstanceBelongQueryInput);
        }

        /// <summary>
        /// 分页查询Eai任务实例归属
        /// </summary>
        /// <param name="eaiTaskInstanceBelongPageQueryInput"><see cref="EaiTaskInstanceBelongPageQueryInput"/></param>
        /// <returns></returns>
        [HttpPost("page-query")]
        public async Task<PageQueryResult<EaiTaskInstanceBelongDto>> PageQueryEaiTaskInstanceBelong([FromBody] EaiTaskInstanceBelongPageQueryInput eaiTaskInstanceBelongPageQueryInput)
        {
            return await _bpmEaiTaskInstanceBelongAppService.PageQueryEaiTaskInstanceBelong(eaiTaskInstanceBelongPageQueryInput);
        }

        /// <summary>
        /// 取消Eai任务实例归属
        /// </summary>
        /// <param name="belongId">Eai任务实例归属Id</param>
        /// <returns></returns>
        [HttpDelete("revoke-by-id")]
        public async Task<Result> RevokeEaiTaskInstanceBelong(Guid belongId)
        {
            return await _bpmEaiTaskInstanceBelongAppService.RevokeEaiTaskInstanceBelong(belongId);
        }
    }
}
