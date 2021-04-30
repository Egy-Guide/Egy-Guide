
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
    [Route("offered-details")]
    public class OfferedDetailsController : Controller
    {
        private readonly IUnitOfWork _unit;
        private readonly ApplicationDbContext _db;
        public OfferedDetailsController(IUnitOfWork unit, ApplicationDbContext db)
        {
            _unit = unit;
            _db = db;
        }
        public IActionResult Index(int id)
        {
            if(id == 0)
            {
                return RedirectToAction("Index", "Offered");
            }
            var selectedStyles = _db.SelectedStyles.Where(s => s.TripId == id).Select(s=>s.StyleId);
            var included = _db.Includeds.Where(i => i.TripId == id);
            var images = _db.Galleries.Where(i => i.TripId == id);
            var daysDetails = _db.TripDaysDetails.Where(t => t.TripId == id);
            var trip = _unit.OfferCreate.GetFirstOrDefault
                (u => u.TripId == id, includeProperties: "City,SelectedImages,Included,Excluded");
            var city = _db.Cities.SingleOrDefault(s => s.CityId == trip.CityId).Name;
            OfferCreateVM tripVM = new OfferCreateVM()
            {
                TripDetail = trip,
                TripStyles = _db.TripStyles.Where(t=> selectedStyles.Contains(t.StyleId)),
                Included = included,
                Galleries = images,
                TripDaysDetail = daysDetails,
                City = city
            };

            return View(tripVM);
        }
    }
}
