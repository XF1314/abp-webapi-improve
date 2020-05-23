using System;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;
using Com.OPPO.Mo.Blogging.MongoDB;

namespace Com.OPPO.Mo.Blogging.Blogs
{
    public class MongoBlogRepository : MongoDbRepository<IBloggingMongoDbContext, Blog, Guid>, IBlogRepository
    {
        public MongoBlogRepository(IMongoDbContextProvider<IBloggingMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Blog> FindByShortNameAsync(string shortName)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(p => p.ShortName == shortName);
        }
    }
}
