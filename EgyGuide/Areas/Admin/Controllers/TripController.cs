using EgyGuide.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyGuide.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TripController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TripController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Route("/admin/trip")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetTrips()
        {
            var trips = _unitOfWork.OfferCreate.GetAll(includeProperties: "GuideUser.ApplicationUser").Select(t => new
            {
                id = t.TripId,
                title = t.Title,
                tourGuide = t.GuideUser.ApplicationUser.FirstName + " " + t.GuideUser.ApplicationUser.LastName
            });

            return Json(new { data = trips });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var deletedTrip = _unitOfWork.OfferCreate.Get(id);

            if (deletedTrip == null)
                return Json(new { success = false });

            _unitOfWork.OfferCreate.Remove(deletedTrip);
            _unitOfWork.Save();

            return Json(new { success = true });
        }
    }
}
