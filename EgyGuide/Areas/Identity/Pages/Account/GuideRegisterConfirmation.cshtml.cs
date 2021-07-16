using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EgyGuide.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EgyGuide.Areas.Identity.Pages.Account
{
    [Authorize(Roles = SD.Role_User_Suspended_Guide)]
    public class GuideRegisterConfirmationModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
