using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyGuide.Areas.TourGuide.Controllers
{
    [Area("TourGuide")]
    [Route("guide/profile")]
    public class GuideProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("tours")]
        public IActionResult Tours()
        {
            return View();
        }
        
        [Route("gallery")]
        public IActionResult Gallery()
        {
            return View();
        }

    }
}
