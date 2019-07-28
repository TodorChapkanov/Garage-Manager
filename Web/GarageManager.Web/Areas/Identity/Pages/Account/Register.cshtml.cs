using GarageManager.Common;
using GarageManager.Domain;
using GarageManager.Extensions.DateTimeProviders;
using GarageManager.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace GarageManager.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<GMUser> _signInManager;
        private readonly UserManager<GMUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IDepartmentService _departmentService;

        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<GMUser> userManager,
            SignInManager<GMUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<RegisterModel> logger,
            IDateTimeProvider dateTimeProvider,
            IDepartmentService departmentService,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _logger = logger;
            _dateTimeProvider = dateTimeProvider;
            _departmentService = departmentService;
             _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            public string FirstName { get; set; }

            [Required]
            public string LastName { get; set; }

            [Required]
            [DataType(DataType.PhoneNumber)]
            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = "/Admin/Employees/AllEmployees";
            //TODO constant for the path
            if (ModelState.IsValid)
            {
                
                var user = new GMUser
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    PhoneNumber = Input.PhoneNumber,
                    CreatedOn = _dateTimeProvider.GetDateTime()
                };

               IdentityResult result = null;
                if (_userManager.Users.Count() == 0)
                {
                    user.CreatedOn = _dateTimeProvider.GetDateTime();
                    user.RecruitedOn = _dateTimeProvider.GetDateTime();
                    user.DepartmentId = (await _departmentService
                        .AllDepartmentsAsync())
                        .FirstOrDefault(department => department.Name == GlobalConstants.FacilitiesManagement)
                        .Id;
                    result = await _userManager.CreateAsync(user, Input.Password);
                    await _userManager.AddToRoleAsync(user, GlobalConstants.AdministratorRoleName);
                }
                else
                {
                    result = await _userManager.CreateAsync(user, Input.Password);
                    await _userManager.AddToRoleAsync(user, GlobalConstants.EmployeeRoleName);
                    
                }

                if (result.Succeeded)
                {
                    
                    _logger.LogInformation("User created a new account with password.");
                    var registeredUser =await this._userManager.FindByEmailAsync(Input.Email);
                      var code = await _userManager.GenerateEmailConfirmationTokenAsync(registeredUser);
                      var callbackUrl = Url.Page(
                          "/Account/ConfirmEmail",
                          pageHandler: null,
                          values: new { userId = registeredUser.Id, code = code },
                          protocol: Request.Scheme);

                      await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                      $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    
                   
                   // await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
