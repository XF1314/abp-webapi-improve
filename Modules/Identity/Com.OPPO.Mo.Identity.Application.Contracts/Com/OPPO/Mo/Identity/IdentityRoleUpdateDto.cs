using Volo.Abp.Domain.Entities;

namespace Com.OPPO.Mo.Identity
{
    public class IdentityRoleUpdateDto : IdentityRoleCreateOrUpdateDtoBase, IHasConcurrencyStamp
    {
        public string ConcurrencyStamp { get; set; }
    }
}