using Com.OPPO.Mo.Blogging.Posts;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Com.OPPO.Mo.Blogging
{
    public static class MoBloggingEntityFrameworkCoreQueryableExtensions
    {
        public static IQueryable<Post> IncludeDetails(this IQueryable<Post> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .Include(x => x.Tags);
        }
    }
}
