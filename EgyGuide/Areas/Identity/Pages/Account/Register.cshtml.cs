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
        public InputModel Input { get; set; }

        [BindProperty]
        public GuideUser Guide { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            // Add another claims.
            [Required]
            public string FirstName { get; set; }
            [Required]
            public string LastName { get; set; }
            [Required]
            public string Country { get; set; }
            [Required]
            public string Nationality { get; set; }
            [Required]
            public string PhoneNumber { get; set; }
            [Required]
            public IFormFile IdentityImage { get; set; }
            public string City { get; set; }

            public string Role { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

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
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    Country = Input.Country,
                    Nationality = Input.Nationality,
                    PhoneNumber = Input.PhoneNumber,
                    City = Input.City,
                    UserName = Input.Email,
                    Email = Input.Email,
                    Role = Input.Role
                };                

                // Add new user.
                var result = await _userManager.CreateAsync(user, Input.Password);

                // Add new guide.
                if (Guide != null)
                {
                    // Locked the new guide for revising.
                    var futureDateLocked = DateTime.Now.AddYears(1000);
                    await _userManager.SetLockoutEndDateAsync(user, futureDateLocked);

                    Guide.UserId = await _userManager.GetUserIdAsync(user);         

                    #region Upload Identity Card

                    string rootPath = _hostEnviroment.WebRootPath;
                    var image = Input.IdentityImage;

                    if (image != null)
                    {
                        string folderPath = Path.Combine(rootPath, @"images\guide-identity");
                        string imageName = Guid.NewGuid().ToString();
                        string extension = Path.GetExtension(image.FileName);

                        string imageURL = Path.Combine(folderPath, imageName + extension);

                        FileStream fileStream = new FileStream(imageURL, FileMode.Create);
                        await image.CopyToAsync(fileStream);
                        
                        Guide.IdentityCardUrl = imageURL;

                    }

                    #endregion

                    _unitOfWork.GuideUser.Add(Guide);
                }                    

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
                    if (user.Role == null)
                        await _userManager.AddToRoleAsync(user, SD.Role_User_Tourist);

                    // Add role to Suspended Guide.
                    if (user.Role == SD.Role_User_Suspended_Guide)
                        await _userManager.AddToRoleAsync(user, SD.Role_User_Suspended_Guide);

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);

                        // This for the new guide
                        if (user.Role == SD.Role_User_Suspended_Guide)
                            return LocalRedirect("/Identity/Account/GuideRegisterConfirmation");

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
