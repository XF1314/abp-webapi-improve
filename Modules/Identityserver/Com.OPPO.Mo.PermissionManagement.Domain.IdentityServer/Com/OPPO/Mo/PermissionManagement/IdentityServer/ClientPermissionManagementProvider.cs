﻿using Com.OPPO.Mo.PermissionManagement;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;

namespace Com.OPPO.Mo.PermissionManagement.IdentityServer
{
    public class ClientPermissionManagementProvider : PermissionManagementProvider
    {
        public override string Name => ClientPermissionValueProvider.ProviderName;

        public ClientPermissionManagementProvider(
            IPermissionGrantRepository permissionGrantRepository,
            IGuidGenerator guidGenerator,
            ICurrentTenant currentTenant)
            : base(
                permissionGrantRepository,
                guidGenerator,
                currentTenant)
        {

        }
    }
}
