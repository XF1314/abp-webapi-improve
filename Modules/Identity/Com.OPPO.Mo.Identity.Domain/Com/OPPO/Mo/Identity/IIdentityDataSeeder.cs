﻿using System;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Com.OPPO.Mo.Identity
{
    public interface IIdentityDataSeeder
    {
        Task<IdentityDataSeedResult> SeedAsync(
            [NotNull] string adminEmail,
            [NotNull] string adminPassword,
            Guid? tenantId = null);
    }
}