using EgyGuide.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IUnitOfWork _unit;
        private readonly IWebHostEnvironment _hostEnvironment;
        public OfferedCreateController(IUnitOfWork unit, IWebHostEnvironment hostEnvironment)
        {
            _unit = unit;
            _hostEnvironment = hostEnvironment;

        }
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
