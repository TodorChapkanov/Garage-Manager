using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using GM.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GarageManager.Areas.Identity.Pages.Account
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
            var returnUrl = GlobalConstants.DefaultLogoutUrl;
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            
                return LocalRedirect(returnUrl);
           
        }

        public void  OnPost()
        {
           
        }
    }
}