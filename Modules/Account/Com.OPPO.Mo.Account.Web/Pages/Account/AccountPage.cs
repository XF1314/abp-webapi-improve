using Com.OPPO.Mo.Account.Localization;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Com.OPPO.Mo.Account.Web.Pages.Account
{
    public abstract class AccountPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<AccountResource> L { get; set; }
    }
}
