using AutoMapper;

namespace Com.OPPO.Mo.TenantManagement
{
    public class MoTenantManagementApplicationAutoMapperProfile : Profile
    {
        public MoTenantManagementApplicationAutoMapperProfile()
        {
            CreateMap<Tenant, TenantDto>()
                .MapExtraProperties();
        }
    }
}