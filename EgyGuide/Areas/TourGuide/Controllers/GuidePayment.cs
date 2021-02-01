using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyGuide.Areas.TourGuide.Controllers
{
    [Area("TourGuide")]    
    public class GuidePaymentController : Controller
    {
        [Route("guide-payment")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("guide-payment-done")]
        public IActionResult GuidePaymentDone()
        {
            return View();
        }
    }
}
