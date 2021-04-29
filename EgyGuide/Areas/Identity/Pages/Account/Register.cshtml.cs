using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using EgyGuide.DataAccess.Repository.IRepository;
using EgyGuide.Models;
using EgyGuide.Models.ViewModels;
using EgyGuide.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace EgyGuide.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IWebHostEnvironment _hostEnviroment;

        public RegisterModel(
            IUnitOfWork unitOfWork,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IWebHostEnvironment hostEnviroment)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _hostEnviroment = hostEnviroment;
        }

        [BindProperty]
        public RegisterVM RegisterVM { get; set; }
        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    FirstName = RegisterVM.Input.FirstName,
                    LastName = RegisterVM.Input.LastName,
                    Country = RegisterVM.Input.Country,
                    Nationality = RegisterVM.Input.Nationality,
                    PhoneNumber = RegisterVM.Input.PhoneNumber,
                    City = RegisterVM.Input.City,
                    UserName = RegisterVM.Input.Email,
                    Email = RegisterVM.Input.Email,
                    Role = RegisterVM.Input.Role
                };                

                // Add new user.
                var result = await _userManager.CreateAsync(user, RegisterVM.Input.Password);                  

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    //if (!await _roleManager.RoleExistsAsync(SD.Role_User_Admin))
                    //    await _roleManager.CreateAsync(new IdentityRole (SD.Role_User_Admin));

                    //if (!await _roleManager.RoleExistsAsync(SD.Role_User_Tourist))
                    //    await _roleManager.CreateAsync(new IdentityRole(SD.Role_User_Tourist));

                    //if (!await _roleManager.RoleExistsAsync(SD.Role_User_Suspended_Guide))
                    //    await _roleManager.CreateAsync(new IdentityRole(SD.Role_User_Suspended_Guide));

                    // Add default role to user (Tourist).
                    await _userManager.AddToRoleAsync(user, SD.Role_User_Tourist);

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(RegisterVM.Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = RegisterVM.Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);

                        return LocalRedirect(returnUrl);
                    }
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
