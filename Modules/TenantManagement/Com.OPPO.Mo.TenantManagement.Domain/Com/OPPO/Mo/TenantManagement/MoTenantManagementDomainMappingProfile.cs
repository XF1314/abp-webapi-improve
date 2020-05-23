using AutoMapper;
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;

namespace Com.OPPO.Mo.TenantManagement
{
    public class MoTenantManagementDomainMappingProfile : Profile
    {
        public MoTenantManagementDomainMappingProfile()
        {
            CreateMap<Tenant, TenantConfiguration>()
                .ForMember(ti => ti.ConnectionStrings, opts =>
                {
                    opts.MapFrom((tenant, ti) =>
                    {
                        var connStrings = new ConnectionStrings();

                        foreach (var connectionString in tenant.ConnectionStrings)
                        {
                            connStrings[connectionString.Name] = connectionString.Value;
                        }

                        return connStrings;
                    });
                });

            CreateMap<Tenant, TenantEto>();
        }
    }
}
