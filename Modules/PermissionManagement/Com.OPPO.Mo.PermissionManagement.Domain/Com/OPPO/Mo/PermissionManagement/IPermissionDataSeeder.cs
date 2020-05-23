using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.PermissionManagement
{
    public interface IPermissionDataSeeder
    {
        Task SeedAsync(
            string providerName,
            string providerKey,
            IEnumerable<string> grantedPermissions,
            Guid? tenantId = null
        );
    }
}
