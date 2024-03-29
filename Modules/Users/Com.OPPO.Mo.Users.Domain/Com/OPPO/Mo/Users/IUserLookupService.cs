﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Users
{
    public interface IUserLookupService<TUser>
        where TUser : class, IUser
    {
        Task<TUser> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<TUser> FindByUserNameAsync(string userName, CancellationToken cancellationToken = default);

        //TODO: More...
    }
}
