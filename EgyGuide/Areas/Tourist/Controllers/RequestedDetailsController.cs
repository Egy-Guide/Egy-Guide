using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyGuide.Areas.Tourist.Controllers
{
    [Area("Tourist")]
    [Route("requested-details")]
    public class RequestedDetailsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
