﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Extensions.Localization;
using Com.OPPO.Mo.Identity;
using Volo.Abp.Text.Formatting;

namespace Microsoft.AspNetCore.Identity
{
    public static class AbpIdentityResultExtensions
    {
        public static void CheckErrors(this IdentityResult identityResult)
        {
            if (identityResult.Succeeded)
            {
                return;
            }

            if (identityResult.Errors == null)
            {
                throw new ArgumentException("identityResult.Errors should not be null.");
            }

            throw new MoIdentityResultException(identityResult);
        }

        [Obsolete]
        public static string LocalizeErrors(this IdentityResult identityResult, IStringLocalizer localizer)
        {
            if (identityResult.Succeeded)
            {
                throw new ArgumentException("identityResult.Succeeded should be false in order to localize errors.");
            }

            if (identityResult.Errors == null)
            {
                throw new ArgumentException("identityResult.Errors should not be null.");
            }

            return identityResult.Errors.Select(err => LocalizeErrorMessage(err, localizer)).JoinAsString(", ");
        }

        [Obsolete]
        public static string LocalizeErrorMessage(this IdentityError error, IStringLocalizer localizer)
        {
            var key = $"Identity.{error.Code}";

            var localizedString = localizer[key];

            if (!localizedString.ResourceNotFound)
            {
                var englishLocalizedString = localizer.WithCulture(CultureInfo.GetCultureInfo("en"))[key];
                if (!englishLocalizedString.ResourceNotFound)
                {
                    if (FormattedStringValueExtracter.IsMatch(error.Description, englishLocalizedString.Value, out var values))
                    {
                        return string.Format(localizedString.Value, values.Cast<object>().ToArray());
                    }
                }
            }

            return localizer["Identity.Default"];
        }

        public static string GetResultAsString(this SignInResult signInResult)
        {
            if (signInResult.Succeeded)
            {
                return "Succeeded";
            }

            if (signInResult.IsLockedOut)
            {
                return "IsLockedOut";
            }

            if (signInResult.IsNotAllowed)
            {
                return "IsNotAllowed";
            }

            if (signInResult.RequiresTwoFactor)
            {
                return "RequiresTwoFactor";
            }

            return "Unknown";
        }
    }
}
