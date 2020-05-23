using AutoMapper;
using Com.OPPO.Mo.Users;
using Volo.Abp.Users;

namespace Com.OPPO.Mo.Identity
{
    public class IdentityDomainMappingProfile : Profile
    {
        public IdentityDomainMappingProfile()
        {
            CreateMap<IdentityUser, UserEto>();
            CreateMap<IdentityClaimType, IdentityClaimTypeEto>();
            CreateMap<IdentityRole, IdentityRoleEto>();
        }
    }
}