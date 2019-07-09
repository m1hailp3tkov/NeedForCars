using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using NeedForCars.Models;
using System.Text.RegularExpressions;
using NeedForCars.Web.Common;

namespace NeedForCars.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<NeedForCarsUser> _signInManager;
        private readonly UserManager<NeedForCarsUser> _userManager;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(SignInManager<NeedForCarsUser> signInManager, UserManager<NeedForCarsUser> userManager, ILogger<LoginModel> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Username or E-mail")]
            public string Identifier { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            string modelErrorMessage = "";

            bool isEmail = Input.Identifier.Contains('@');

            if (!IsValidIdentifier(Input.Identifier))
            {
                if (isEmail)
                {
                    modelErrorMessage = "Invalid email";
                }
                else
                {
                    modelErrorMessage = "Invalid username";
                }

                ModelState.AddModelError("Identifier", modelErrorMessage);
                return Page();
            }

            if (ModelState.IsValid)
            {
                var identifier = Input.Identifier;
                NeedForCarsUser user;

                if (isEmail)
                {
                    user = await _userManager.FindByEmailAsync(Input.Identifier);
                    modelErrorMessage =
                        user == null ? "User with this email does not exist" : "";
                }
                else
                {
                    user = await _userManager.FindByNameAsync(Input.Identifier);
                    modelErrorMessage =
                        user == null ? "User with this username does not exist" : "";
                }

                if (user == null)
                {
                    ModelState.AddModelError("Identifier", modelErrorMessage);
                    return Page();
                }

                var result = await _signInManager.PasswordSignInAsync(user, Input.Password, Input.RememberMe, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError("Password", "Wrong password");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private bool IsValidIdentifier(string identifier)
        {
            Regex emailRegex = new Regex(GlobalConstants.EMAIL_REGEX);
            Regex usernameRegex = new Regex(GlobalConstants.USERNAME_REGEX);

            if (!emailRegex.IsMatch(identifier) && !usernameRegex.IsMatch(identifier))
            {
                return false;
            }

            return true;
        }
    }
}
