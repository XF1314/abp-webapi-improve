using Com.OPPO.Mo.Account.Web.Pages.Account;
using AutoMapper;
using Com.OPPO.Mo.Identity;

namespace Com.OPPO.Mo.Account.Web
{
    public class MoAccountWebAutoMapperProfile : Profile
    {
        public MoAccountWebAutoMapperProfile()
        {
            CreateMap<ProfileDto, PersonalSettingsInfoModel>();
        }
    }
}
