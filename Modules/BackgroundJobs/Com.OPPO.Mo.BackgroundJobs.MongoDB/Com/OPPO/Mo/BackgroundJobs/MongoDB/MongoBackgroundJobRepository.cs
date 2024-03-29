﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;
using Volo.Abp.Timing;

namespace Com.OPPO.Mo.BackgroundJobs.MongoDB
{
    public class MongoBackgroundJobRepository : MongoDbRepository<IBackgroundJobsMongoDbContext, BackgroundJobRecord, Guid>, IBackgroundJobRepository
    {
        protected IClock Clock { get; }

        public MongoBackgroundJobRepository(
            IMongoDbContextProvider<IBackgroundJobsMongoDbContext> dbContextProvider, 
            IClock clock) 
            : base(dbContextProvider)
        {
            Clock = clock;
        }

        public virtual async Task<List<BackgroundJobRecord>> GetWaitingListAsync(int maxResultCount)
        {
            return await GetWaitingListQuery(maxResultCount)
                .ToListAsync();
        }

        protected virtual IMongoQueryable<BackgroundJobRecord> GetWaitingListQuery(int maxResultCount)
        {
            var now = Clock.Now;
            return GetMongoQueryable()
                .Where(t => !t.IsAbandoned && t.NextTryTime <= now)
                .OrderByDescending(t => t.Priority)
                .ThenBy(t => t.TryCount)
                .ThenBy(t => t.NextTryTime)
                .Take(maxResultCount);
        }
    }
}
