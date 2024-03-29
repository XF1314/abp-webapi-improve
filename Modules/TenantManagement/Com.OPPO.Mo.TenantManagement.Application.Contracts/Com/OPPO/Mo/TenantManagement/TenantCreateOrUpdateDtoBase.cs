﻿using System.ComponentModel.DataAnnotations;
using Volo.Abp.ObjectExtending;

namespace Com.OPPO.Mo.TenantManagement
{
    public abstract class TenantCreateOrUpdateDtoBase : ExtensibleObject
    {
        [Required]
        [StringLength(TenantConsts.MaxNameLength)]
        public string Name { get; set; }
    }
}