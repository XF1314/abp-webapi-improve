﻿using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;

namespace Com.OPPO.Mo.PermissionManagement
{
    public class PermissionDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        protected ICurrentTenant CurrentTenant { get; }

        protected IPermissionDefinitionManager PermissionDefinitionManager { get; }
        protected IPermissionDataSeeder PermissionDataSeeder { get; }

        public PermissionDataSeedContributor(
            IPermissionDefinitionManager permissionDefinitionManager,
            IPermissionDataSeeder permissionDataSeeder,
            ICurrentTenant currentTenant)
        {
            PermissionDefinitionManager = permissionDefinitionManager;
            PermissionDataSeeder = permissionDataSeeder;
            CurrentTenant = currentTenant;
        }

        public virtual Task SeedAsync(DataSeedContext context)
        {
            var multiTenancySide = CurrentTenant.GetMultiTenancySide();
            var permissionNames = PermissionDefinitionManager
                .GetPermissions()
                .Where(p => p.MultiTenancySide.HasFlag(multiTenancySide))
                .Select(p => p.Name)
                .ToArray();

            return PermissionDataSeeder.SeedAsync(
                RolePermissionValueProvider.ProviderName,
                "admin",
                permissionNames,
                context.TenantId
            );
        }
    }
}
