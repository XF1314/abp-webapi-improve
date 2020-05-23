using System.Collections.Generic;

namespace Com.OPPO.Mo.PermissionManagement
{
    public class PermissionGroupDto
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public List<PermissionGrantInfoDto> Permissions { get; set; }
    }
}