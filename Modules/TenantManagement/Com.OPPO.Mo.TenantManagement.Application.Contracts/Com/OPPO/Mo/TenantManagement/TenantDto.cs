using System;
using Volo.Abp.Application.Dtos;

namespace Com.OPPO.Mo.TenantManagement
{
    public class TenantDto : ExtensibleEntityDto<Guid>
    {
        public string Name { get; set; }
    }
}