using System.Collections.Generic;
using System.Threading.Tasks;
using Com.OPPO.Mo.MasterData.Process.DbModel;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.MasterData.Process
{
    public class ProcessAppService : ApplicationService, IProcessAppService
    {
        private readonly IProcessDapperRepository _processDapperRepository;

        public ProcessAppService(IProcessDapperRepository processDapperRepository)
        {
            _processDapperRepository = processDapperRepository;
        }

        public async Task<Result<int>> GetPendingProcessInstancesCountAsync(string userCode)
        {
            var count = await _processDapperRepository.GetPendingProcessInstancesCountAsync(userCode);
            return Result.FromData(count);
        }

        public async Task<Result<IEnumerable<string>>>
            GetPagedPendingProcessInstanceCodesAsync(string userCode, int pageIndex, int pageSize)
        {
            var processInstanceCodes =
                await _processDapperRepository.GetPagedPendingProcessInstanceCodesAsync(userCode, pageIndex, pageSize);
            return Result.FromData(processInstanceCodes);
        }

        public async Task<Result<IEnumerable<PendingProcessInstanceDetail>>> GetPendingProcessInstanceDetailAsync(
            string formInstanceCode)
        {
            var details = await _processDapperRepository.GetPendingProcessInstanceDetailAsync(formInstanceCode);
            return Result.FromData(details);
        }

        public async Task<Result<int>> GetApprovedProcessInstancesCountAsync(string userCode)
        {
            var count = await _processDapperRepository.GetApprovedProcessInstancesCountAsync(userCode);
            return Result.FromData(count);
        }
        
        public async Task<Result<IEnumerable<string>>>
            GetPagedApprovedProcessInstanceCodesAsync(string userCode, int pageIndex, int pageSize)
        {
            var processInstanceCodes = 
                await _processDapperRepository.GetPagedApprovedProcessInstanceCodesAsync(userCode, pageIndex, pageSize);
            return Result.FromData(processInstanceCodes);
        }
        
        public async Task<Result<IEnumerable<ApprovedProcessInstanceDetail>>> GetApprovedProcessInstanceDetailAsync(
            string formInstanceCode)
        {
            var details = await _processDapperRepository.GetApprovedProcessInstanceDetailAsync(formInstanceCode);
            return Result.FromData(details);
        }
    }
}