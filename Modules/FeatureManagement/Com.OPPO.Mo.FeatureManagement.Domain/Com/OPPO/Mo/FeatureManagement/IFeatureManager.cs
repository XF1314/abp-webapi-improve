﻿using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Com.OPPO.Mo.FeatureManagement
{
    public interface IFeatureManager
    {
        Task<string> GetOrNullAsync([NotNull]string name, [NotNull] string providerName, [CanBeNull] string providerKey, bool fallback = true);

        Task<List<FeatureNameValue>> GetAllAsync([NotNull] string providerName, [CanBeNull] string providerKey, bool fallback = true);

        Task SetAsync([NotNull] string name, [CanBeNull] string value, [NotNull] string providerName, [CanBeNull] string providerKey, bool forceToSet = false);
    }
}