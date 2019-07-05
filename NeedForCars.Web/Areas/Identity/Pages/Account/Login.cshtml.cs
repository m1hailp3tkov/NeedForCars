using System;
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

            bool isEmail = false;
            bool isValidIdentifier = true;

            // Check whether indetifier is a valid email or a valid username
            if (Input.Identifier.Contains('@'))
            {
                //email validation

                string emailRegex = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                               + "@"
                               + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z";
                Regex regex = new Regex(emailRegex);

                if (!regex.IsMatch(Input.Identifier))
                {
                    modelErrorMessage = "Email is not valid.";
                    isValidIdentifier = false;
                }

                isEmail = true;
            }
            else
            {
                //username validation

                string usernameRegex = "[A-Za-z0-9._]{3,20}";
                Regex regex = new Regex(usernameRegex);

                if (!regex.IsMatch(Input.Identifier))
                {
                    modelErrorMessage = "Username is not valid.";
                    isValidIdentifier = false;
                }

                isEmail = false;
            }

            if (ModelState.IsValid && isValidIdentifier)
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

                if(user == null)
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
    }
}
