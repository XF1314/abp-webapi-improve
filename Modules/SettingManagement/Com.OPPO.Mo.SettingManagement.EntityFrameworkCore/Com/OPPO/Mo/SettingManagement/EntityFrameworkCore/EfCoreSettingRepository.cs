﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Com.OPPO.Mo.SettingManagement.EntityFrameworkCore
{
    public class EfCoreSettingRepository : EfCoreRepository<ISettingManagementDbContext, Setting, Guid>, ISettingRepository
    {
        public EfCoreSettingRepository(IDbContextProvider<ISettingManagementDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public virtual async Task<Setting> FindAsync(string name, string providerName, string providerKey)
        {
            return await DbSet
                .FirstOrDefaultAsync(
                    s => s.Name == name && s.ProviderName == providerName && s.ProviderKey == providerKey
                );
        }

        public virtual async Task<List<Setting>> GetListAsync(string providerName, string providerKey)
        {
            return await DbSet
                .Where(
                    s => s.ProviderName == providerName && s.ProviderKey == providerKey
                ).ToListAsync();
        }
    }
}
