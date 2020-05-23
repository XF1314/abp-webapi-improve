using Volo.Abp.Application.Dtos;

namespace Com.OPPO.Mo.TenantManagement
{
    public class GetTenantsInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}