﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Com.OPPO.Mo.IdentityServer.ApiResources;
using System.Linq.Dynamic.Core;
using Volo.Abp.MongoDB;

namespace Com.OPPO.Mo.IdentityServer.MongoDB
{
    public class MongoApiResourceRepository : MongoDbRepository<IMoIdentityServerMongoDbContext, ApiResource, Guid>, IApiResourceRepository
    {
        public MongoApiResourceRepository(IMongoDbContextProvider<IMoIdentityServerMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public virtual async Task<ApiResource> FindByNameAsync(string name, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable()
                .Where(ar => ar.Name == name)
                .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<ApiResource>> GetListByScopesAsync(string[] scopeNames, bool includeDetails = false,
            CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable()
                .Where(ar => ar.Scopes.Any(x => scopeNames.Contains(x.Name)))
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<ApiResource>> GetListAsync(string sorting, int skipCount, int maxResultCount, bool includeDetails = false,
            CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable()
                .OrderBy(sorting ?? nameof(ApiResource.Name))
                .As<IMongoQueryable<ApiResource>>()
                .PageBy<ApiResource, IMongoQueryable<ApiResource>>(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<long> GetTotalCount()
        {
            return await GetCountAsync();
        }

        public virtual async Task<bool> CheckNameExistAsync(string name, Guid? expectedId = null, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().AnyAsync(ar => ar.Id != expectedId && ar.Name == name, cancellationToken: cancellationToken);
        }
    }
}
