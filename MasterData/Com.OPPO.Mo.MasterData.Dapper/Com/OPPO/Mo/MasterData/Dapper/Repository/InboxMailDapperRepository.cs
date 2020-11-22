using Com.OPPO.Mo.Domain.Repositories.Dapper;
using Com.OPPO.Mo.MasterData.InboxMail;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;

namespace Com.OPPO.Mo.MasterData.Dapper.Repository
{
    public class InboxMailDapperRepository : DapperRepository<MoDbContext>, IInboxMailDapperRepository, ITransientDependency
    {
        public InboxMailDapperRepository(IDbContextProvider<MoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public virtual async Task<int> SetMailSubjectByCode(string mailCode, string mailSubject)
        {
            return await DbConnection.ExecuteAsync(@$"UPATE Platform_MailInbox
                                                      SET MailSubject = '{mailSubject}'
                                                      WHERE MailCode = '{mailCode}'", DbTransaction);
        }
    }
}
