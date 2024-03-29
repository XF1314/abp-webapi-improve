﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Com.OPPO.Mo.Users
{
    public interface IUserRepository<TUser> : IBasicRepository<TUser, Guid>
        where TUser : class, IUser, IAggregateRoot<Guid>
    {
        Task<TUser> FindByUserNameAsync(string userName, CancellationToken cancellationToken = default);

        Task<List<TUser>> GetListAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
    }
}