using EgyGuide.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyGuide.Areas.TourGuide.Controllers
{
    [Area("TourGuide")]
    [Route("guide/dashboard")]
    [Authorize(Roles = SD.Role_User_Tour_Guide)]
    public class GuideDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
