using System;
using System.Threading.Tasks;

namespace Com.OPPO.Mo.Identity
{
    public interface IUserRoleFinder
    {
        Task<string[]> GetRolesAsync(Guid userId);
    }
}
