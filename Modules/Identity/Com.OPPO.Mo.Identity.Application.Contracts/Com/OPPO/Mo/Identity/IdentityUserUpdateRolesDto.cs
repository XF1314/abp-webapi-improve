using System.ComponentModel.DataAnnotations;

namespace Com.OPPO.Mo.Identity
{
    public class IdentityUserUpdateRolesDto
    {
        [Required]
        public string[] RoleNames { get; set; }
    }
}