﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Features;

namespace Com.OPPO.Mo.FeatureManagement
{
    public static class EditionFeatureManagerExtensions
    {
        public static Task<string> GetOrNullForEditionAsync(this IFeatureManager featureManager, [NotNull] string name, Guid editionId, bool fallback = true)
        {
            return featureManager.GetOrNullAsync(name, EditionFeatureValueProvider.ProviderName, editionId.ToString(), fallback);
        }

        public static Task<List<FeatureNameValue>> GetAllForEditionAsync(this IFeatureManager featureManager, Guid editionId, bool fallback = true)
        {
            return featureManager.GetAllAsync(EditionFeatureValueProvider.ProviderName, editionId.ToString(), fallback);
        }

        public static Task SetForEditionAsync(this IFeatureManager featureManager, Guid editionId, [NotNull] string name, [CanBeNull] string value, bool forceToSet = false)
        {
            return featureManager.SetAsync(name, value, EditionFeatureValueProvider.ProviderName, editionId.ToString(), forceToSet);
        }
    }
}