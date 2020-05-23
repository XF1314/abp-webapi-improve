using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Com.OPPO.Mo.Users.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Com.OPPO.Mo.Blogging.EntityFrameworkCore;

namespace Com.OPPO.Mo.Blogging.Users
{
    public class EfCoreBlogUserRepository : EfCoreUserRepositoryBase<IBloggingDbContext, BlogUser>, IBlogUserRepository
    {
        public EfCoreBlogUserRepository(IDbContextProvider<IBloggingDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {

        }

        public async Task<List<BlogUser>> GetUsersAsync(int maxCount, string filter, CancellationToken cancellationToken = default)
        {
            return await DbSet
                .WhereIf( !string.IsNullOrWhiteSpace( filter), x=>x.UserName.Contains(filter))
                .Take(maxCount).ToListAsync(cancellationToken);
        }
    }
}
