using EgyGuide.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyGuide.Areas.Tourist.Controllers
{
    [Area("Tourist")]
    [Route("tourist/dashboard")]
    [Authorize(Roles = SD.Role_User_Tourist)]
    public class TouristDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
