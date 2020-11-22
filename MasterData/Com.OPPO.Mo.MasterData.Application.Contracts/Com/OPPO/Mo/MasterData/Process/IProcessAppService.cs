using System.Collections.Generic;
using System.Threading.Tasks;
using Com.OPPO.Mo.MasterData.Process.DbModel;

namespace Com.OPPO.Mo.MasterData.Process
{
    public interface IProcessAppService
    {
        Task<Result<int>> GetPendingProcessInstancesCountAsync(string userCode);

        Task<Result<IEnumerable<string>>>
            GetPagedPendingProcessInstanceCodesAsync(string userCode, int pageIndex, int pageSize);

        Task<Result<IEnumerable<PendingProcessInstanceDetail>>> GetPendingProcessInstanceDetailAsync(
            string formInstanceCode);

        Task<Result<int>> GetApprovedProcessInstancesCountAsync(string userCode);

        Task<Result<IEnumerable<string>>>
            GetPagedApprovedProcessInstanceCodesAsync(string userCode, int pageIndex, int pageSize);

        Task<Result<IEnumerable<ApprovedProcessInstanceDetail>>> GetApprovedProcessInstanceDetailAsync(
            string formInstanceCode);
    }
}