﻿using Com.OPPO.Mo.Identity;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Auditing;

namespace Com.OPPO.Mo.Account
{
    public class RegisterDto
    {
        [Required]
        [StringLength(IdentityUserConsts.MaxUserNameLength)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(IdentityUserConsts.MaxEmailLength)]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(IdentityUserConsts.MaxPasswordLength)]
        [DataType(DataType.Password)]
        [DisableAuditing]
        public string Password { get; set; }

        [Required]
        public string AppName { get; set; }
    }
}