using Abp.Auditing;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Configuration.Startup;
using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using tmss.Authorization;
using tmss.Authorization.Accounts;
using tmss.Authorization.Accounts.Dto;
using tmss.Authorization.Users;
using tmss.Identity;
using tmss.MultiTenancy;
using tmss.Web.Models.Ui;
using tmss.Web.Session;

namespace tmss.Web.Controllers
{
    public class UiController : tmssControllerBase
    {
        private readonly IPerRequestSessionCache _sessionCache;
        private readonly IMultiTenancyConfig _multiTenancyConfig;
        private readonly LogInManager _logInManager;
        private readonly SignInManager _signInManager;
        private readonly AbpLoginResultTypeHelper _abpLoginResultTypeHelper;

        public UiController(
            IPerRequestSessionCache sessionCache,
            IMultiTenancyConfig multiTenancyConfig,
            LogInManager logInManager,
            SignInManager signInManager,
            AbpLoginResultTypeHelper abpLoginResultTypeHelper)
        {
            _sessionCache = sessionCache;
            _multiTenancyConfig = multiTenancyConfig;
            _logInManager = logInManager;
            _signInManager = signInManager;
            _abpLoginResultTypeHelper = abpLoginResultTypeHelper;
        }

        [DisableAuditing]
        public async Task<IActionResult> Index()
        {
            var model = new HomePageModel
            {
                LoginInformation = await _sessionCache.GetCurrentLoginInformationsAsync(),
                IsMultiTenancyEnabled = _multiTenancyConfig.IsEnabled
            };

            if (model.LoginInformation?.User == null)
            {
                return RedirectToAction("Login");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = "")
        {
            if (!string.IsNullOrEmpty(returnUrl))
            {
                ViewBag.ReturnUrl = returnUrl;
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl = "")
        {
           
            var loginResult = await GetLoginResultAsync(model.UserNameOrEmailAddress, model.Password);

            if (loginResult.User.ShouldChangePasswordOnNextLogin)
            {
                throw new UserFriendlyException(L("RequiresPasswordChange"));
            }

            var signInResult = await _signInManager.SignInOrTwoFactorAsync(loginResult, model.RememberMe);

            if (signInResult.RequiresTwoFactor)
            {
                throw new UserFriendlyException(L("RequiresTwoFactorAuth"));
            }

            if (!string.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index");
        }

        private async Task<AbpLoginResult<Tenant, User>> GetLoginResultAsync(string usernameOrEmailAddress, string password)
        {
            var loginResult = await _logInManager.LoginAsync(usernameOrEmailAddress, password);
             return loginResult;
        }
    }
}