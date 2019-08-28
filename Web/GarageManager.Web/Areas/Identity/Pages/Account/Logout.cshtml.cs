using GarageManager.Common;
using GarageManager.Common.GlobalConstant;
using GarageManager.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GarageManager.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<GMUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;

        public LogoutModel(SignInManager<GMUser> signInManager, ILogger<LogoutModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        public async Task<IActionResult> OnGet()
        {
            var returnUrl = WebConstants.HomeIndex;
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            
                return LocalRedirect(returnUrl);
           
        }

        public void  OnPost()
        {
           
        }
    }
}