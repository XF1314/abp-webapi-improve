using System.Collections.Generic;

namespace Com.OPPO.Mo.PermissionManagement
{
    public class GetPermissionListResultDto
    {
        public string EntityDisplayName { get; set; }

        public List<PermissionGroupDto> Groups { get; set; }
    }
}