
using EgyGuide.DataAccess.Data;
using EgyGuide.DataAccess.Repository.IRepository;
using EgyGuide.Models;
using EgyGuide.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyGuide.Areas.Tourist.Controllers
{
    [Area("Tourist")]
    [Route("requested")]
    public class RequestedController : Controller
    {
        private readonly IUnitOfWork _unit;
        private readonly ApplicationDbContext _db;
        public RequestedController(IUnitOfWork unit, ApplicationDbContext db)
        {
            _unit = unit;
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Requested> tripList = _unit.Requested.GetAll();
            foreach(var trip in tripList)
            {
               var city = _db.Cities.SingleOrDefault(s => s.CityId == trip.CityId).Name;
                trip.City.Name = city;
            }
            return View(tripList);
        }
    }
}
