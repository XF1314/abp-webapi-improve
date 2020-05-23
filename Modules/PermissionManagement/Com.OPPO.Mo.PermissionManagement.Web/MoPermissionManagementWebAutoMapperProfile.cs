using AutoMapper;
using Volo.Abp.AutoMapper;
using Com.OPPO.Mo.PermissionManagement.Web.Pages.PermissionManagement;

namespace Com.OPPO.Mo.PermissionManagement.Web
{
    public class MoPermissionManagementWebAutoMapperProfile : Profile
    {
        public MoPermissionManagementWebAutoMapperProfile()
        {
            CreateMap<PermissionGroupDto, PermissionManagementModal.PermissionGroupViewModel>().Ignore(p=>p.IsAllPermissionsGranted);

            CreateMap<PermissionGrantInfoDto, PermissionManagementModal.PermissionGrantInfoViewModel>()
                .ForMember(p => p.Depth, opts => opts.Ignore());

            CreateMap<ProviderInfoDto, PermissionManagementModal.ProviderInfoViewModel>();
        }
    }
}
