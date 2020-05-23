using System.ComponentModel.DataAnnotations;
using Volo.Abp.Auditing;

namespace Com.OPPO.Mo.Identity
{
    public class IdentityUserCreateDto : IdentityUserCreateOrUpdateDtoBase
    {
        [Required]
        [StringLength(IdentityUserConsts.MaxPasswordLength)]
        [DisableAuditing]
        public string Password { get; set; }
    }
}