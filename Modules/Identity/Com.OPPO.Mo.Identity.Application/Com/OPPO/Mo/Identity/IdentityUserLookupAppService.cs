using System;
using System.Threading.Tasks;
using Com.OPPO.Mo.Users;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Users;

namespace Com.OPPO.Mo.Identity
{
    [Authorize(IdentityPermissions.UserLookup.Default)]
    public class IdentityUserLookupAppService : IdentityAppServiceBase, IIdentityUserLookupAppService
    {
        protected IdentityUserRepositoryExternalUserLookupServiceProvider UserLookupServiceProvider { get; }

        public IdentityUserLookupAppService(
            IdentityUserRepositoryExternalUserLookupServiceProvider userLookupServiceProvider)
        {
            UserLookupServiceProvider = userLookupServiceProvider;
        }

        public virtual async Task<UserData> FindByIdAsync(Guid id)
        {
            var userData = await UserLookupServiceProvider.FindByIdAsync(id);
            if (userData == null)
            {
                return null;
            }

            return new UserData(userData);
        }

        public virtual async Task<UserData> FindByUserNameAsync(string userName)
        {
            var userData = await UserLookupServiceProvider.FindByUserNameAsync(userName);
            if (userData == null)
            {
                return null;
            }

            return new UserData(userData);
        }
    }
}
