using Com.OPPO.Mo.Thirdparty.Hr.PreEmploymentPlatform.Dtos;
using Com.OPPO.Mo.Thirdparty.Hr.PreEmploymentPlatform.Response;
using Com.OPPO.Mo.Thirdparty.HR.PreEmploymentPlatform.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Com.OPPO.Mo.Thirdparty.Hr.PreEmploymentPlatform
{
    /// <summary>
    /// 社会招聘录用审批服务接口
    /// </summary>
    public interface ISocialRecruitApprovalAppService : IApplicationService
    {
       

        /// <summary>
        /// 员工数据同步接口
        /// </summary>
        /// <param name="employment"></param>
        /// <returns></returns>
        Task<Result> EmployeeDataSync(EmploymentDto employment);


        /// <summary>
        /// 办公用具领用状态同步
        /// </summary>
        /// <param name="status">办公用具领用状态，必填,1表示办公用具领用;2表示电脑权限开通</param>
        /// <param name="employId">操作者ID，必填</param>
        /// <param name="number">文件编号，必填</param>
        /// <returns></returns>
        Task<Result> ReceiveStateSync(string status, string employId, string number);


        /// <summary>
        /// 招聘平台获取员工信息
        /// </summary>
        /// <param name="name">员工名</param>
        /// <returns></returns>
        Task<Result<List<ResumeInfo>>> GetEmployeeData(string name);
    }
}
