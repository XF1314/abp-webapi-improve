﻿using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Features;

namespace Com.OPPO.Mo.FeatureManagement
{
    public class DefaultValueFeatureManagementProvider : IFeatureManagementProvider, ISingletonDependency
    {
        public string Name => DefaultValueFeatureValueProvider.ProviderName;

        public virtual Task<string> GetOrNullAsync(FeatureDefinition feature, string providerKey)
        {
            return Task.FromResult(feature.DefaultValue);
        }

        public virtual Task SetAsync(FeatureDefinition feature, string value, string providerKey)
        {
            throw new AbpException($"Can not set default value of a feature. It is only possible while defining the feature in a {typeof(IFeatureDefinitionProvider)} implementation.");
        }

        public virtual Task ClearAsync(FeatureDefinition feature, string providerKey)
        {
            throw new AbpException($"Can not clear default value of a feature. It is only possible while defining the feature in a {typeof(IFeatureDefinitionProvider)} implementation.");
        }
    }
}