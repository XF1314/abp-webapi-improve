﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq;
using System.Linq.Dynamic.Core;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Com.OPPO.Mo.Identity.MongoDB
{
    public class MongoIdentityClaimTypeRepository : MongoDbRepository<IMoIdentityMongoDbContext, IdentityClaimType, Guid>, IIdentityClaimTypeRepository
    {
        public MongoIdentityClaimTypeRepository(IMongoDbContextProvider<IMoIdentityMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public virtual async Task<bool> AnyAsync(string name, Guid? ignoredId = null)
        {
            if (ignoredId == null)
            {
                return await GetMongoQueryable()
                    .Where(ct => ct.Name == name)
                    .AnyAsync();
            }
            else
            {
                return await GetMongoQueryable()
                    .Where(ct => ct.Id != ignoredId && ct.Name == name)
                    .AnyAsync();
            }
        }

        public virtual async Task<List<IdentityClaimType>> GetListAsync(string sorting, int maxResultCount, int skipCount, string filter)
        {
            return await GetMongoQueryable()
                .WhereIf<IdentityClaimType, IMongoQueryable<IdentityClaimType>>(
                    !filter.IsNullOrWhiteSpace(),
                    u =>
                        u.Name.Contains(filter)
                )
                .OrderBy(sorting ?? nameof(IdentityClaimType.Name))
                .As<IMongoQueryable<IdentityClaimType>>()
                .PageBy<IdentityClaimType, IMongoQueryable<IdentityClaimType>>(skipCount, maxResultCount)
                .ToListAsync();
        }
    }
}
