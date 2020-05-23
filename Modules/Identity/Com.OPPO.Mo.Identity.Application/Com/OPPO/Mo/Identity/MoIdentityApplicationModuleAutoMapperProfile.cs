using AutoMapper;

namespace Com.OPPO.Mo.Identity
{
    public class MoIdentityApplicationModuleAutoMapperProfile : Profile
    {
        public MoIdentityApplicationModuleAutoMapperProfile()
        {
            CreateMap<IdentityUser, IdentityUserDto>()
                .MapExtraProperties();

            CreateMap<IdentityRole, IdentityRoleDto>()
                .MapExtraProperties();
            
            CreateMap<IdentityUser, ProfileDto>()
                .MapExtraProperties();
        }
    }
}