using GarageManager.Common;
using GarageManager.Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<GMUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly UserManager<GMUser> _userManager;
        private readonly IEmailSender _emailSender;

        public LoginModel(SignInManager<GMUser> signInManager,
            ILogger<LoginModel> logger,
            UserManager<GMUser> userManager,
            IEmailSender emailSender)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
            _emailSender = emailSender;
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
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

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

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager
                    .PasswordSignInAsync(
                    Input.Email, Input.Password,
                    false,
                    lockoutOnFailure: false);
                if (result.Succeeded)
                {
                   /* await emailSender.SendEmailAsync(Input.Email, "Login Confirmation",
                    $"You are logedIn Sucssesful.");
                    var user = await _userManager.FindByEmailAsync(Input.Email);
                    var role = await _userManager.IsInRoleAsync(user, GlobalConstants.EmployeeRoleName.ToUpper());

                    if (role)
                    {
                        return this.Redirect($"/Employees/Departments/CarsInDepartment/{user.DepartmentId}");
                    }
                    _logger.LogInformation("User logged in.");*/
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
