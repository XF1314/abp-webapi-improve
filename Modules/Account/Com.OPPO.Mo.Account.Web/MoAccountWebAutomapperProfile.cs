using Com.OPPO.Mo.Account.Web.Pages.Account;
using Com.OPPO.Mo.Identity;
using AutoMapper;

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
