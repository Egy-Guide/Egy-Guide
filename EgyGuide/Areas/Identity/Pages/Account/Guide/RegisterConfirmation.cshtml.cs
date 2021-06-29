using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EgyGuide.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EgyGuide.Areas.Identity.Pages.Account.Guide
{
    [Authorize(Roles = SD.Role_User_Suspended_Guide + "," + SD.Role_User_Tour_Guide)]
    public class RegisterConfirmationModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
