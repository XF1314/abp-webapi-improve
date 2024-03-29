﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Repositories;

namespace Com.OPPO.Mo.Identity
{
    public interface IIdentityUserRepository : IBasicRepository<IdentityUser, Guid>
    {
        Task<IdentityUser> FindByNormalizedUserNameAsync(
            [NotNull] string normalizedUserName,
            bool includeDetails = true,
            CancellationToken cancellationToken = default
        );

        Task<List<string>> GetRoleNamesAsync(
            Guid id,
            CancellationToken cancellationToken = default
        );

        Task<IdentityUser> FindByLoginAsync(
            [NotNull] string loginProvider,
            [NotNull] string providerKey,
            bool includeDetails = true,
            CancellationToken cancellationToken = default
        );

        Task<IdentityUser> FindByNormalizedEmailAsync(
            [NotNull] string normalizedEmail, 
            bool includeDetails = true,
            CancellationToken cancellationToken = default
        );

        Task<List<IdentityUser>> GetListByClaimAsync(
            Claim claim, 
            bool includeDetails = false,
            CancellationToken cancellationToken = default
        );

        Task<List<IdentityUser>> GetListByNormalizedRoleNameAsync(
            string normalizedRoleName, 
            bool includeDetails = false,
            CancellationToken cancellationToken = default
        );

        Task<List<IdentityUser>> GetListAsync(
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            string filter = null,
            bool includeDetails = false,
            CancellationToken cancellationToken = default
        );

        Task<List<IdentityRole>> GetRolesAsync(
            Guid id,
            bool includeDetails = false,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filter = null,
            CancellationToken cancellationToken = default
        );
    }
}
