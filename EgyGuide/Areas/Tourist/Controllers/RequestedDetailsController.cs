
using EgyGuide.DataAccess.Data;
using EgyGuide.DataAccess.Repository.IRepository;
using EgyGuide.Models.ViewModels;
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
        private readonly IUnitOfWork _unit;
        private readonly ApplicationDbContext _db;
        public RequestedDetailsController(IUnitOfWork unit, ApplicationDbContext db)
        {
            _unit = unit;
            _db = db;
        }
        public IActionResult Index(int id)
        {
            var selectedStyles = _db.RequestedSelectedStyle.Where(s => s.TripId == id).Select(s => s.StyleId);
            var info = _db.RequestedInfo.Where(i => i.TripId == id);
            RequestedVM tripVM = new RequestedVM()
            {
                Requested = _unit.Requested.GetFirstOrDefault
               (u => u.TripId == id, includeProperties: "City"),
                TripStyles = _db.TripStyles.Where(t => selectedStyles.Contains(t.StyleId)),
               RequestedInfos = info
            };
            return View(tripVM);
        }
    }
}
