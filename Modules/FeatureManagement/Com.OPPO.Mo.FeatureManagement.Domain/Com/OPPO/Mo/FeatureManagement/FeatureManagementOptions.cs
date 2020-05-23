﻿using System.Collections.Generic;
using Volo.Abp.Collections;

namespace Com.OPPO.Mo.FeatureManagement
{
    public class FeatureManagementOptions
    {
        public ITypeList<IFeatureManagementProvider> Providers { get; }

        public Dictionary<string, string> ProviderPolicies { get; }

        public FeatureManagementOptions()
        {
            Providers = new TypeList<IFeatureManagementProvider>();
            ProviderPolicies = new Dictionary<string, string>();
        }
    }
}