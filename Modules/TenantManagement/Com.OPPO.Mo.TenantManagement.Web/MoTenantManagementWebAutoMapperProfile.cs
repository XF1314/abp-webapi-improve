using AutoMapper;
using Volo.Abp.AutoMapper;
using Com.OPPO.Mo.TenantManagement.Web.Pages.TenantManagement.Tenants;

namespace Com.OPPO.Mo.TenantManagement.Web
{
    public class MoTenantManagementWebAutoMapperProfile : Profile
    {
        public MoTenantManagementWebAutoMapperProfile()
        {
            //List
            CreateMap<TenantDto, EditModalModel.TenantInfoModel>();

            //CreateModal
            CreateMap<CreateModalModel.TenantInfoModel, TenantCreateDto>()
                .Ignore(x => x.ExtraProperties);

            //EditModal
            CreateMap<EditModalModel.TenantInfoModel, TenantUpdateDto>()
                .Ignore(x => x.ExtraProperties);
        }
    }
}
