using System.Collections.Generic;
using System.Threading.Tasks;
using Com.OPPO.Mo.MasterData.Process.DbModel;

namespace Com.OPPO.Mo.MasterData.Process
{
    public interface IProcessDapperRepository
    {
        Task<int> GetPendingProcessInstancesCountAsync(string userCode);

        Task<IEnumerable<string>>
            GetPagedPendingProcessInstanceCodesAsync(string userCode, int pageIndex, int pageSize);

        Task<IEnumerable<PendingProcessInstanceDetail>> GetPendingProcessInstanceDetailAsync(string formInstanceCode);

        Task<int> GetApprovedProcessInstancesCountAsync(string userCode);

        Task<IEnumerable<string>> GetPagedApprovedProcessInstanceCodesAsync(string userCode, int pageIndex,
            int pageSize);

        Task<IEnumerable<ApprovedProcessInstanceDetail>> GetApprovedProcessInstanceDetailAsync(string formInstanceCode);
    }
}