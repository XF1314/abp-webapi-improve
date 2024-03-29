﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Com.OPPO.Mo.Account.Web.Pages.Account
{
    public class LogoutModel : AccountPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; }

        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public string ReturnUrlHash { get; set; }

        public virtual async Task<IActionResult> OnGetAsync()
        {
            await SignInManager.SignOutAsync();
            if (ReturnUrl != null)
            {
                return RedirectSafely(ReturnUrl, ReturnUrlHash);
            }

            return RedirectToPage("/Account/Login");
        }

        public virtual Task OnPostAsync()
        {
            return Task.CompletedTask;
        }
    }
}
