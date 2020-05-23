using Com.OPPO.Mo.Domain.Repositories.Dapper;
using Com.OPPO.Mo.Inmail.InboxMail;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;

namespace Com.OPPO.Mo.Inmail.Dapper.Repository
{
    public class InboxMailReadonlyDapperRepository : DapperRepository<InmailReadonlyDbContext>, IInboxMailReadonlyDapperRepository, ITransientDependency
    {
        public InboxMailReadonlyDapperRepository(IDbContextProvider<InmailReadonlyDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        public virtual async Task<List<string>> GetMailCodeBySenderName(string senderName)
        {
            var mailCodes = await DbConnection.QueryAsync<string>(@$"SELECT MailCode
                                                                     FROM Platform_MailInbox WITH(NOLOCK)
                                                                     WHERE SenderName = '{senderName}'", DbTransaction);

            return mailCodes.ToList();
        }
    }
}
