using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Com.OPPO.Mo.Users;

namespace Com.OPPO.Mo.Blogging.Users
{
    public interface IBlogUserRepository : IBasicRepository<BlogUser, Guid>, IUserRepository<BlogUser>
    {
        Task<List<BlogUser>> GetUsersAsync(int maxCount, string filter, CancellationToken cancellationToken = default);
    }
}