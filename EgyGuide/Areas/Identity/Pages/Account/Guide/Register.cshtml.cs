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

namespace EgyGuide.Areas.Identity.Pages.Account.Guide
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

                // Add new guide.
                if (RegisterVM.Guide != null)
                {
                    // Locked the new guide for revising.
                    var futureDateLocked = DateTime.Now.AddYears(1000);
                    await _userManager.SetLockoutEndDateAsync(user, futureDateLocked);

                    RegisterVM.Guide.UserId = await _userManager.GetUserIdAsync(user);         

                    #region Upload Identity Card

                    string rootPath = _hostEnviroment.WebRootPath;
                    var image = RegisterVM.Guide.IdentityImage;

                    if (image != null)
                    {
                        string folderPath = Path.Combine(rootPath, @"images\guide-identity");
                        string imageName = Guid.NewGuid().ToString();
                        string extension = Path.GetExtension(image.FileName);

                        string imageURL = Path.Combine(folderPath, imageName + extension);

                        using (var fileStream = new FileStream(imageURL, FileMode.Create))
                        {
                            await image.CopyToAsync(fileStream);
                            await fileStream.DisposeAsync();
                        }                         

                        RegisterVM.Guide.IdentityCardUrl = imageURL;

                    }

                    #endregion

                    _unitOfWork.GuideUser.Add(RegisterVM.Guide);
                }                    

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    // Add role to Suspended Guide.                    
                    await _userManager.AddToRoleAsync(user, SD.Role_User_Suspended_Guide);

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
                        // EmailService
                        return RedirectToPage("RegisterConfirmation", new { email = RegisterVM.Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);

                        // This for the new guide                        
                        return RedirectToPage("RegisterConfirmation");
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
