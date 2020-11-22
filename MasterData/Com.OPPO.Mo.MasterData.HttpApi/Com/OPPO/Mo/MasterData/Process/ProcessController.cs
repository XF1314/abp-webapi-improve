using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Com.OPPO.Mo.MasterData.Process
{
    [Route("api")]
    public class ProcessController : AbpController
    {
        private readonly IProcessAppService _processAppService;
        
        public ProcessController(IProcessAppService processAppService)
        {
            _processAppService = processAppService;
        }

        [HttpGet("paged/pending/processinstances")]
        public async Task<Result<IEnumerable<string>>> GetPagedPendingProcessInstanceCodesAsync(string userCode, int pageIndex = 1, int pageSize = 10)
        {
             return await _processAppService.GetPagedPendingProcessInstanceCodesAsync(userCode, pageIndex, pageSize);
        }

        //public async Task<Result<IEnumerable<string>>> GetPendingCountAsync(string userCode)
        //{
            
        //} 
        
        
        [HttpGet("paged/approved/processinstances")]
        public async Task<Result<IEnumerable<string>>> GetPagedApprovedProcessInstanceCodesAsync(string userCode, int pageIndex = 1, int pageSize = 10)
        {
            return await _processAppService.GetPagedApprovedProcessInstanceCodesAsync(userCode, pageIndex, pageSize);
        }
    }
}