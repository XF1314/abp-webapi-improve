using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Com.OPPO.Mo.Account.Localization;
using Com.OPPO.Mo.Account.Settings;
using Com.OPPO.Mo.Account.Web.Areas.Account.Controllers.Models;
using Volo.Abp.AspNetCore.Mvc;
using Com.OPPO.Mo.Identity;
using Volo.Abp.Settings;
using Volo.Abp.Validation;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using UserLoginInfo = Com.OPPO.Mo.Account.Web.Areas.Account.Controllers.Models.UserLoginInfo;
using IdentityUser = Com.OPPO.Mo.Identity.IdentityUser;
using Volo.Abp;

namespace Com.OPPO.Mo.Account.Web.Areas.Account.Controllers
{
    [RemoteService(Name = AccountRemoteServiceConsts.RemoteServiceName)]
    [Controller]
    [ControllerName("Login")]
    [Area("Account")]
    [Route("api/account")]
    public class AccountController : AbpController
    {
        protected SignInManager<IdentityUser> SignInManager { get; }
        protected IdentityUserManager UserManager { get; }
        protected ISettingProvider SettingProvider { get; }

        public AccountController(SignInManager<IdentityUser> signInManager, IdentityUserManager userManager, ISettingProvider settingProvider)
        {
            LocalizationResource = typeof(AccountResource);

            SignInManager = signInManager;
            UserManager = userManager;
            SettingProvider = settingProvider;
        }

        [HttpPost]
        [Route("login")]
        public virtual async Task<MoLoginResult> Login(UserLoginInfo login)
        {
            await CheckLocalLoginAsync();

            ValidateLoginInfo(login);

            await ReplaceEmailToUsernameOfInputIfNeeds(login);
            
            return GetAbpLoginResult(await SignInManager.PasswordSignInAsync(
                login.UserNameOrEmailAddress,
                login.Password,
                login.RememberMe,
                true
            ));
        }

        [HttpGet]
        [Route("logout")]
        public virtual async Task Logout()
        {
           await SignInManager.SignOutAsync();
        }

        [HttpPost]
        [Route("checkPassword")]
        public virtual async Task<MoLoginResult> CheckPassword(UserLoginInfo login)
        {
            ValidateLoginInfo(login);

            await ReplaceEmailToUsernameOfInputIfNeeds(login);

            var identityUser = await UserManager.FindByNameAsync(login.UserNameOrEmailAddress);

            if (identityUser == null)
            {
                return new MoLoginResult(LoginResultType.InvalidUserNameOrPassword);
            }

            return GetAbpLoginResult(await SignInManager.CheckPasswordSignInAsync(identityUser, login.Password, true));
        }

        protected virtual async Task ReplaceEmailToUsernameOfInputIfNeeds(UserLoginInfo login)
        {
            if (!ValidationHelper.IsValidEmailAddress(login.UserNameOrEmailAddress))
            {
                return;
            }

            var userByUsername = await UserManager.FindByNameAsync(login.UserNameOrEmailAddress);
            if (userByUsername != null)
            {
                return;
            }

            var userByEmail = await UserManager.FindByEmailAsync(login.UserNameOrEmailAddress);
            if (userByEmail == null)
            {
                return;
            }

            login.UserNameOrEmailAddress = userByEmail.UserName;
        }

        private static MoLoginResult GetAbpLoginResult(SignInResult result)
        {
            if (result.IsLockedOut)
            {
                return new MoLoginResult(LoginResultType.LockedOut);
            }

            if (result.RequiresTwoFactor)
            {
                return new MoLoginResult(LoginResultType.RequiresTwoFactor);
            }

            if (result.IsNotAllowed)
            {
                return new MoLoginResult(LoginResultType.NotAllowed);
            }

            if (!result.Succeeded)
            {
                return new MoLoginResult(LoginResultType.InvalidUserNameOrPassword);
            }

            return new MoLoginResult(LoginResultType.Success);
        }

        protected virtual void ValidateLoginInfo(UserLoginInfo login)
        {
            if (login == null)
            {
                throw new ArgumentException(nameof(login));
            }

            if (login.UserNameOrEmailAddress.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(login.UserNameOrEmailAddress));
            }

            if (login.Password.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(login.Password));
            }
        }

        protected virtual async Task CheckLocalLoginAsync()
        {
            if (!await SettingProvider.IsTrueAsync(AccountSettingNames.EnableLocalLogin))
            {
                throw new UserFriendlyException(L["LocalLoginDisabledMessage"]);
            }
        }
    }
}
