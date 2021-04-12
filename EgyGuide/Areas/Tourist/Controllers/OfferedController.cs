using EgyGuide.DataAccess.Repository.IRepository;
using EgyGuide.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyGuide.Areas.Tourist.Controllers
{
    [Area("Tourist")]
    [Route("offered")]
    public class OfferedController : Controller
    {
        private readonly IUnitOfWork _unit;
        private readonly IWebHostEnvironment _host;
        public OfferedController(IUnitOfWork unit, IWebHostEnvironment host)
        {
            _unit = unit;
            _host = host;
        }
        public IActionResult Index()
        {
            IEnumerable<TripDetail> tripList = _unit.OfferCreate.GetAll();
            return View(tripList);
        }
    }
}
