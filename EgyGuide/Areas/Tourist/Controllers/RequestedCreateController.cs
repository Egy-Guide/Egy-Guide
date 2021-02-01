using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyGuide.Areas.Tourist.Controllers
{
    [Area("Tourist")]    
    public class RequestedCreateController : Controller
    {
        [Route("requested-create")]
        public IActionResult Index()
        {
            return View();
        }
        
        [Route("requested-create-done")]
        public IActionResult RequestedCreateDone()
        {
            return View();
        }
    }
}
