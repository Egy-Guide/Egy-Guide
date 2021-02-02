using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyGuide.Areas.Tourist.Controllers
{
    [Area("Tourist")]
    public class BlogController : Controller
    {
        [Route("blog")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("blog-single")]
        public IActionResult BlogSingle()
        {
            return View();
        }

        [Route("blog-create")]
        public IActionResult BlogCreate()
        {
            return View();
        }
    }
}
