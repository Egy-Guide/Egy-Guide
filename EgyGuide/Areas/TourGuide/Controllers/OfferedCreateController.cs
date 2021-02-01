using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyGuide.Areas.TourGuide.Controllers
{
    [Area("TourGuide")]    
    public class OfferedCreateController : Controller
    {
        [Route("offered-create")]
        public IActionResult Index()
        {
            return View();
        }
        
        [Route("offered-create-done")]    
        public IActionResult OfferedCreateDone()
        {
            return View();
        }
    }
}
