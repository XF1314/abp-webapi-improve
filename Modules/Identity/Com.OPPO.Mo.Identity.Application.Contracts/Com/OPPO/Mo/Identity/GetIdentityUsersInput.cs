using Volo.Abp.Application.Dtos;

namespace Com.OPPO.Mo.Identity
{
    public class GetIdentityUsersInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
