using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyGuide.Areas.TourGuide.Controllers
{
    [Area("TourGuide")]    
    public class OfferedPaymentController : Controller
    {
        [Route("offered-payment")]
        public IActionResult Index()
        {
            return View();
        }
        
        [Route("offered-payment-done")]
        public IActionResult OfferedPaymentDone()
        {
            return View();
        }
    }
}
