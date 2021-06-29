using EgyGuide.DataAccess.Repository.IRepository;
using EgyGuide.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        public OfferedController(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public IActionResult Index()
        {
            IEnumerable<TripDetail> tripList = _unit.OfferCreate.GetAll();

            return View(tripList);
        }
    }
}
