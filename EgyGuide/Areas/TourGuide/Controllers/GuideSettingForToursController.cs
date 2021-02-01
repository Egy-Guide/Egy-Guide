using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyGuide.Areas.TourGuide.Controllers
{
    [Area("TourGuide")]
    [Route("guide-details-setting-my-tours")]
    public class GuideSettingForToursController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
