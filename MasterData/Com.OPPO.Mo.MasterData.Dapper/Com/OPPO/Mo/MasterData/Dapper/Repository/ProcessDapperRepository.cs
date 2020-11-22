using System.Collections.Generic;
using System.Threading.Tasks;
using Com.OPPO.Mo.Domain.Repositories.Dapper;
using Com.OPPO.Mo.MasterData.Process;
using Com.OPPO.Mo.MasterData.Process.DbModel;
using Dapper;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;

namespace Com.OPPO.Mo.MasterData.Dapper.Repository
{
    /// <summary>
    /// 流程数据的仓储类
    /// </summary>
    public class ProcessDapperRepository : DapperRepository<MoDbContext>, IProcessDapperRepository, ITransientDependency
    {
        public ProcessDapperRepository(IDbContextProvider<MoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        
        /// <summary>
        /// 获取一个人的所有待办数目
        /// </summary>
        /// <param name="userCode">要查询的员工工号</param>
        /// <returns></returns>
        public async Task<int> GetPendingProcessInstancesCountAsync(string userCode)
        {
            var sql = @"select count(ID)
                        from Runtime.WorkListItems with(nolock)
                        where ActionerAccount = @userCode
                        and Finished = 0
                        and IsProcessing = 0";
            return await DbConnection.QueryFirstOrDefaultAsync<int>(sql, new { userCode });
        }
        
        /// <summary>
        /// 分页得获取一个员工的待办文件编码
        /// </summary>
        /// <param name="userCode">员工工号</param>
        /// <param name="pageIndex">分页页号</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        public async Task<IEnumerable<string>> GetPagedPendingProcessInstanceCodesAsync(string userCode, int pageIndex, int pageSize)
        {
            var sql = @"with workListItems as (
                            select ProcInstID, WorkStartDatetime
                            from Runtime.WorkListItems with(nolock)
                            where ActionerAccount = @userCode
                            and Finished = 0
                            and IsProcessing = 0
                        )

                        select FormInstanceCode
                        from workListItems with(nolock)
                        inner join Runtime.ProcessInstance with(nolock) on ProcessInstance.ProcInstID = workListItems.ProcInstID
                        order by workListItems.WorkStartDatetime desc
                        offset @offset rows fetch next @pageSize rows only";
            return await DbConnection.QueryAsync<string>(sql, new { userCode, offset = pageIndex * pageSize, pageSize });
        }

        /// <summary>
        /// 获取待审批流程实例的详情
        /// </summary>
        /// <param name="formInstanceCode"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PendingProcessInstanceDetail>> GetPendingProcessInstanceDetailAsync(string formInstanceCode)
        {
            var sql = @"declare @processInstanceId nvarchar(128);

                        select @processInstanceId = ProcInstID
                        from Runtime.ProcessInstance with(nolock)
                        where FormInstanceCode = @formInstanceCode;

                        with processInstances as (
                            select FormInstanceCode, ProcInstID, Folio, StartUserAccount, StartUserChsName, StartUserFullName
                            from Runtime.ProcessInstance
                            where ProcInstID = @processInstanceId
                        ), items as (
                            select ProcInstID as ProcInstID, WorkStartDatetime, ActionerAccount, ActionerChsName, ActionerFullName
                            from Runtime.WorkListItems with(nolock)
                            where ProcInstID = @processInstanceId
                            and Finished = 0
                            and IsProcessing = 0
                        )

                        select processInstances.*, items.WorkStartDatetime, items.ActionerAccount, items.ActionerChsName, items.ActionerFullName
                        from processInstances
                        inner join items on items.ProcInstID = processInstances.ProcInstID
            ";

            return await DbConnection.QueryAsync<PendingProcessInstanceDetail>(sql, new {formInstanceCode});
        }

        /// <summary>
        /// 获取一个人的所有已办数据
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public async Task<int> GetApprovedProcessInstancesCountAsync(string userCode)
        {
            var sql = @"select count(ID)
                        from Runtime.WorkListItemLog with(nolock)
                        where ActionerAccount = @userCode
                        and IsDisplay = 1
                        and WLField5 = 0";
            return await DbConnection.QueryFirstOrDefaultAsync<int>(sql, new { userCode });
        }
        
        /// <summary>
        /// 分页得获取一个员工的已办文件编码
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<IEnumerable<string>> GetPagedApprovedProcessInstanceCodesAsync(string userCode, int pageIndex, int pageSize)
        {
            var sql = @"with workListItemLogs as (
                            select ProcInstID, ApproveDatetime
                            from Runtime.WorkListItemLog with(nolock)
                            where ActionerAccount = @userCode
                            and IsDisplay = 1
                            and WLField5 = 0
                        )

                        select FormInstanceCode
                        from workListItemLogs with(nolock)
                        inner join Runtime.ProcessInstance with(nolock) on ProcessInstance.ProcInstID = workListItemLogs.ProcInstID
                        order by workListItemLogs.ApproveDatetime desc
                        offset @offset rows fetch next @pageSize rows only";
            return await DbConnection.QueryAsync<string>(sql, new { userCode, offset = pageIndex * pageSize, pageSize });
        }

        /// <summary>
        /// 获取已审批流程实例的详情
        /// </summary>
        /// <param name="formInstanceCode"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ApprovedProcessInstanceDetail>> GetApprovedProcessInstanceDetailAsync(string formInstanceCode)
        {
            var sql = @"declare @processInstanceId nvarchar(128);
                        
                        select @processInstanceId = ProcInstID
                        from Runtime.ProcessInstance with(nolock)
                        where FormInstanceCode = @formInstanceCode;

                        with processInstances as (
                            select FormInstanceCode, ProcInstID, Folio, StartUserAccount, StartUserChsName, StartUserFullName, ProcInstStatus
                            from Runtime.ProcessInstance
                            where ProcInstID = @processInstanceId
                        ), logs as (
                            select ProcInstID as ProcInstID, ApproveDatetime, ActionerAccount, ActionerChsName, ActionerFullName
                            from Runtime.WorkListItemLog with(nolock)
                            where ProcInstID = @processInstanceId
                            and IsDisplay = 1
                            and WLField5 = 0
                        )

                        select processInstances.*, logs.ApproveDatetime, logs.ActionerAccount, logs.ActionerChsName, logs.ActionerFullName
                        from processInstances
                        inner join logs on logs.ProcInstID = processInstances.ProcInstID";
            return await DbConnection.QueryAsync<ApprovedProcessInstanceDetail>(sql, new { formInstanceCode });
        }
    }
}