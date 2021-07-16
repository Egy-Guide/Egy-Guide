using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyGuide.Areas.Tourist.Controllers
{
    [Area("Tourist")]
    [Route("about-us")]
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }        
    }
}
