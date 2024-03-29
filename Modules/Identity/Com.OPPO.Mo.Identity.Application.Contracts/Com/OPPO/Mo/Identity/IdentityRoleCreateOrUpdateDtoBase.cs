﻿using System.ComponentModel.DataAnnotations;
using Volo.Abp.ObjectExtending;

namespace Com.OPPO.Mo.Identity
{
    public class IdentityRoleCreateOrUpdateDtoBase : ExtensibleObject
    {
        [Required]
        [StringLength(IdentityRoleConsts.MaxNameLength)]
        public string Name { get; set; }

        public bool IsDefault { get; set; }

        public bool IsPublic { get; set; }
    }
}