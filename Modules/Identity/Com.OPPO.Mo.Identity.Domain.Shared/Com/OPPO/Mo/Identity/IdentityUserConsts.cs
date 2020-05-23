using Com.OPPO.Mo.Users;
using Volo.Abp.Users;

namespace Com.OPPO.Mo.Identity
{
    public static class IdentityUserConsts
    {
        public const int MaxUserNameLength = MoUserConsts.MaxUserNameLength;

        public const int MaxNameLength = MoUserConsts.MaxNameLength;

        public const int MaxSurnameLength = MoUserConsts.MaxSurnameLength;

        public const int MaxNormalizedUserNameLength = MaxUserNameLength;

        public const int MaxEmailLength = MoUserConsts.MaxEmailLength;

        public const int MaxNormalizedEmailLength = MaxEmailLength;

        public const int MaxPhoneNumberLength = MoUserConsts.MaxPhoneNumberLength;

        public const int MaxPasswordLength = 128;

        public const int MaxPasswordHashLength = 256;

        public const int MaxSecurityStampLength = 256;

        public const int MaxConcurrencyStampLength = 256;
    }
}
